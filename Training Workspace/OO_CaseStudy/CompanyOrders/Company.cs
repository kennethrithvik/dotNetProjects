using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyOrders
{
    class Company
    {
        public string CompanyName { get; set; }
     public   List<Item> _item { get; set; }
       public List<Customer> _customer { get; set; }
        public double GetTotalWorthOfOrders()
       {
           Console.WriteLine(_customer.Count);
          
            double sum = 0.0;
           double TotalOrdersCost = 0.0;
            double TotalWorth = 0.0;
          
            foreach (Customer customer in _customer)
            {
                TotalOrdersCost = 0.0;
                sum = 0.0;
                foreach (Order item in customer._order)
                {
                    //Console.WriteLine(customer.CustomerName);
                   TotalOrdersCost += item.GetTotalOrders();
                }
                if (customer is RegisteredCustomer)
                {
                    Console.WriteLine(customer.CustomerName);
                    RegisteredCustomer regcustomer = (RegisteredCustomer)customer;
                    sum = TotalOrdersCost * (regcustomer.GetSplDiscount()) / 100;
                    TotalOrdersCost -= sum;
                }

                TotalWorth += TotalOrdersCost;
            }
            return TotalWorth;
        }
    }
}
