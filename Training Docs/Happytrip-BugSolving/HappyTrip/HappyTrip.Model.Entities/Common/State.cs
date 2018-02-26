using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.Entities.Common
{
    /// <summary>
    /// Class to represent states of a country
    /// </summary>
    public class State
    {
        #region Fields of the class

        private List<City> Cities = new List<City>();

        #endregion

        #region Properties of the class

        public long StateId {get;set;}
        public string Name {get;set; }

        #endregion


        #region Methods of the class

        /// <summary>
        /// Gets all the cites for a state
        /// </summary>
        /// <returns></returns>
        public List<City> GetCities()
        {
            return Cities;
        }

        /// <summary>
        /// Adds a schedule for a route
        /// </summary>
        /// <param name="NewCity"></param>
        public void AddCity(City NewCity)
        {
            Cities.Add(NewCity);
        }

        #endregion

    }
}
