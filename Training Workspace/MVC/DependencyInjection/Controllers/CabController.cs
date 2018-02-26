using DependencyInjection.Models;
using DependencyInjection.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DependencyInjection.Controllers
{
    public class CabController : Controller
    {
        ICabRepository cabrepo;
        public CabController(ICabRepository repo)
        {
            cabrepo = repo;
        }
        // GET: Cab
        public ActionResult Index()
        {
            var a = cabrepo.GetAll();
            ViewBag.Cab = a;
            return View();
        }
        public ActionResult PutCab( string cab)
        {
            Cab data = new JavaScriptSerializer().Deserialize<Cab>(cab);
            cabrepo.AddCag(data);
            var a = cabrepo.GetAll();
            ViewBag.Cab = a;
            return View(a);
        }
    }
}