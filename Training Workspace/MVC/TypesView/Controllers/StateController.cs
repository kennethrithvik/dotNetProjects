using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllerDemo.Models;
using System.Web.Script.Serialization;

namespace TypesView.Controllers
{
    public class StateController : Controller
    {
        StateData statedata;
        CityData citydata;
        // GET: State
        public ActionResult Index()
        {
            ViewBag.state = CreateState();
          //  ViewBag.state = new SelectList(CreateState(), "StateID", "Name", "citylist");
            //ViewBag.city = new SelectList(CreateCity(2), "CityId", "Name", "StateID");
            return View();
        }

        public IList<State> CreateState()
        {
            statedata = new StateData();

            statedata.AddState(new State { StateID = 1, Name = "aaaaaaa" });
            statedata.AddState(new State { StateID = 2, Name = "bbbbbbb" });
            statedata.AddState(new State { StateID = 3, Name = "ccccccc" });
            statedata.AddState(new State { StateID = 4, Name = "ddddddd" });
            return statedata.GetList();
        }

        //public ActionResult GetCities(string id)
        //{
        //    citydata = new CityData();
        //    citydata.AddCity(new City { CityID = 1, Name = "1111111", StateID = 1 });
        //    citydata.AddCity(new City { CityID = 2, Name = "2222222", StateID = 1 });
        //    citydata.AddCity(new City { CityID = 3, Name = "33333333", StateID = 2 });
        //    citydata.AddCity(new City { CityID = 4, Name = "44444444", StateID = 2 });

        //    IList<City> citylist = new List<City>();
        //    foreach (var item in citydata.GetList())
        //    {
        //        if (item.StateID.ToString().Equals(id))
        //            citylist.Add(item);
        //    }
        //    var json = new JavaScriptSerializer().Serialize(citylist);
        //    return Json(json, JsonRequestBehavior.AllowGet);

        //}
    }
}