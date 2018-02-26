using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.DataAccessLayer.AirTravel;
using HappyTrip.Model.Entities.AirTravel;

namespace HappyTrip.Model.BusinessLayer.AirTravel
{
    public class Routes
    {
        /// <summary>
        /// Fields of the class
        /// </summary>
        private IRouteDAO routeDAO = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Routes()
        {
            routeDAO = AirTravelDAOFactory.GetInstance().CreateRouteDAO();
        }

        /// <summary>
        /// Parameterized Constructor to accept a data access object to work with
        /// </summary>
        /// <param name="routeDAO"></param>
        public Routes(IRouteDAO routeDAO)
        {
            this.routeDAO = routeDAO;
        }

        #region Method to get all the flight routes
        /// <summary>
        /// Gets the flight routes
        /// </summary>
        /// <exception cref="RouteManagerException">Thrown when unable to get routes</exception>
        /// <returns>Returns a collection with all the route information</returns>
        public List<Route> GetRoutes()
        {
            List<Route> routes1 = null;

			try
			{
                routes1 = routeDAO.GetRoutes().ToList();
                
                routes1.Sort();

                return routes1;
			}
			catch (RouteDAOException ex)
			{
				throw new RouteManagerException("Unable to get routes", ex);
			}
        }
        #endregion
    }
}
