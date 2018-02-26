using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cont = true;
            Employee emp = null;
            int ch;
            while (cont)
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to add");
                Console.WriteLine("Enter 2 to dispaly");

                Console.WriteLine("Enter 3 to exit");
                ch = Int16.Parse(Console.ReadLine());
                if (ch == 1)
                {
                    emp=new Employee();
                    Console.WriteLine("Enter name of Employee");
                    emp.Name = Console.ReadLine();
                    Console.WriteLine("Enter Gender of Employee");
                    emp.Gender = Console.ReadLine();
                    HRModule.AddEmployee(emp);

                }
                else if (ch == 2)
                {
                    foreach (var temp in HRModule.ListEmps)
                    {
                        Console.WriteLine(temp.Value.Display());
                    }
                    Console.ReadLine();
                }
 
                
                else

                    cont = false;
            }
            Console.WriteLine("Exited");
            Console.ReadLine();
        }
    }
}
