using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.Search For a File ");
            Console.WriteLine("2.List all Active Drives");
            Console.WriteLine("3.List all System Drives");
            Console.WriteLine("4.Exit");
            Console.WriteLine("Enter your choice :");
            int choice = GetChoiceFromUser();
            switch (choice)
            {
                case 1: SearchForAFile();
                    break;
                case 2: ListDrives(Roots.ACTIVE);
                    break;
                case 3: ListDrives(Roots.SYSTEM);
                    break;
                case 4: System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
            Console.ReadLine();
        }

        private static void ListDrives(Roots root)
        {
            RootFinderFactory factory = RootFinderFactory.GetInstance();
            IRootFinder finder=factory.Create(root);
            List<string> roots=finder.GetRoots();
            foreach (var rt in roots)
            {
                Console.WriteLine("Root Name :"+ rt);
            }

        }

      

        private static int GetChoiceFromUser()
        {
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
        static FileSearcher searcher = new FileSearcher();
        private static void SearchForAFile()
        {
            Console.WriteLine("Enter the Drive to be searched :");
            string drivetosearch = GetDriveToSearch();
            Console.WriteLine("Enter the file to be searched :");
            string filetosearch = GetFileToSearch();

            //Creating instance of FileSearcher

            searcher.Search(drivetosearch, filetosearch);
            DisplayResult();
        }

        private static string GetFileToSearch()
        {
            string filetosearch = Console.ReadLine();
            return filetosearch;
        }

        private static string GetDriveToSearch()
        {
            string drivetosearch = Console.ReadLine();
            return drivetosearch;
        }

        private static void DisplayResult()
        {
            List<string> results = searcher.GetFileFoundResults();
            foreach (var result in results)
            {
                Console.WriteLine("File Found in :" + result);
            }
        }


    }
}
