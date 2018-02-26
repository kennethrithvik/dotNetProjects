using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeClass emp1;
            Salary sal;
            sal.Basic = 10000;
            sal.DA = 20;
            sal.TA = 30;
            sal.HRA = 20;
            emp1 = new EmployeeClass();
            emp1.Name="name1";
            emp1.EmployeeID = 10;
            emp1.DOB = new DateTime(1993, 10, 4);
            emp1.Email = "nam1@gmail.com";
            emp1.Gender = Gender.Male;
            emp1.Salary = sal;



            Console.WriteLine(emp1.Display());
            //Console.WriteLine(EmployeeClass.EmployeeCount);
            Console.ReadLine();

        }
    }
}
