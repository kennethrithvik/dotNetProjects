using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyOrders
{
    class Item
    {
        public string ItemDescription { get; private set; }
        public double ItemCost { get;private set; }
     
        public Item(string desc,double cost)
        {
            ItemDescription = desc;
            ItemCost = cost;


        }
    }
}
