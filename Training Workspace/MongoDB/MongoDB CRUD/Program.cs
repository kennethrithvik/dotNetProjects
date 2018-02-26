using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoServer server = MongoServer.Create("Server=localhost:27017");
            MongoDatabase objDatabase = server.GetDatabase("ProductDB");
            Console.WriteLine("DB Connected......");

            //MongoCollection<BsonDocument> ProductDetails =objDatabase.GetCollection<BsonDocument>("Products");
            //Console.WriteLine("Collection created........");

            //Console.WriteLine("Enter product name");
            //String name = Console.ReadLine();
            //Console.WriteLine("Enter product cost");
            //int cost = Convert.ToInt32(Console.ReadLine());
            //BsonDocument objDocument = new BsonDocument
            //{
            //    {"Names",name},
            //    {"Cost",cost}

            //};
            //ProductDetails.Insert(objDocument);
            //Console.WriteLine("Record added");

            List<Product> result = objDatabase.GetCollection<Product>("Products").FindAll().ToList();
            Console.WriteLine(result.Count);
            foreach (var item in result)
            {
                Console.WriteLine(item.ToJson());
            }
            Console.ReadLine();
        }
       
    }
}
