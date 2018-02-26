using FiltersExceptionLogging.Filters;
using FiltersExceptionLogging.Logger;
using FiltersExceptionLogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersExceptionLogging.Controllers
{
    [LogFilter]
    [ExceptionFilter]
    [AuthenticationFilter]
    [AutherizationFilter]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                Product pr = null;
                pr.Name = "rgrg";
            }
            catch(Exception ex)
            {
                LogManager.ExceptionLog(ex.Message,ex);
            }
            return View();
        }
    }
}