using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace assign3
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Contact> SDcont = new SortedDictionary<string,Contact>();
            int ch;
            bool cont = true;
            Contact tconc = null;
            while (cont)
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to add");
                Console.WriteLine("Enter 2 to Edit Contact");
                Console.WriteLine("Enter 3 to Display names sorted on first or last name");
                Console.WriteLine("Enter 4 to remove Contact");
                Console.WriteLine("Enter 5 to Search contact");
                Console.WriteLine("Enter 6 to exit");
                ch = Int16.Parse(Console.ReadLine());
                if (ch == 1)
                {

                        tconc = new Contact();
                        Console.WriteLine("Enter First name");
                        tconc.FirstName= Console.ReadLine();
                        Console.WriteLine("Enter Last name");
                        tconc.LastName = Console.ReadLine();
                        Console.WriteLine("Enter Mobile no.");
                        tconc.Mobile = Console.ReadLine();

                        if (SDcont.ContainsKey(tconc.Mobile))
                        {
                            Console.WriteLine("Mobile no. already exists");
                            continue;
                        }

                        Console.WriteLine("Enter Email ID");
                        tconc.Email = Console.ReadLine();

                        SDcont.Add(tconc.Mobile,tconc);
                        

                }
                else if (ch == 2)
                {
                    Console.WriteLine("Enter Mobile no. to Edit");
                    string tmob;
                    if (!SDcont.ContainsKey(tmob=Console.ReadLine()))
                        Console.WriteLine("Contact not found");
                    else
                    {
                        Contact Econt=SDcont[tmob];
                        Console.WriteLine("Enter new First name");
                        Econt.FirstName = Console.ReadLine();
                        Console.WriteLine("Enter new Last name");
                        Econt.LastName = Console.ReadLine();
                        Console.WriteLine("Enter new Email ID");
                        Econt.Email = Console.ReadLine();


                    }
                    Console.ReadLine();

                }
                else if (ch == 3)
                {
                    Console.WriteLine("Enter 1 to display sorted by First name or 2 to sort by last name");
                    ch = Int16.Parse(Console.ReadLine());

                    if (ch == 1)
                    {
                        foreach (var sdict in SDcont)
                        {
                            Console.WriteLine(sdict.Value.Display());
                        }
                    }

                    else
                    {
                        foreach (var sdict in SDcont)
                        {
                            Console.WriteLine(sdict.Value.Display());
                        }
                    }
                    
                    Console.ReadLine();
                }
                else if (ch == 4)
                {
                    Console.WriteLine("Enter Mobile no. to delete");
                    string tmob;
                    if (!SDcont.ContainsKey(tmob=Console.ReadLine()))
                        Console.WriteLine("Contact not found");
                    else
                    {
                        Console.WriteLine("Deleted \n"+SDcont[tmob].Display());
                        SDcont.Remove(tmob);
                    }
                    Console.ReadLine();
                }
                else if (ch == 5)
                {
                    Console.WriteLine("Enter Mobile no. to Search");
                    string tmob;
                    if (!SDcont.ContainsKey(tmob = Console.ReadLine()))
                        Console.WriteLine("Contact not found");
                    else
                    {
                        Console.WriteLine("Found \n" + SDcont[tmob].Display());
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
