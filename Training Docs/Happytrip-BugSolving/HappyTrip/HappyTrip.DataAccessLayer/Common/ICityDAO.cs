using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.Common;

namespace HappyTrip.DataAccessLayer.Common
{
    /// <summary>
    /// Interface to the represent the city operations to be performed on the database
    /// </summary>
    public interface ICityDAO
    {
        /// <summary>
        /// Gets the cities from the database
        /// </summary>
        /// <exception cref="CityDAOException">Throws an exception if unable to rertrieve</exception>
        /// <returns>Returns an array of cities from the database</returns>
        City[] GetCities();

        /// <summary>
        /// Add cities to the database
        /// </summary>
        /// <parameter name="city"></parameter>
        /// <exception cref="CityDAOException">Thorws an exception when not able to add a city</exception>
        /// <returns>Returns the status of the add activity. True if successfully added</returns>
        bool AddCity(City city);

        /// <summary>
        /// Update the existing cities to the database
        /// </summary>
        /// <parameter name="city"></parameter>
        /// <exception cref="CityDAOException">Thorws an exception when not able to update a city</exception>
        /// <returns>Returns the status of update activity. True if it has been successfully updated</returns>
        bool UpdateCity(City city);

        /// <summary>
        /// Gets the states from the database
        /// </summary>
        /// <exception cref="StateDAOException">Throws an exception if unable to rertrieve</exception>
        /// <returns>List of States from the database</returns>
        List<State> GetStates();
    }
}
