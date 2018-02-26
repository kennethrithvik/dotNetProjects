using FiltersExceptionLogging.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersExceptionLogging.Filters
{
    public class LogFilter:FilterAttribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            LogManager.Log("On ActionExecuted", filterContext.RouteData);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogManager.Log("On ActionExecuting", filterContext.RouteData);
        }
    }
}