using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyOrders
{
    class OrderedItem
    {
        public int Quantity { get;private set; }
       public Item _item{ get; set; }
      
        public OrderedItem(int qty)
        {
            Quantity = qty;
        }

        public double GetTotalCostPerItem()
        {
            return (_item.ItemCost) * (Quantity);

        }
       
    }
}
