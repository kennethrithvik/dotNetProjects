using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EntityLayer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Product> Dprod = new Dictionary<int,Product>();
            int ch;
            bool cont = true;
            Product prod = null;
            while (cont)
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to add");
                Console.WriteLine("Enter 2 to dispaly all");
                Console.WriteLine("Enter 3 to dispaly on ID");
                Console.WriteLine("Enter 4 to remove ID");
                Console.WriteLine("Enter 5 to exit");
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

                        if (Dprod.ContainsKey(prod.ProductID))
                        {
                            Console.WriteLine("Duplictae key");
                            continue;
                        }

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


                        Dprod.Add(prod.ProductID,prod);


                }
                else if (ch == 2)
                {
                    foreach(KeyValuePair<int,Product> tempProd in Dprod)
                    {
                        Console.WriteLine(tempProd.Value.Display());
                    }
                    Console.ReadLine();
                }
                else if (ch == 3)
                {
                    int temp;
                    Console.WriteLine("Enter key");
                    if (!Dprod.ContainsKey(temp=Int16.Parse(Console.ReadLine())))
                        Console.WriteLine("Key not found");
                    else
                        Console.WriteLine(Dprod[temp].Display());
                    Console.ReadLine();
                }
                else if (ch == 4)
                {
                    int temp;
                    Console.WriteLine("Enter key");
                    if (!Dprod.ContainsKey(temp=Int16.Parse(Console.ReadLine())))
                        Console.WriteLine("Key not found");
                    else
                    {
                        Console.WriteLine("Deleted \n"+Dprod[temp].Display());
                        Dprod.Remove(temp);
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
