using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HappyTrip.DataAccessLayer.Common;
using HappyTrip.Model.Entities.AirTravel;
using HappyTrip.Model.Entities.Common;

namespace HappyTrip.Model.BusinessLayer.AirTravel
{
    /// <summary>
    /// Class to manage the activities related to operation of flight in different cities
    /// </summary>
    public class CityManager
    {
        ///
        //Cities cities= null;
        /// 
        /// <summary>
        /// Fields of the class
        /// </summary>
        private ICityDAO cityDAO = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CityManager()
        {
            cityDAO = CityDAOFactory.GetInstance().CreateCity();
        }

        /// <summary>
        /// Parameterized Constructor to accept a data access object to work with
        /// </summary>
        /// <param name="cityDAO"></param>
        public CityManager(ICityDAO cityDAO)
        {
            this.cityDAO = cityDAO;
        }

        #region Method to get all the operation of flight in different cities
        /// <summary>
        /// Gets all the cities which is operational for flights
        /// </summary>
        /// <exception cref="CityManagerException">Thrown when unable get cities</exception>
        /// <returns>Returns List of cities</returns>
        public City[] GetCities()
        {
            try
            {
				City[] cities = cityDAO.GetCities();

 
                SortCities(cities);

				return cities;
            }
            catch(CityDAOException ex)
            {
                throw new CityManagerException("Unable to get cities", ex);
            }
        }
        #endregion

        #region Method to sort the list of cities
        /// <summary>
        /// Method to sort the list of cities
        /// </summary>
        /// <param name="cities">The unsorted city list</param>
        public void SortCities(City[] cities)
        {
            for (int i = 0; i < cities.Length - 1; ++i)
            {
                for (int j = 0; j < cities.Length - 2; ++j)
                {
                    if (cities[j].Name.CompareTo(cities[j + 1].Name) > 0)
                    {
                        City temp = cities[j];
                        cities[j] = cities[j + 1];
                        cities[j + 1] = temp;
                    }
                }
            }
        }
        #endregion

		#region Method to Add all cities
		/// <summary>
		/// Adds a city to the database
		/// </summary>
		/// <param name="city"></param>
		/// <exception cref="CityManagerException">Thrown when unable to add city</exception>
		/// <returns>Returns the status of insertion to be done</returns>
		public bool AddCity(City city)
        {
            bool isAdded = false;

            try 
            { 
                isAdded = cityDAO.AddCity(city);
            }
            catch (CityDAOException ex)
            {
                throw new CityManagerException("Unable to add the city", ex);
            }
            

            return isAdded;
        }
        #endregion

        #region Method to Update the existing the Cities
        /// <summary>
        /// Update the existing city information
        /// </summary>
        /// <param name="city"></param>
        /// <exception cref="CityManagerException">Thrown when unable to update city information</exception></exception>
        /// <returns>Returns the status of the update</returns>
        public bool UpdateCity(City city)
        {
            bool isUpdated = false;

            try
            {
                isUpdated = cityDAO.UpdateCity(city);
            }
            catch (CityDAOException ex)
            {
                throw new CityManagerException("Unable to update city information", ex);
            }
            

            return isUpdated;
        }
        #endregion

        #region Method to get all the states
        /// <summary>
        /// Gets all the states
        /// </summary>
        /// <exception cref="CityManagerException">Thrown when unable to get states</exception>
        /// <returns>Returns the list of states from database</returns>
        public List<State> GetStates()
        {
			try
			{
				return cityDAO.GetStates();
			}
			catch (CityDAOException ex)
			{
				throw new CityManagerException("Unable to get states", ex);
			}
        }
        #endregion

    }
}