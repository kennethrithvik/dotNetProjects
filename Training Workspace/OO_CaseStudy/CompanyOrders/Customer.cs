using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyOrders
{
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
      public  List<Order> _order { get; set; }

      
     
    
    }

    class RegisteredCustomer : Customer
    {
        public double SplDiscount { get; private set; }
        public RegisteredCustomer(double dis)
        {
            SplDiscount = dis;
        }
        public  double GetSplDiscount()
        {
            return SplDiscount;
        }
    }
}
