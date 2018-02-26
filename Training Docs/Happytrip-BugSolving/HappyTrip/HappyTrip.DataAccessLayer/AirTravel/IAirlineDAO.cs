using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTrip.DataAccessLayer.AirTravel
{
    /// <summary>
    /// Interface to the represent the airline operations to be performed on the database
    /// </summary>
    public interface IAirlineDAO
    {
        /// <summary>
        /// Gets the airlines from the database
        /// </summary>
        /// <exception cref="AirlineDAOException">Throws an exception if unable to get airlines</exception>
        /// <returns>Returns the array of airlines from the database</returns>
        Airline[] GetAirlines();
    }
}
