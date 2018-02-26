using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.DataAccessLayer.Common;
using HappyTrip.Model.Entities.Common;
using System.Data;
using System.Data.SqlClient;

namespace HappyTrip.DataAccessLayer.Common
{
    /// <summary>
    /// Class to represent the database related activities  
    /// with respect to cities operations for fetch,add,update
    /// </summary>
    class CityDAO : DAO, ICityDAO
    {

        #region Making the constructor public
        /// <summary>
        /// Default Constructor - For initialization
        /// </summary>
        public CityDAO()
        {

        }
        #endregion

        #region Method to get the states from the database
        /// <summary>
        /// Gets the states from the database
        /// </summary>
        /// <exception cref="StateDAOException">Throws an exception if unable to rertrieve</exception>
        /// <returns>List of States from the database</returns>
        public List<State> GetStates()
        {
            List<State> states = null;
            IDbConnection conn = null;

            try
            {
                conn = this.GetConnection();
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "GetStates";
                cmd.CommandType = CommandType.StoredProcedure;

                using (IDataReader reader = cmd.ExecuteReader())
                {

                    states = new List<State>();
                    while (reader.Read())
                    {
                        State state = new State();

                        state.StateId = Convert.ToInt64(reader["StateId"]);
                        state.Name = reader["StateName"].ToString();

                        states.Add(state);
                    }

                }
            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new StateDAOException("Unable to get states", ex);
            }
            catch (Exception ex)
            {
                throw new StateDAOException("Unable to get states", ex);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return states;
        }
        #endregion

        #region Method to get the cities from the database
        /// <summary>
        /// Gets the cities from the database
        /// </summary>
        /// <exception cref="CityDAOException">Throws an exception if unable to rertrieve</exception>
        /// <returns>Returns a list of cities from the database</returns>
        public Model.Entities.Common.City[] GetCities()
        {
            List<City> cities = null;
            IDbConnection conn = null;
            try
            {
                conn = this.GetConnection();
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "GetCities";
                cmd.CommandType = CommandType.StoredProcedure;

                using (IDataReader reader = cmd.ExecuteReader())
                {

                    cities = new List<City>();
                    while (reader.Read())
                    {
                        City city = new City();
                        city.CityId = Convert.ToInt64(reader["CityId"]);
                        city.Name = reader["CityName"].ToString();

                        State state = new State();
                        state.StateId = Convert.ToInt64(reader["StateId"]);
                        state.Name = reader["StateName"].ToString();

                        city.StateInfo = state;

                        cities.Add(city);
                    }

                }
            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new CityDAOException("Unable to get cities", ex);
            }
            catch (Exception ex)
            {
                throw new CityDAOException("Unable to get cities", ex);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return cities.ToArray();
        }
        #endregion

        #region Method to add cities to the database
        /// <summary>
        /// Add cities to the database
        /// </summary>
        /// <parameter name="city"></parameter>
        /// <exception cref="CityDAOException">Thorws an exception when not able to add a city</exception>
        /// <returns>Returns the status of the add activity. True if successfully added</returns>
        public bool AddCity(City city)
        {
            bool flag = false;

            IDbConnection conn = null;
            try
            {
                conn = this.GetConnection();
                conn.Open();

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select isnull(count(*),0) as CityCount from cities where CityName = '" + city.Name + "'";
                cmd.CommandType = CommandType.Text;
                int cityCount = Convert.ToInt32(cmd.ExecuteScalar());

                if (cityCount == 0)
                {
                    string query = "INSERT INTO Cities (CityName, StateId) VALUES ('" + city.Name + "'," + city.StateInfo.StateId + ")";// StateId Must Be Sent
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    flag = true;
                }
                else
                    throw new CityDAOException("City Name Already Exists");

            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new CityDAOException("Unable to add city", ex);
            }
            catch (CityDAOException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new CityDAOException("Unable to add city", ex);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return flag;
        }
        #endregion

        #region Method to update the existing cities to the database
        /// <summary>
        /// Update the existing cities to the database
        /// </summary>
        /// <parameter name="city"></parameter>
        /// <exception cref="CityDAOException">Thorws an exception when not able to update a city</exception>
        /// <returns>Returns the status of update activity. True if it has been successfully updated</returns>
        public bool UpdateCity(City city)
        {
            bool flag = true;
            int cityId = 1;

            IDbConnection conn = null;
            string query = "UPDATE    dbo.[cities] SET   CityName ='" + city.Name + "' where CityId=" + city.CityId;

            try
            {
                conn = this.GetConnection();
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                
               int count=  cmd.ExecuteNonQuery();
               if (count == 0)
               {
                   flag = false;
               }
               else
               {
                   flag = true;
               }
        

            }
            catch (Common.ConnectToDatabaseException ex)
            {
                throw new CityDAOException("Unable to update the city", ex);
            }
            catch (Exception ex)
            {
                throw new CityDAOException("Unable to update the city", ex);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return flag;
        }
        #endregion

    }
}
