using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IO
{
    class Program
    {
        static void Main(string[] args)
        {
            //tdrives();
            ReadTextFileByte();



            Console.ReadLine();
        }

        static void ReadTextFileByte()
        {
            string path = @"D:\test.txt";
            FileStream fs =new FileStream(path,FileMode.Open,FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string mystring = sr.ReadToEnd();
            

            //byte[] by = new byte[fs.Length];
            //fs.Read(by, 0, by.Length);
            //string filestring = System.Text.Encoding.UTF8.GetString(by);
            Console.WriteLine(mystring);
        }

        static void Getdrives()
        {
            DriveInfo[] drvs = DriveInfo.GetDrives();
            foreach (var item in drvs)
            {
                if (item.IsReady)
                {
                    Console.WriteLine(item.DriveType);
                    Console.WriteLine(item.DriveFormat);
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.TotalSize);
                    Console.WriteLine(item.VolumeLabel);
                    Console.WriteLine(item.AvailableFreeSpace);
                }

              


            } 
        }
    }
}
