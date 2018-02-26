using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipApp
{
    class Customer
    {
        public string CustId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Customer(string custId, string name, string email)
        {
            CustId = custId;
            Name = name;
            Email = email;
        }
    }
}
