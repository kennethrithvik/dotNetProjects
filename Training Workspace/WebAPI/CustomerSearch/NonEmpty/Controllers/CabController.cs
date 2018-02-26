using NonEmpty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace NonEmpty.Controllers
{
    public class CabController : ApiController
    {
        // GET: api/Cab
        CabData ad = new CabData();
        public IEnumerable<Cab> Get()
        {
            return ad.GetAll();
        }

        // GET: api/Cab/5
        public IList<Cab> Get(string cab)
        {
            Cab data = new JavaScriptSerializer().Deserialize<Cab>(cab);
            IList<Cab> clist=new CabData().GetAll();
            clist.Add(data);

            return clist;
            //var json = new JavaScriptSerializer().Serialize(clist);
            //JsonResult a=Json(json, JsonRequestBehavior.AllowGet);
            //return json;
            
        }

        // POST: api/Cab
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cab/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cab/5
        public void Delete(int id)
        {
        }
    }
}
