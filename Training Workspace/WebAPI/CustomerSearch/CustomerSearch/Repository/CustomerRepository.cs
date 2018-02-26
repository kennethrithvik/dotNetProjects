using CustomerSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerSearch.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        public IList<Models.Customer> GetCustomers()
        {
            IList<Customer> listcus = new List<Customer>();
            listcus.Add(new Customer { CustomerID = 1, Name = "Kenneth1", Address = "aaaaaaaaa", PhoneNo = "11111111" });
            listcus.Add(new Customer { CustomerID = 2, Name = "Kenneth2", Address = "bbbbbbbbb", PhoneNo = "22222222" });
            listcus.Add(new Customer { CustomerID = 3, Name = "Kenneth3", Address = "ccccccccc", PhoneNo = "33333333" });
            listcus.Add(new Customer { CustomerID = 4, Name = "Kenneth4", Address = "ddddddddd", PhoneNo = "44444444" });
            listcus.Add(new Customer { CustomerID = 5, Name = "Kenneth5", Address = "eeeeeeeee", PhoneNo = "55555555" });
            listcus.Add(new Customer { CustomerID = 6, Name = "Kenneth6", Address = "fffffffff", PhoneNo = "66666666" });

            return listcus;
        }
    }
}