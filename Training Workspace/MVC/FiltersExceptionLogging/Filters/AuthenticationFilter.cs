using FiltersExceptionLogging.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace FiltersExceptionLogging.Filters
{
    public class AuthenticationFilter:FilterAttribute,IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (!filterContext.Principal.Identity.IsAuthenticated)
                filterContext.Result = new HttpUnauthorizedResult();
            LogManager.AuthenticationLog("On Authentication", filterContext.ToString());
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            LogManager.AuthenticationLog("On AuthenticationChallenge", filterContext.Result.ToString());
        }
    }
}