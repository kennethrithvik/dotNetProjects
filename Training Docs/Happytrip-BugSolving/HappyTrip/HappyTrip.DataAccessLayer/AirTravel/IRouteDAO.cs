using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyTrip.Model.Entities.AirTravel;
using System.Data;

namespace HappyTrip.DataAccessLayer.AirTravel
{
    /// <summary>
    /// Interface to the represent the route operations to be performed on the database
    /// </summary>
    public interface IRouteDAO
    {
        Route[] GetRoutes();
        int AddRoute(Route RouteInfo);
        bool UpdateRoute(Route RouteInfo);
        int GetRouteID(Route RouteInfo);
    }
}
