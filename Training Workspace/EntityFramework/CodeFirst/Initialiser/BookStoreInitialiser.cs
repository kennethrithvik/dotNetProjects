using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.DataContext;
using CodeFirst.Entities;

namespace CodeFirst.Initialiser
{
    class BookStoreInitialiser:DropCreateDatabaseIfModelChanges<BookStoreContext>
    {
        protected override void Seed(BookStoreContext context)
        {
            var lstAuthors = new List<Author> {
                new Author { Name="Adam freeman"},
                new Author { Name="Peter carter"},
                new Author { Name="Joseph rattz"},
                new Author { Name="Scott klein"},
                new Author { Name="Rick kiessig"},
                new Author { Name="Micheal frampton"},
                new Author { Name="Buddy james"}
            };
            //   base.Seed(context);
            lstAuthors.ForEach(au => context.Authors.Add(au));
            context.SaveChanges();

            var lstBooks = new List<Book> {
                new Book {Name="Asp.net MVC 5", AuthorID=1, Price=500, PublishDate= new DateTime(2015,2,17) },
                new Book { Name="Sql server administration", AuthorID=2, Price=600, PublishDate= new DateTime(2015,10,01) },
                new Book {Name="Pro Linq", AuthorID=3, Price=500, PublishDate= new DateTime(2009,8,01) },
                new Book {Name="Pro Entityframework 4", AuthorID=4, Price=600, PublishDate= new DateTime(2010,3,10) },
                new Book {Name="Asp.net 4.5", AuthorID=5, Price=700, PublishDate= new DateTime(2012,7,24) },
                new Book {Name="Big data made easy", AuthorID=6, Price=700, PublishDate= new DateTime(2014,12,30) },
                new Book { Name="Pro XAML with C#", AuthorID=7, Price=800, PublishDate= new DateTime(2015,7,07) },
                new Book {Name="HTML 5 and CSS3", AuthorID=2, Price=800, PublishDate= new DateTime(2015,7,07) },
                new Book {Name="WCF 4", AuthorID=4, Price=800, PublishDate= new DateTime(2015,7,07) },
                new Book {Name="Angular", AuthorID=2, Price=800, PublishDate= new DateTime(2015,7,07) }
            };

            lstBooks.ForEach(bk => context.Books.Add(bk));
            context.SaveChanges();

            var lstCust = new List<Customer>{
                new Customer {  Name="Customer1"},
                new Customer { Name="Customer2"},
                new Customer { Name="Customer3"},
                new Customer { Name="Customer4"},
                new Customer { Name="Customer5"}
            };

            lstCust.ForEach(cu => context.Customers.Add(cu));
            context.SaveChanges();

            var lstOrd = new List<Order>
            {
                new Order {  OrderDate=new DateTime(2015,10,28), CustomerID=1},
                new Order { OrderDate=new DateTime(2015,10,28), CustomerID=2},
                new Order { OrderDate=new DateTime(2015,10,28), CustomerID=3},
                new Order { OrderDate=new DateTime(2015,10,28), CustomerID=4}
            };

            lstOrd.ForEach(or => context.Orders.Add(or));
            context.SaveChanges();

            var lstOd = new List<OrderItem>
            {
                 new OrderItem{ OrderID=lstOrd.SingleOrDefault(o => o.CustomerID==1).OrderID,
                 BookID= lstBooks.SingleOrDefault(b=>b.Name=="Asp.net MVC 5").BookID, Quantity=10},
                 new OrderItem{ OrderID=lstOrd.SingleOrDefault(o => o.CustomerID==1).OrderID,
                 BookID= lstBooks.SingleOrDefault(b=>b.Name=="Sql server administration").BookID, Quantity=10},
                 new OrderItem{ OrderID=lstOrd.SingleOrDefault(o => o.CustomerID==1).OrderID,
                 BookID= lstBooks.SingleOrDefault(b=>b.Name=="Asp.net 4.5").BookID, Quantity=10},
                 new OrderItem{ OrderID=lstOrd.SingleOrDefault(o => o.CustomerID==2).OrderID,
                 BookID= lstBooks.SingleOrDefault(b=>b.Name=="Asp.net MVC 5").BookID, Quantity=10},
                 new OrderItem{ OrderID=lstOrd.SingleOrDefault(o => o.CustomerID==2).OrderID,
                 BookID= lstBooks.SingleOrDefault(b=>b.Name=="Angular").BookID, Quantity=10},
                 new OrderItem{ OrderID=lstOrd.SingleOrDefault(o => o.CustomerID==3).OrderID,
                 BookID= lstBooks.SingleOrDefault(b=>b.Name=="Pro XAML with C#").BookID, Quantity=10},

                 new OrderItem{ OrderID=lstOrd.SingleOrDefault(o => o.CustomerID==3).OrderID,
                 BookID= lstBooks.SingleOrDefault(b=>b.Name=="HTML 5 and CSS3").BookID, Quantity=10},
                 new OrderItem{ OrderID=lstOrd.SingleOrDefault(o => o.CustomerID==3).OrderID,
                 BookID= lstBooks.SingleOrDefault(b=>b.Name=="WCF 4").BookID, Quantity=10}                 
            };
            lstOd.ForEach(od => context.OrderItems.Add(od));
            context.SaveChanges();
        }        
    }
}
