using FiltersExceptionLogging.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authentication.Controllers
{
    [AuthenticationFilter]
    [AutherizationFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Kenneth's Application";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Kenneth";

            return View();
        }
    }
}