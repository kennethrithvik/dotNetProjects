using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipApp
{
    class Company
    {
        public string Name { get; set; }
        public List<Customer> Customers { get; set; }

        public Company(string name)
        {
            Name = name;
        }

        public void AddCustomer(Customer cus)
        {
            Customers.Add(cus);
        }
    }
}
