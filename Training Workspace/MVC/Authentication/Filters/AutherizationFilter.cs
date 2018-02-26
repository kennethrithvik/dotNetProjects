using FiltersExceptionLogging.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersExceptionLogging.Filters
{
    public class AutherizationFilter:FilterAttribute,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            LogManager.AutherizationLog("On Autherization", filterContext.RouteData);
        }
    }
}