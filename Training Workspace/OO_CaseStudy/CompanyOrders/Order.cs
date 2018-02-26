using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyOrders
{
    class Order
    {
        public int OrderId { get; set; }
       //doubt
     public  Customer _customer { get; set; }
     public   List<OrderedItem> _ordereditem { get; set; }
        public double GetTotalOrders()
        {
            double TotalOrders=0.0;

            foreach (OrderedItem item in _ordereditem)
            {
                TotalOrders += item.GetTotalCostPerItem();
            }
            return TotalOrders;
        }
    }
}
