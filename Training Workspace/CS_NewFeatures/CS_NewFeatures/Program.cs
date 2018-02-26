using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_NewFeatures
{
    internal delegate long MathDel(int n1, int n2);
    class Product
    {
        private int intPid;

        public int ProductID
        {
            get { return intPid; }
            set { intPid = value; }
        }

        //1 Implicit properties
        public string Name { get; set; }

        public DateTime MfgDate { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //2 Object and collection initialization
            Product pr = new Product {MfgDate = new DateTime(2015, 10, 4),Name = "kenneth",ProductID = 1};
            List<Product> prods = new List<Product>
            {
                pr,
                new Product {MfgDate = new DateTime(2015, 10, 4),Name = "kenneth1",ProductID = 2},
                new Product {MfgDate = new DateTime(2015, 10, 4),Name = "kenneth2",ProductID = 3},
                new Product {MfgDate = new DateTime(2015, 10, 4),Name = "kenneth3",ProductID = 4}
            };


            //3 Implicitly typed local variables
            var i = 10;
            var str = "hello";
            var fl = 5645.67576;


            //4 Anonymous Data Types
            var student = new {StudentID = 10, Name = "student1", DOB = new DateTime(2015, 10, 10)};


            
            //5 Delegates -->> Anonymous methods (2.0) -->> lamda
            //5a Anonymous method--> Inline function
            MathDel del = delegate(int n1, int n2)
            {
                return n1 + n2;
            };


            Action<Product> prdaction = delegate(Product p)
            {
                Console.WriteLine(p.Name);
            };
            prods.ForEach(prdaction);

            prods.ForEach(delegate(Product p)
            {
                Console.WriteLine(p.Name);
            });


            //5b lamda
            MathDel del2 = (n1, n2) =>
            {
                return n1 + n2;
            };


            prods.ForEach((p)=>
            {
                Console.WriteLine(p.Name);
            });


            MathDel del3 = (n1, n2) => n1 + n2;

            prods.ForEach(  (p)=>Console.WriteLine(p.Name)  );

            //6a Utility/Extension Methods
            string msg = "Tesco";
            Console.WriteLine(msg.Welcome());


            //7 Dynamic Data Type
            dynamic pr1=new Product{MfgDate = new DateTime(2015, 10, 4),Name = "kenneth4",ProductID = 5};
            //pr1.Display();   //Display() method does not exist--> error oly at runtime


            //8 Func delegate
            Func<int, int, long> funcmul = (n1, n2) => n1*n2;
            Console.WriteLine(funcmul.Invoke(22,33));






            Console.ReadLine();
        }

    }


    //6b Utility/Extension Methods
    public static class MyUtility
    {
        public static string Welcome(this string msg)
        {
            return "Welcome " + msg;
        }
    }


}
