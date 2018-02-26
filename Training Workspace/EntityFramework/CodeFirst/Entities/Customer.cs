using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    class Customer
    {
        public int CustomerID{ get; set; }
        public string Name{ get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
