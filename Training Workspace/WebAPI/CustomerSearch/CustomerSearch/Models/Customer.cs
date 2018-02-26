using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerSearch.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String PhoneNo { get; set; }
    }
}