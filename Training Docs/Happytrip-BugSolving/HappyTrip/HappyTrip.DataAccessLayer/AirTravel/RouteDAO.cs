using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.DataAccessLayer.Common;
//using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.Model.Entities.Common;

namespace HappyTrip.DataAccessLayer.AirTravel
{
	/// <summary>
	/// Class to represent the database related activities  
	/// with respect to routes operations for fetch,add,update
	/// </summary>
	class RouteDAO : DAO, IRouteDAO
	{

		#region Making the constructor public
		public RouteDAO()
		{

		}
		#endregion

		

		#region Method to get the routes from the database
		/// <summary>
		/// Gets the routes from the database
		/// </summary>
		/// <returns>Returns an array of routes from the database</returns>
		public Route[] GetRoutes()
		{
            List<Route> routes = null;
            IDbConnection conn = null;
			try
			{
                conn = this.GetConnection();
                conn.Open();

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "GetRoutes";
                cmd.CommandType = CommandType.StoredProcedure;


				using (IDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
				{
                    routes = new List<Route>();

					while (Reader.Read())
					{
                        Route route = new Route();
                        route.ID = long.Parse(Reader["RouteId"].ToString());

                        City fromCity = new City();
                        fromCity.CityId = long.Parse(Reader["FromCityId"].ToString());
                        fromCity.Name = Reader["FromCityName"].ToString();

                        route.FromCity = fromCity;

                        City toCity = new City();
                        toCity.CityId = long.Parse(Reader["ToCityId"].ToString());
                        toCity.Name = Reader["ToCityName"].ToString();

                        route.ToCity = toCity;

                        route.IsActive = bool.Parse(Reader["Status"].ToString());
                        route.DistanceInKms = double.Parse(Reader["DistanceInKms"].ToString().Trim());

                        routes.Add(route);
					}

				}
			}
			catch (Common.ConnectToDatabaseException)
			{

				throw new RouteDAOException("Unable to get routes");
			}
			catch (Exception)
			{
				throw new RouteDAOException("Unable to get routes");
			}

			return routes.ToArray();
		}
		#endregion

		#region Method to add the routes to the database
		/// <summary>
		/// Add the routes to the database
		/// </summary>
		/// <parameter name="RouteInfo"></parameter>
		/// <returns>int</returns>
		public int AddRoute(Model.Entities.AirTravel.Route RouteInfo)
		{
            IDbConnection conn = null;
            try
            {
                conn = this.GetConnection();
                conn.Open();


                IDbCommand cmd = conn.CreateCommand();
                //string insertSQL = @"insert into Routes(FromCityId,ToCityId,DistanceInKms,Status) values(@fromcityID,@toCityID,@dis,@st);";
                cmd.CommandText = "InsertRoute";
                cmd.CommandType = CommandType.StoredProcedure;

				IDataParameter p1 = cmd.CreateParameter();
                p1.ParameterName = "@fromcityID";
                p1.Value = RouteInfo.FromCity.CityId;
                cmd.Parameters.Add(p1);

                IDataParameter p2 = cmd.CreateParameter();
                p2.ParameterName = "@tocityID";
                p2.Value = RouteInfo.ToCity.CityId;
                cmd.Parameters.Add(p2);

                IDataParameter p3 = cmd.CreateParameter();
                p3.ParameterName = "@dis";
                p3.Value = RouteInfo.DistanceInKms;
                cmd.Parameters.Add(p3);


                IDataParameter p4 = cmd.CreateParameter();
                p4.ParameterName = "@st";
                p4.Value = RouteInfo.IsActive;
                cmd.Parameters.Add(p4);

                return cmd.ExecuteNonQuery();
            }
            catch (Common.ConnectToDatabaseException)
            {
                throw new RouteDAOException("Unable to add route");
            }
            catch (Exception)
            {
                throw new RouteDAOException("Unable to add route");
            }
            finally
            {
                conn.Close();
            }

		}
		#endregion

		#region Method to update the existing routes to the database
		/// <summary>
		/// Update the existing routes to the database
		/// </summary>
		/// <parameter name="RouteInfo"></parameter>
		/// <returns>Status of the update</returns>
		public bool UpdateRoute(Model.Entities.AirTravel.Route RouteInfo)
		{
            IDbConnection conn = null;
            bool isUpdated = false;
            try
            {
                conn = this.GetConnection();
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateRoutes";

                IDataParameter p1 = cmd.CreateParameter();
                p1.ParameterName = "@ID";
                p1.Value = RouteInfo.ID;
                cmd.Parameters.Add(p1);

                IDataParameter p2 = cmd.CreateParameter();
                p2.ParameterName = "@DisInKms";
                p2.Value = RouteInfo.DistanceInKms;
              
                cmd.Parameters.Add(p2);

                IDataParameter p3 = cmd.CreateParameter();
                p3.ParameterName = "@Status";
                p3.Value = RouteInfo.IsActive;
           
                cmd.Parameters.Add(p3);
                
                cmd.ExecuteNonQuery();

                isUpdated = true;
            }
            catch (Common.ConnectToDatabaseException)
            {
                throw new RouteDAOException("Unable to update route");
            }
            catch (Exception)
            {
                throw new RouteDAOException("Unable to update route");
            }
            finally
            {
                if(conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }

            return isUpdated;	

		}
		#endregion

		#region Method to get the route id for a schedule from the database
		/// <summary>
		/// Gets the route id for a schedule from the database
		/// </summary>
		/// <parameter name="ScheduleInfo"></parameter>
		/// <returns>int</returns>
		public int GetRouteID(Route RouteInfo)
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
                p1.Value = RouteInfo.FromCity.Name;
                cmd.Parameters.Add(p1);

                IDataParameter p2 = cmd.CreateParameter();
                p2.ParameterName = "@tocity";
                p2.Value = RouteInfo.ToCity.Name;
                cmd.Parameters.Add(p2);


				int routeId = 0;



				using (IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
				{


					while (reader.Read())
					{
						routeId = int.Parse(reader["RouteId"].ToString());
					}

					return routeId;
				}
			}
			catch (Common.ConnectToDatabaseException)
			{
				throw new RouteDAOException("Unable to get route id");
			}
			catch (Exception)
			{
				throw new RouteDAOException("Unable to get route id");
			}
		}
		#endregion

	}
}
