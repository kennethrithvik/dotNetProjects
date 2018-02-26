using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Markup;

namespace ProductInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] prod = new Product[100];
            int top = 0;
            bool cont = true;
            ConsoleColor BackgroundColor = ConsoleColor.Blue;
            while (cont)
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to add");
                Console.WriteLine("Enter 2 to dispaly");
                Console.WriteLine("Enter 3 to exit");
                int ch = Int16.Parse(Console.ReadLine());
                if (ch == 1)
                {
                    prod[top] = new Product();

                    Console.WriteLine("Enter name of Product");
                    prod[top].Name = Console.ReadLine();
                    Console.WriteLine("Enter Product ID");
                    prod[top].ProductID = Int16.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Manufacturing Date of Product");
                    prod[top].MfgDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the quantity of Product");
                    prod[top].Quant = Int16.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Base price of Product");
                    double bp = Double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter VAT of Product");
                    double vat = Double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Discount of Product");
                    double dis = Double.Parse(Console.ReadLine());
                    MRP mrp1 = new MRP(bp, vat, dis);
                    prod[top].mrp = mrp1;
                    top++;

                }
                else if (ch == 2)
                {
                    for (int i = 0; i < top; i++)
                    {
                        Product tempProd = prod[i];
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
