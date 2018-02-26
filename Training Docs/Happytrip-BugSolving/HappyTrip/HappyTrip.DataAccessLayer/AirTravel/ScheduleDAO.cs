using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.DataAccessLayer.Common;
using HappyTrip.Model.Entities.AirTravel;
using System.Data;
using HappyTrip.Model.Entities.Common;
using System.Data.Common;


namespace HappyTrip.DataAccessLayer.AirTravel
{
	/// <summary>
	/// Class to represent the database related activities  
	/// with respect to schedule operations for fetch,add,update
	/// </summary>
	class ScheduleDAO : DAO, IScheduleDAO
	{
		

		#region Making the constructor public
		public ScheduleDAO()
		{

		}
		#endregion

        #region Method to get the schedules from the database
        /// <summary>
        /// Gets the schedules from the database
        /// </summary>
        /// <returns>A Collection of Schedules</returns>
        public Model.Entities.AirTravel.Schedule[] GetSchedules()
        {
            List<Schedule> _schedulelist = new List<Schedule>();

            try
            {
                IDbConnection conn = this.GetConnection();
                IDbConnection conn2 = this.GetConnection();
                conn.Open();
                conn2.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "GetScheduleFlight";
                cmd.CommandType = CommandType.StoredProcedure;
                using (IDataReader Reader = cmd.ExecuteReader())
                {

                    while (Reader.Read())
                    {
                        Schedule _schedule = new Schedule();

                        _schedule.ID = long.Parse(Reader["ScheduleId"].ToString());

                        Airline _airline = new Airline();
                        _airline.Id = int.Parse(Reader["AirlineId"].ToString());
                        _airline.Name = Reader["AirlineName"].ToString();

                        Flight _flight = new Flight();
                        _flight.ID = long.Parse(Reader["FlightId"].ToString());
                        _flight.AirlineForFlight = _airline;
                        _flight.Name = Reader["FlightName"].ToString();

                        _schedule.FlightInfo = _flight;

                        City _fromcity = new City();
                        _fromcity.CityId = long.Parse(Reader["FromId"].ToString());
                        _fromcity.Name = Reader["FromCity"].ToString();

                        City _tocity = new City();
                        _tocity.CityId = long.Parse(Reader["ToId"].ToString());
                        _tocity.Name = Reader["ToCity"].ToString();

                        Route _route = new Route();
                        _route.ID = long.Parse(Reader["RouteId"].ToString());
                        _route.FromCity = _fromcity;
                        _route.ToCity = _tocity;
                        _route.DistanceInKms = long.Parse(Reader["DistanceInKms"].ToString());
                        _schedule.RouteInfo = _route;

                        DateTime dateTime = DateTime.Parse(Reader["DepartureTime"].ToString());
                        TimeSpan dtime = new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second);
                        _schedule.DepartureTime = dtime;

                        dateTime = DateTime.Parse(Reader["ArrivalTime"].ToString());
                        TimeSpan atime = new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second);
                        _schedule.ArrivalTime = atime;
                        
                        _schedule.DurationInMins = int.Parse(Reader["DurationInMins"].ToString());
                        _schedule.IsActive = bool.Parse(Reader["Status"].ToString());


                        IDbCommand cmd2 = conn2.CreateCommand();
                        cmd2.CommandText = "getScheduleFlightCost";
                        cmd2.CommandType = CommandType.StoredProcedure;
                        IDataParameter param = cmd2.CreateParameter();
                        param.Direction = ParameterDirection.Input;
                        param.ParameterName = "@scheduleid";
                        param.Value = _schedule.ID;
                        cmd2.Parameters.Add(param);
                        using (IDataReader Reader2 = cmd2.ExecuteReader())
                        {
                            try
                            {
                                while (Reader2.Read())
                                {
                                    FlightCost _classcost = new FlightCost();
                                    int classid = int.Parse(Reader2["ClassId"].ToString());
                                    _classcost.Class = (TravelClass)classid;
                                    _classcost.CostPerTicket = int.Parse(Reader2["CostPerTicket"].ToString());
                                    _schedule.AddFlightCost(_classcost);
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        _schedulelist.Add(_schedule);
                    }

                }
            }
            catch (Common.ConnectToDatabaseException)
            {
                throw new ScheduleDAOException("Unable to get schedules");
            }
            catch (Exception ex)
            {
                throw new ScheduleDAOException("Unable to get schedules");
            }

            return _schedulelist.ToArray();
        }
        #endregion

		#region Method to get the route id for a schedule from the database
		/// <summary>
		/// Gets the route id for a schedule from the database
		/// </summary>
		/// <parameter name="ScheduleInfo"></parameter>
		/// <returns>Returns the route id for a given schedule</returns>
		public int GetRouteID(Model.Entities.AirTravel.Schedule scheduleInfo)
		{
            IDbConnection conn = null;
            try
			{
                conn = this.GetConnection();
                conn.Open();

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "getRouteId";
                cmd.CommandType = CommandType.StoredProcedure;

                IDataParameter p1 = cmd.CreateParameter();
                p1.ParameterName = "@fromcity";
                p1.Value = scheduleInfo.RouteInfo.FromCity.Name;
                cmd.Parameters.Add(p1);

                IDataParameter p2 = cmd.CreateParameter();
                p2.ParameterName = "@tocity";
                p2.Value = scheduleInfo.RouteInfo.ToCity.Name;
                cmd.Parameters.Add(p2);


				int RouteId = 0;


				using (IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
				{

					while (reader.Read())
					{
						RouteId = int.Parse(reader["RouteId"].ToString());
					}

                    return RouteId;
				}
			}
			catch (Common.ConnectToDatabaseException)
			{
				throw new ScheduleDAOException("Unable to get route id");
			}
			catch (Exception)
			{
				throw new ScheduleDAOException("Unable to get route id");
			}
		}
		#endregion

		#region Method to add the schedule for the database
		/// <summary>
		/// Add the schedule for the database
		/// </summary>
		/// <parameter name="ScheduleInfo"></parameter>
		/// <returns>Returns the number of rows affected</returns>
		public int AddSchedule(Model.Entities.AirTravel.Schedule scheduleInfo)
		{
            IDbConnection conn = null;
            int RouteId = 0;

            RouteId = GetRouteID(scheduleInfo);

            if (RouteId == 0)
               throw new RouteNotAvailableForScheduleDAOException("Route not available for the given schedule information");
    
            try
            {
                var scheduleID = InsertSchedule(scheduleInfo, ref conn, RouteId);

                foreach (FlightCost item in scheduleInfo.GetFlightCosts())
                {
                    int classId = (int)item.Class;

                    InsertFlightCost(scheduleID, classId, item.CostPerTicket);

                }

            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new ScheduleDAOException("Unable to add schedule", ex);
            }
            catch (Exception ex)
            {
                throw new ScheduleDAOException("Unable to add schedule", ex);
            }
			return 0;
		}


        /// <summary>
        /// Inserts record into FlightCost
        /// </summary>
        /// <param name="scheduleID"></param>
        /// <param name="classId"></param>
        /// <param name="cost"></param>
        private void InsertFlightCost(long scheduleID, int classId, decimal cost)
        {
			IDbConnection conn = null;
            string insertSQL = "insert into FlightCosts(ScheduleID,ClassID,CostPerTicket) values(" + scheduleID + "," + classId + "," + cost + ")";
			try
			{
				conn = this.GetConnection();
				conn.Open();
				IDbCommand cmd = conn.CreateCommand();
				cmd.CommandText = insertSQL;
				cmd.CommandType = CommandType.Text;
				cmd.ExecuteNonQuery();
			}
			finally
			{
				conn.Close();
			}
        }


        /// <summary>
        /// Inserts Data into Schedule Table and returns the schedule id
        /// </summary>
        /// <param name="ScheduleInfo"></param>
        /// <param name="conn"></param>
        /// <param name="RouteId"></param>
        /// <returns>Returns the inserted schedule's id</returns>
        private long InsertSchedule(Model.Entities.AirTravel.Schedule scheduleInfo, ref IDbConnection conn, int routeId)
        {
            conn = this.GetConnection();
            conn.Open();

            string insertSQL = @"insert into Schedules(FlightId,RouteId,DepartureTime,ArrivalTime,DurationInMins,IsActive) 
   values(@flightid,@routeid,@departmenttime,@arrivaltime,@dur,@isactive)";

            IDbCommand cmd = conn.CreateCommand();

            cmd.CommandText = insertSQL;
            cmd.CommandType = CommandType.Text;

            IDataParameter p1 = cmd.CreateParameter();
            p1.ParameterName = "@flightid";
            p1.Value = scheduleInfo.FlightInfo.ID;
            cmd.Parameters.Add(p1);

            IDataParameter p2 = cmd.CreateParameter();
            p2.ParameterName = "@routeid";
            p2.Value = routeId;
            cmd.Parameters.Add(p2);

            IDataParameter p3 = cmd.CreateParameter();
            p3.ParameterName = "@departmenttime";
            DateTime dTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, scheduleInfo.DepartureTime.Hours, scheduleInfo.DepartureTime.Minutes, 0);
            p3.Value = dTime;
            cmd.Parameters.Add(p3);

            IDataParameter p4 = cmd.CreateParameter();
            p4.ParameterName = "@arrivaltime";
            DateTime aTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, scheduleInfo.ArrivalTime.Hours, scheduleInfo.ArrivalTime.Minutes, 0);
            p4.Value = aTime;
            cmd.Parameters.Add(p4);


            IDataParameter p5 = cmd.CreateParameter();
            p5.ParameterName = "@dur";
            p5.Value = scheduleInfo.DurationInMins;
            cmd.Parameters.Add(p5);


            IDataParameter p6 = cmd.CreateParameter();
            p6.ParameterName = "@isactive";
            p6.Value = scheduleInfo.IsActive;
            cmd.Parameters.Add(p6);

            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT @@IDENTITY AS TEMPVALUE";
            long scheduleID = Convert.ToInt64(cmd.ExecuteScalar());
            return scheduleID;
        }
		#endregion

