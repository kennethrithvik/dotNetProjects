using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace assign2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Product> Dprod = new Dictionary<int,Product>();
            int ch;
            bool cont = true;
            Product prod = null;
            string path = @"D:\inventory.txt", lin, path1 = @"D:\inventoryb.txt";



            //FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //StreamReader sr = new StreamReader(fs);
            //while ((lin = sr.ReadLine()) != null)
            //{
            //    string[] data = lin.Split(',');
            //    if (data[5] == "TV")
            //    {
            //        TV tv = new TV();
            //        tv.Is3D = bool.Parse(data[4]);
            //        prod = tv;
            //        prod.type = data[5];
            //    }
            //    else if (data[5] == "mobile")
            //    {
            //        Mobile mob = new Mobile();
            //        mob.Is4G = bool.Parse(data[4]);
            //        prod = mob;
            //        prod.type = data[5];
            //    }
            //    prod.Name = data[1];
            //    prod.ProductID = Int16.Parse(data[0]);
            //    prod.MfgDate = DateTime.Parse(data[2]);
            //    prod.Quant = Int16.Parse(data[3]);



            //    Dprod.Add(prod.ProductID, prod);

            //}
            //fs.Close(); sr.Close(); fs.Dispose(); sr.Dispose();




            FileStream fsb = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fsb);
            int count = br.ReadInt32();
            string typ;
            for (int i = 0; i < count; i++)
            {
                if ((typ=br.ReadString())=="TV")
                {
                    TV tv = new TV();
                    //tv.Is3D = bool.Parse(data[4]);
                    prod = tv;
                    prod.type = typ;
                }
                else if (typ == "mobile")
                {
                    Mobile mob = new Mobile();
                    //mob.Is4G = bool.Parse(data[4]);
                    prod = mob;
                    prod.type = typ;
                }
                prod.Name = br.ReadString();
                prod.ProductID = br.ReadInt32();
                prod.MfgDate = new DateTime(br.ReadInt64());
                prod.Quant = br.ReadInt32();



                Dprod.Add(prod.ProductID, prod);

            }
            fsb.Close(); br.Close(); fsb.Dispose(); br.Dispose();




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
                        prod.type = "TV";
                    }
                    else if (ch == 2)
                    {
                        Mobile mob = new Mobile();
                        Console.WriteLine("Enter true if mobile is 4G");
                        mob.Is4G = bool.Parse(Console.ReadLine());
                        prod = mob;
                        prod.type = "mobile";
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

            //TextReader file writer
            FileStream fs1 = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw=new StreamWriter(fs1);
            foreach (var tempProd in Dprod)
            {
                sw.WriteLine(tempProd.Value.FileString());
            }
            sw.Flush(); sw.Close(); sw.Dispose();
            fs1.Close();  fs1.Dispose();


            //binary file writer
            FileStream fs2 = new FileStream(path1, FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs2);
            bw.Write(Dprod.Count);
            foreach (var tempProd in Dprod)
            {
                bw.Write(tempProd.Value.type);
                bw.Write(tempProd.Value.Name);
                bw.Write(tempProd.Value.ProductID);
                bw.Write(tempProd.Value.MfgDate.Ticks);
                bw.Write(tempProd.Value.Quant);
            }
            bw.Flush(); bw.Close(); bw.Dispose();
            fs2.Close(); fs2.Dispose();


            Console.WriteLine("Exited");
            Console.ReadLine();
        }
    }
}
