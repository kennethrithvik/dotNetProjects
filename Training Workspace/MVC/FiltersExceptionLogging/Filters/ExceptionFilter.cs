using FiltersExceptionLogging.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersExceptionLogging.Filters
{
    public class ExceptionFilter:FilterAttribute,IExceptionFilter

    {
        public void OnException(ExceptionContext filterContext)
        {
            LogManager.ExceptionLog("Exception Occured", filterContext.Exception);
            
        }
    }
}