		#region Method to update the existing schedule for the database
		/// <summary>
		/// Update the existing schedule for the database
		/// </summary>
		/// <parameter name="ScheduleInfo"></parameter>
		/// <returns>int</returns>
		public bool UpdateSchedule(Model.Entities.AirTravel.Schedule scheduleInfo)
		{
            IDbConnection conn = null;
            bool isUpdated = false;
            try
            {
                int RouteId = GetRouteID(scheduleInfo);

                conn = this.GetConnection();
                conn.Open();

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UpdateSchedule";
                cmd.CommandType = CommandType.StoredProcedure;

                IDataParameter p1 = cmd.CreateParameter();
                p1.ParameterName = "@scheduleid";
                p1.Value = scheduleInfo.ID;
                cmd.Parameters.Add(p1);

                IDataParameter p2 = cmd.CreateParameter();
                p2.ParameterName = "@flightid";
                p2.Value = scheduleInfo.FlightInfo.ID;
                cmd.Parameters.Add(p2);

                IDataParameter p3 = cmd.CreateParameter();
                p3.ParameterName = "@routeid";
                p3.Value = RouteId;
                cmd.Parameters.Add(p3);

                IDataParameter p7 = cmd.CreateParameter();
                p7.ParameterName = "@departuretime";
                p7.Value = scheduleInfo.DepartureTime;
                cmd.Parameters.Add(p7);

                IDataParameter p4 = cmd.CreateParameter();
                p4.ParameterName = "@arrivaltime";
                p4.Value = scheduleInfo.ArrivalTime;
                cmd.Parameters.Add(p4);
               
                IDataParameter p5 = cmd.CreateParameter();
                p5.ParameterName = "@durationinmins";
                p5.Value = scheduleInfo.DurationInMins;
                cmd.Parameters.Add(p5);

                IDataParameter p6 = cmd.CreateParameter();
                p6.ParameterName = "@isactive";
                p6.Value = scheduleInfo.IsActive;
                cmd.Parameters.Add(p6);

                cmd.ExecuteNonQuery();

                isUpdated = true;
            }
            catch (Common.ConnectToDatabaseException)
            {
                throw new ScheduleDAOException("Unable to update schedule");
            }
            catch (Exception ex)
            {
                throw new ScheduleDAOException("Unable to update schedule");
            }
            finally
            {
                conn.Close();
            }

            return isUpdated;
		}
		#endregion

