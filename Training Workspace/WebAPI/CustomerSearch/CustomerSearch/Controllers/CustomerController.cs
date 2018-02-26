using CustomerSearch.Models;
using CustomerSearch.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;


namespace CustomerSearch.Controllers
{
    public class CustomerController : ApiController
    {
        ICustomerRepository cusrepo;
        //public CustomerController()
        //{
        //    cusrepo = new CustomerRepository();
        //}
        public CustomerController(ICustomerRepository cr)
        {
            cusrepo = cr;
        }
        // GET: api/Customer
        public IList<Customer> Get()
        {
            IList<Customer> a= cusrepo.GetCustomers();
            //string json = new JavaScriptSerializer().Serialize(a);
            
            //var b = Json<string>(json);
            //return json;
            return a;
        }

        // GET: api/Customer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
