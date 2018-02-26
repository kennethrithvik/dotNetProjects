using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.DataContext;
using CodeFirst.Initialiser;
using CodeFirst.Entities;


namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer<BookStoreContext>(new BookStoreInitialiser());
            BookStoreContext bkc=new BookStoreContext();
            bkc.Database.Connection.ConnectionString =
                @"integrated security=true;database=BookStore;data source=NEXWAVE-PC;";
            foreach (var item in bkc.Books)
            {
                Console.WriteLine(item.Name);
            }


            Console.ReadLine();
        }
    }
}
