using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace assign1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Product[] prod = new Product[100];
            ArrayList al = new ArrayList();
            int ch;
            bool cont = true;
            Product prod = null;
            while (cont)
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to add");
                Console.WriteLine("Enter 2 to dispaly");
                Console.WriteLine("Enter 3 to exit");
                ch = Int16.Parse(Console.ReadLine());
                if (ch == 1)
                {
                    
                    Console.WriteLine("Enter 1 to add TV");
                    Console.WriteLine("Enter 2 to add Mobile");
                    ch = Int16.Parse(Console.ReadLine());
                    if (ch == 1)
                    {
                        TV tv = new TV();
                        Console.WriteLine("Enter true if tv is 3D");
                        tv.Is3D = bool.Parse(Console.ReadLine());
                        prod = tv;
                    }
                    else if (ch == 2)
                    {
                        Mobile mob = new Mobile();
                        Console.WriteLine("Enter true if mobile is 4G");
                        mob.Is4G = bool.Parse(Console.ReadLine());
                        prod = mob;
                    }
                    

                        Console.WriteLine("Enter name of Product");
                        prod.Name = Console.ReadLine();
                        Console.WriteLine("Enter Product ID");
                        prod.ProductID = Int16.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Manufacturing Date of Product");
                        prod.MfgDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the quantity of Product");
                        prod.Quant = Int16.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Base price of Product");
                        double bp = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter VAT of Product");
                        double vat = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Discount of Product");
                        double dis = Double.Parse(Console.ReadLine());
                        MRP mrp1 = new MRP(bp, vat, dis);
                        prod.mrp = mrp1;


                        al.Add(prod);


                }
                else if (ch == 2)
                {
                    foreach(Product tempProd in al)
                    {
                        Console.WriteLine(tempProd.Display());
                    }
                    Console.ReadLine();
                }
                else
                    
                    cont=false;
            }
            Console.WriteLine("Exited");
            Console.ReadLine();
        }
    }
}
