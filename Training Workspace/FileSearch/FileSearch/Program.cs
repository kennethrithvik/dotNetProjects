using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the file name");
            string fname = Console.ReadLine();
            Searcher sr=new Searcher();
            List<string> matches = sr.search(fname);
            Console.WriteLine(sr.display(matches));
            
            
            Console.ReadLine();
        }
    }
}