		#region Method to update the existing flight cost for the specific schedule id for the database
		/// <summary>
		/// Update the existing flight cost for the specific schedule id for the database
		/// </summary>
		/// <parameter name="FlightCostInfo"></parameter>
		/// <parameter name="ScheduleInfo"></parameter>
		/// <returns>int</returns>
		public int UpdateScheduleFlightCost(Schedule ScheduleInfo, FlightCost FlightCostInfo)
		{
            IDbConnection conn = null;
            try
            {
                conn = this.GetConnection();
                conn.Open();

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UpdateFlightCost";
                cmd.CommandType = CommandType.StoredProcedure;

                IDataParameter p1 = cmd.CreateParameter();
                p1.ParameterName = "@scheduleid";
                p1.Value = ScheduleInfo.ID;
                cmd.Parameters.Add(p1);

                IDataParameter p2 = cmd.CreateParameter();
                p2.ParameterName = "@classid";
                p2.Value = FlightCostInfo.Class;
                cmd.Parameters.Add(p2);

                IDataParameter p3 = cmd.CreateParameter();
                p3.ParameterName = "@cost";
                p3.Value = FlightCostInfo.CostPerTicket;
                cmd.Parameters.Add(p3);


                return cmd.ExecuteNonQuery();
            }
            catch (Common.ConnectToDatabaseException)
            {
                throw new ScheduleDAOException("Unable to update schedule flight cost");
            }
            catch (Exception)
            {
                throw new ScheduleDAOException("Unable to update schedule flight cost");
            }
            finally
            {
                conn.Close();
            }
		}
		#endregion

