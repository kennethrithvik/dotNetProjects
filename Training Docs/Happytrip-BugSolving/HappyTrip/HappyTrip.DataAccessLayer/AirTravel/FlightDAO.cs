using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.DataAccessLayer.Common;
using HappyTrip.Model.Entities.AirTravel;
using System.Data;
using System.Data.SqlClient;
//using Microsoft.Practices.EnterpriseLibrary.Data;
//using Microsoft.Practices.EnterpriseLibrary.Data;

namespace HappyTrip.DataAccessLayer.AirTravel
{
	/// <summary>
	/// Class to represent the database related activities  
	/// with respect to flight operations for fetch,add,update
	/// </summary>
	class FlightDAO : DAO, IFlightDAO
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		public FlightDAO()
		{

		}

        #region Method to get the flight details from the database
        /// <summary>
        /// Get the flight details from the database
        /// </summary>
        /// <exception cref="FlightDAOException">Thorws an exception when unable to get flights</exception>
        /// <returns>Returns the array of flights from the database</returns>
        public Flight[] GetFlights()
        {
            List<Flight> flights = new List<Flight>();

            try
            {
                IDbConnection db = GetConnection();
                db.Open();
                IDbCommand cmd1 = db.CreateCommand();
                cmd1.CommandText = "GetFlights";
                cmd1.CommandType = CommandType.StoredProcedure;

                using (IDataReader reader = cmd1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flight flight = new Flight();

                        flight.ID = long.Parse(reader["FlightId"].ToString());
                        flight.Name = reader["FlightName"].ToString();
                        flight.AirlineForFlight = new Airline();
                        flight.AirlineForFlight.Id = int.Parse(reader["AirlineId"].ToString());
                        flight.AirlineForFlight.Name = reader["AirlineName"].ToString();
                        flight.AirlineForFlight.Code = reader["AirlineCode"].ToString();

                        GetClassDetails(flight);
                       
                        flights.Add(flight);
                    }

                }
            }
            catch (ConnectToDatabaseException ex)
            {
                throw new FlightDAOException("Unable to connect to database", ex);
            }
            catch (Exception ex)
            {
                throw new FlightDAOException("Unable to get flights", ex);
            }

