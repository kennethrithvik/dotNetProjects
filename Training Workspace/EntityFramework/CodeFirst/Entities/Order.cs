﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    class Order
    {
        public int OrderID{ get; set; }
        public DateTime OrderDate{ get; set; }
        public int CustomerID{ get; set; }
        public Customer Customer{ get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
