using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyTrip.Model.BusinessLayer.AirTravel
{
    /// <summary>
    /// Class to represent an exception to be handled when route is not availabe for given route information
    /// </summary>
    public class RouteNotAvailableException : Exception
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RouteNotAvailableException()
        {

        }

        /// <summary>
        /// Paramterized Constructor - To accept a message
        /// </summary>
        /// <param name="message"></param>
        public RouteNotAvailableException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Paramterized Constructor - To accept message and inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public RouteNotAvailableException(string message, Exception ex)
            : base(message, ex)
        {
            
        }
    }
}