            return flights.ToArray();
        }
        #endregion

        private void GetClassDetails(Flight flight)
        {
            IDbConnection db = GetConnection();
            db.Open();
            IDbCommand cmd2 = db.CreateCommand();
            cmd2.CommandText = "GetFlightClasses";
            cmd2.CommandType = CommandType.StoredProcedure;
            IDbDataParameter p1 = cmd2.CreateParameter();
            p1.ParameterName = "@FlightId";
            p1.Value = flight.ID;
            cmd2.Parameters.Add(p1);
            using (IDataReader reader2 = cmd2.ExecuteReader())
            {
                try
                {
                    while (reader2.Read())
                    {
                        FlightClass _class = new FlightClass();
                        int classid = int.Parse(reader2["ClassId"].ToString());
                        _class.ClassInfo = (TravelClass)classid;

                        _class.NoOfSeats = int.Parse(reader2["NoOfSeats"].ToString());
                        flight.AddClass(_class);
                    }
                    db.Close();
                }
                catch (Exception)
                {
                    throw;
                }
               
            }
        }

		#region Method to get the flight details for a given flight id from the database
		/// <summary>
		/// Get the flights details for a given flight from the database
		/// </summary>
		/// <parameter name="FlightId"></parameter>
		/// <returns>Returns a flight for a given flight id from the database</returns>
		public Flight GetFlight(int FlightId)
		{
            Flight flight = null;
            IDbConnection conn = null;
            IDbConnection conn2 = null;
            try
            {
                conn = this.GetConnection();
                conn.Open();
                IDbCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = "GetFlightsID";
                cmd1.CommandType = CommandType.StoredProcedure;

                IDataParameter p1 = cmd1.CreateParameter();
                p1.ParameterName = "@FlightID";
                p1.Value = FlightId;
                cmd1.Parameters.Add(p1);


                conn2 = this.GetConnection();
                conn2.Open();
                IDbCommand cmd2 = conn2.CreateCommand();
                cmd2.CommandText = "GetFlightClasses";
                cmd2.CommandType = CommandType.StoredProcedure;
                IDataParameter p = cmd2.CreateParameter();
                p.ParameterName = "@FlightId";
                cmd2.Parameters.Add(p);

                using (IDataReader Reader = cmd1.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        flight = new Flight(); 
                        flight.ID = long.Parse(Reader["FlightId"].ToString());
                        flight.Name = Reader["FlightName"].ToString();
                        flight.AirlineForFlight = new Airline();
                        flight.AirlineForFlight.Id = int.Parse(Reader["AirlineId"].ToString());
                        flight.AirlineForFlight.Name = Reader["AirlineName"].ToString();
                        flight.AirlineForFlight.Code = Reader["AirlineCode"].ToString();

                        p.Value = flight.ID;

                        using (IDataReader reader2 = cmd2.ExecuteReader())
                        {
                            try
                            {
                                while (reader2.Read())
                                {
                                    FlightClass fClass = null;
                                    fClass = new FlightClass();
                                    int classid = int.Parse(reader2["ClassId"].ToString());
                                    fClass.ClassInfo = (TravelClass)classid;

                                    fClass.NoOfSeats = int.Parse(reader2["NoOfSeats"].ToString());
                                    flight.AddClass(fClass);
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
            }
            catch (Common.ConnectToDatabaseException)
            {
                throw new FlightDAOException("Unable to get the flight details");
            }
            catch (Exception)
            {
                throw new FlightDAOException("Unable to get the flight details");
            }
            finally
            {
                if(conn!=null && conn.State == ConnectionState.Open)
                    conn.Close();

                if (conn2 != null && conn2.State == ConnectionState.Open)
                    conn2.Close();
            }

			return flight;
		}
		#endregion

		#region Method to Add the flight details for the database
		/// <summary>
		/// Add the flight details for the database
		/// </summary>
		/// <parameter name="flight"></parameter>
		/// <returns>bool</returns>
		public bool AddFlight(Flight flight)
		{
			long flightId = 0;
			bool flag = false;

            try
            {
                int cityCount = GetFlightCount(flight);
                if (cityCount > 0)
                    {
                        flag = false;
                    }
                else
                    {
                        flightId = InsertFlight(flight);
                        foreach (FlightClass item in flight.GetClasses())
                        {
                            int ClassId = (int)item.ClassInfo;
                            int NoOfSeats = item.NoOfSeats;
                            InsertFlightClass(flightId, ClassId, NoOfSeats);
                        }
                        return true;
                    }
                return flag;
            }
            catch (Common.ConnectToDatabaseException)
            {
                throw new FlightDAOException("Unable to add flight");
            }
            catch (Exception)
            {
                throw new FlightDAOException("Unable to add flight");
            }
            
        }

        private void InsertFlightClass(long flightId, int ClassId, int NoOfSeats)
        {
            IDbConnection conn = null;
            try
            {
                string query = "INSERT INTO FlightClasses (FlightId, ClassId, NoOfSeats) VALUES ('" + flightId + "','" + ClassId + "','" + NoOfSeats + "')";

                conn = this.GetConnection();
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new FlightDAOException("Unable to add flight");
            }
            finally
            {
                conn.Close();
            }
        }
            
        private  long InsertFlight(Flight flight)
        {
            IDbConnection conn = this.GetConnection();
            conn.Open();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Flights (AirlineId, FlightName) VALUES(@AirLineId,@FlightName)";

            IDataParameter p1 = cmd.CreateParameter();
            p1.ParameterName = "@FlightName";
            p1.Value = flight.Name;
            cmd.Parameters.Add(p1);

            IDataParameter p2 = cmd.CreateParameter();
            p2.ParameterName = "@AirLineId";
            p2.Value = flight.AirlineForFlight.Id;
            cmd.Parameters.Add(p2);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "SELECT @@IDENTITY AS TEMPVALUE";
            long flightID =Convert.ToInt64( cmd.ExecuteScalar());
            return flightID;
        }

        private int GetFlightCount(Flight flight)
        {
            IDbConnection conn = null;
            try
            {
                conn = this.GetConnection();
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select count(*) as FlightCount from flights where FlightName = '" + flight.Name + "' and AirlineId = " + flight.AirlineForFlight.Id;
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            
        }
		#endregion

		#region Method to update the existing flight details for a given flight id for the database
		/// <summary>
		/// Update the existing flight details for a given flight id for the database
		/// </summary>
		/// <parameter name="_flight"></parameter>
		/// <returns>Returns the status of the update</returns>
		public bool UpdateFlight(Flight _flight)
		{
            IDbConnection conn1 = null;
            IDbConnection conn2 = null;
            bool isUpdated = false;
            try
            {
                conn1 = this.GetConnection();
                conn1.Open();

                IDbCommand cmd = conn1.CreateCommand();
                cmd.CommandText = "select count(*) from flights where FlightName = '" + _flight.Name + "' and AirlineId = " + _flight.AirlineForFlight.Id;
                cmd.CommandType = CommandType.Text;

                conn2 = this.GetConnection();
                conn2.Open();
                IDbCommand cmd2 = conn2.CreateCommand();
                
                cmd2.CommandText = "UpdateFlight";
                cmd2.CommandType = CommandType.StoredProcedure;

                IDataParameter p1 = cmd2.CreateParameter();
                //command.Parameters.AddWithValue("@Course", comboBox1.Text);
                p1.ParameterName = "@flightid";
                p1.Value = _flight.ID;
                cmd2.Parameters.Add(p1);

                IDataParameter p2 = cmd2.CreateParameter();
                p2.ParameterName = "@flightname";
                p2.Value = _flight.Name;
                cmd2.Parameters.Add(p2);

                IDataParameter p3 = cmd2.CreateParameter();
                p3.ParameterName = "@airlineId";
                p3.Value = _flight.AirlineForFlight.Id;
                cmd2.Parameters.Add(p3);

                using (IDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        int count=int.Parse(reader[0].ToString());
                        if ( count > 0)
                        {
                            isUpdated = false;
                        }
                        else
                        {
                            cmd2.ExecuteNonQuery();
                            isUpdated = true;
                        }
                    }
                }
            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new FlightDAOException("Unable to update flight");
            }
            catch (Exception ex)
            {
                throw new FlightDAOException("Unable to update flight");
            }
            finally
            {
                if (conn1 != null && conn1.State == ConnectionState.Open)
                    conn1.Close();

                if (conn2 != null && conn2.State == ConnectionState.Open)
                    conn2.Close();
            }

            return isUpdated;
		}
		#endregion

		#region Method to update the existing flight class seats for a given flight id for the database
		/// <summary>
        /// Update the existing flight class seats for a given flight id for the database
		/// </summary>
		/// <param name="_flight"></param>
		/// <param name="_flightclass"></param>
		/// <returns>Returns the number of rows updated</returns>
		public int UpdateFlightClass(Flight flight, FlightClass flightClass)
		{
            IDbConnection conn1 = null;
            int flag = 0;
            try
            {
                conn1 = this.GetConnection();
                conn1.Open();

                
                IDbCommand cmd = conn1.CreateCommand();
                cmd.CommandText = "UpdateFlightClass";
                cmd.CommandType = CommandType.StoredProcedure;

                IDataParameter p1 = cmd.CreateParameter();
                p1.ParameterName = "@flightId";
                p1.Value = flight.ID;
                cmd.Parameters.Add(p1);

                IDataParameter p2 = cmd.CreateParameter();
                p2.ParameterName = "@classId";
                p2.Value = (int)flightClass.ClassInfo;
                cmd.Parameters.Add(p2);

                IDataParameter p3 = cmd.CreateParameter();
                p3.ParameterName = "@noOfSeats";
                p3.Value = flightClass.NoOfSeats;
                cmd.Parameters.Add(p3);

                flag = cmd.ExecuteNonQuery();
                
                
            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new FlightDAOException("Unable to update flight class");
            }
            catch (Exception ex)
            {
                throw new FlightDAOException("Unable to update flight class");
            }
            finally
            {
                if (conn1 != null && conn1.State == ConnectionState.Open)
                    conn1.Close();
            }

            return flag;

		}
		#endregion

	}
}