		#region Method to get the schedule details for a given schedule id from the database
		/// <summary>
		/// Get the schedule details for a given schedule id from the database
		/// </summary>
		/// <parameter name="ScheduleId"></parameter>
		/// <returns>Returns the schedule information<Schedule></returns>
		public Model.Entities.AirTravel.Schedule GetSchedule(long scheduleId)
		{
            Schedule schedule = null;
            IDbConnection conn = null;
			try
			{
                conn = this.GetConnection();
                conn.Open();

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "getScheduleDetails_BasedID";
                cmd.CommandType = CommandType.StoredProcedure;

                IDataParameter p1 = cmd.CreateParameter();
                p1.ParameterName = "@scheduleid";
                p1.Value = scheduleId;
                cmd.Parameters.Add(p1);

				using (IDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						schedule = new Schedule();

						schedule.ID = long.Parse(reader["ScheduleId"].ToString());

						Airline airline = new Airline();
						airline.Id = int.Parse(reader["AirlineId"].ToString());
						airline.Name = reader["AirlineName"].ToString();

						Flight flight = new Flight();
						flight.ID = long.Parse(reader["FlightId"].ToString());
					    flight.AirlineForFlight = airline;
						flight.Name = reader["FlightName"].ToString();

						schedule.FlightInfo = flight;

						City fromcity = new City();
						fromcity.CityId = long.Parse(reader["FromId"].ToString());
						fromcity.Name = reader["FromCity"].ToString();

						City tocity = new City();
						tocity.CityId = long.Parse(reader["ToId"].ToString());
						tocity.Name = reader["ToCity"].ToString();

						Route route = new Route();
						route.ID = long.Parse(reader["RouteId"].ToString());
						route.FromCity = fromcity;
						route.ToCity = tocity;
						route.DistanceInKms = long.Parse(reader["DistanceInKms"].ToString());
						schedule.RouteInfo = route;

                        DateTime dtime = Convert.ToDateTime(reader["DepartureTime"]);
                        TimeSpan sp1 = new TimeSpan(dtime.Hour, dtime.Minute, dtime.Second);

                        DateTime atime = Convert.ToDateTime(reader["ArrivalTime"]);
                        TimeSpan sp2 = new TimeSpan(atime.Hour, atime.Minute, atime.Second);

                        schedule.DepartureTime = sp1;
                        schedule.ArrivalTime = sp2;

						schedule.DurationInMins = int.Parse(reader["DurationInMins"].ToString());
						schedule.IsActive = bool.Parse(reader["Status"].ToString());

                        //Method call to get flight costs
                        List<FlightCost> flightCosts = GetFlightCostsForSchedule(schedule.ID);

                        foreach (FlightCost cost in flightCosts)
                        {
                            schedule.AddFlightCost(cost);
                        }
					}

				}
			}
			catch (Common.ConnectToDatabaseException)
			{
				throw new ScheduleDAOException("Unable to get the schedule details");
			}
            catch (ScheduleDAOException ex)
            {
                throw ex;
            }
			catch (Exception)
			{
				throw new ScheduleDAOException("Unable to get the schedule details");
			}
			return schedule;
		}

        /// <summary>
        /// Gets the flight costs for a given schedule
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        public List<FlightCost> GetFlightCostsForSchedule(long scheduleId)
        {
            List<FlightCost> flightCosts = null;

            IDbConnection conn = null;
            try
            {
                conn = this.GetConnection();
                conn.Open();

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "getScheduleFlightCost";
                cmd.CommandType = CommandType.StoredProcedure;

                IDataParameter p1 = cmd.CreateParameter();
                p1.ParameterName = "@scheduleid";
                p1.Value = scheduleId;
                cmd.Parameters.Add(p1);

                using (IDataReader Reader2 = cmd.ExecuteReader())
                {
                    flightCosts = new List<FlightCost>();
                    while (Reader2.Read())
                    {
                        FlightCost classCost = new FlightCost();
                        int classid = int.Parse(Reader2["ClassId"].ToString());
                        classCost.Class = (TravelClass)classid;
                        classCost.CostPerTicket = int.Parse(Reader2["CostPerTicket"].ToString());

                        flightCosts.Add(classCost);
                    }
                   
                }
            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new ScheduleDAOException("Unable to get the schedule cost details", ex);
            }
            catch (Exception ex)
            {
                throw new ScheduleDAOException("Unable to get the schedule cost details", ex);
            }

            return flightCosts;
        }


		#endregion

	}
}
