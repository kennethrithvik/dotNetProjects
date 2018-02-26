using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.DataAccessLayer.AirTravel
{
    /// <summary>
    /// Class to represent an exception while trying to add or update schedule without a route
    /// </summary>
    public class RouteNotAvailableForScheduleDAOException : Exception
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RouteNotAvailableForScheduleDAOException()
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message
        /// </summary>
        /// <param name="message"></param>
        public RouteNotAvailableForScheduleDAOException(string message) : base(message)
        {

        }

        /// <summary>
        /// Parameterized Constructor - Which takes a message and then inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public RouteNotAvailableForScheduleDAOException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
