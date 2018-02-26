using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            //create company
            Company company = new Company();
            company.CompanyName = "UTC";


            //create customer 
            Customer customer1 = new Customer();
            customer1.CustomerID = 1;
            customer1.CustomerName = "kumuda bg";

            //create customer 
            RegisteredCustomer customer2 = new RegisteredCustomer(10.0);
            customer2.CustomerID = 1;
            customer2.CustomerName = "kumuda";

            //add customer to company
            company._customer = new List<Customer>();
            company._customer.Add(customer2);
            company._customer.Add(customer1);
            //create order
            Order order1 = new Order();
            order1.OrderId = 1;

            Order order2 = new Order();
            order2.OrderId = 1;
            
            //add customer to order
            order1._customer = customer1;
            order2._customer = customer2;


            //add order to customer
            customer2._order = new List<Order>();
            customer2._order.Add(order1);

            customer1._order = new List<Order>();
            customer1._order.Add(order1);
            // create orderitem
            OrderedItem ordereditem = new OrderedItem(3);

            //add ordereditem to order
            order1._ordereditem = new List<OrderedItem>();

            order1._ordereditem.Add(ordereditem);

            order2._ordereditem = new List<OrderedItem>();

            order2._ordereditem.Add(ordereditem);

            //create item
            Item item = new Item("Slice", 100);

            //add item to ordereditem
            ordereditem._item = new Item(item.ItemDescription,item.ItemCost);
            ordereditem._item = item;

            //add item to company
            company._item = new List<Item>();
            company._item.Add(item);

            Console.WriteLine(  "WorthOfOrders="+ company.GetTotalWorthOfOrders());
            Console.Read();

         
        }
    }
}
