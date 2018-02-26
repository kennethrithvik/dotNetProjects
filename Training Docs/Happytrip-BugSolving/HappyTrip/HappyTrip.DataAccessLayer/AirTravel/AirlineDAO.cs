using System;
using System.Collections.Generic;
using HappyTrip.DataAccessLayer.Common;
using HappyTrip.Model.Entities.AirTravel;
using System.Data;

namespace HappyTrip.DataAccessLayer.AirTravel
{
    /// <summary>
    /// Class to represent the database related activities  
    /// with respect to airline operations for fetch
    /// </summary>
    class AirlineDAO:DAO,IAirlineDAO
    {

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AirlineDAO()
        {

        }

        #region Method to get the airlines details from the database
        /// <summary>
        /// Gets the airlines from the database
        /// </summary>
        /// <exception cref="AirlineDAOException">Throws an exception if unable to get airlines</exception>
        /// <returns>Returns the array of airlines from the database</returns>
		public Model.Entities.AirTravel.Airline[] GetAirlines()
		{
            List<Airline> airlines = null;
            
            IDbConnection conn = null;
            try
            {
                //Execute the stored procedure to fetch the airline details
                conn = this.GetConnection();
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Select * From Airlines";


                using (IDataReader reader = cmd.ExecuteReader())
                {
                    airlines = new List<Airline>();
                    while (reader.Read())
                    {
                        Airline airline = new Airline();

                        airline.Id = int.Parse(reader["AirlineId"].ToString());
                        airline.Name = reader["AirlineName"].ToString();
                        airline.Code = reader["AirlineCode"].ToString();
                        airline.Logo = reader["AirlineLogo"].ToString();

                        airlines.Add(airline);
                    }

                }
                return airlines.ToArray();
            }
            catch (ConnectToDatabaseException ex)
            {
                throw new AirlineDAOException("Unable to get airlines", ex);
            }
            catch (Exception ex)
            {
                throw new AirlineDAOException("Unable to get airlines", ex);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
			
			
		}
        #endregion

    }
}
        