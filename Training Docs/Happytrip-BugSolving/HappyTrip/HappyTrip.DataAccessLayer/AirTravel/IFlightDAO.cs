using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTrip.DataAccessLayer.AirTravel
{
    /// <summary>
    /// Interface to the represent the flight operations to be performed on the database
    /// </summary>
    public interface IFlightDAO
    {
        /// <summary>
        /// Get the flight details from the database
        /// </summary>
        /// <exception cref="FlightDAOException">Thorws an exception when unable to get flights</exception>
        /// <returns>Returns the array of flights from the database</returns>
        Flight[] GetFlights();


        bool AddFlight(Flight _flight);
        bool UpdateFlight(Flight _flight);
        int UpdateFlightClass(Flight _flight,FlightClass _flightclass);
        Flight GetFlight(int flightid);
    }
}
