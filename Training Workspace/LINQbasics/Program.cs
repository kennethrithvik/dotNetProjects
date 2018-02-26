using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQbasics
{
    class Department
    {
        public int DeptID { get; set; }
        public string Name { get; set; }
    }

    class Employee
    {
        public int EmpID{ get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public int DeptID { get; set; }
        public decimal Salary { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Department> tescodepts = new List<Department>
            {
                new Department{DeptID = 1,Name = "TescoBank"},
                new Department{DeptID = 2,Name = "RFID"},
                new Department{DeptID = 3,Name = "TescoRetail"},
                new Department{DeptID = 4,Name = "GHS"}
            };

            List<Employee> tescoemps = new List<Employee>
            {
                new Employee{EmpID = 1,Name="Kenneth",DOB=new DateTime(1993,10,4),DeptID = 1,Salary = 700000},
                new Employee{EmpID = 2,Name="Kumuda",DOB=new DateTime(1993,4,27),DeptID = 2,Salary = 486000},
                new Employee{EmpID = 3,Name="Bhanu",DOB=new DateTime(1993,8,28),DeptID = 3,Salary = 560000},
                new Employee{EmpID = 4,Name="Arpit",DOB=new DateTime(1993,2,19),DeptID = 4,Salary = 900000},
                new Employee{EmpID = 5,Name="Sharukh",DOB=new DateTime(1994,1,18),DeptID = 1,Salary = 450000}
            };


            var allemps = from Department dept in tescodepts
                          join Employee emp in tescoemps
                          on dept.DeptID equals emp.DeptID
                          //where emp.Name.StartsWith("K") && emp.DeptID==1
                          //where  emp.DOB >= new DateTime(1993,1,1) && emp.DOB<=new DateTime(1994,1,1)
                          orderby emp.DOB ascending 
                          select new
                          {
                                EmpID=emp.EmpID,
                                Name=emp.Name,
                                DOB=emp.DOB,
                                DeptID=emp.DeptID,
                                DeptName=dept.Name,
                                Salary=emp.Salary
                          };


           // IEnumerable<Employee> pagination = allemps.Skip(2*2).Take(2);

            decimal totalsalary = allemps.Sum((emp) => emp.Salary);
            decimal minsalary = allemps.Min((emp) => emp.Salary);
            //Console.WriteLine(totalsalary);


            foreach (var item in allemps)
            {
                Console.WriteLine("{0,-5}{1,-10}{2,-15}{3,-15}{4,-10}",item.EmpID,item.Name,item.DOB.ToShortDateString(),item.DeptName,item.Salary);
            }


            IEnumerable<string> allempnames = allemps
                                              .Select((emp) => emp.Name)
                                              .Distinct()
                                              .OrderBy((empnames) => empnames);
            foreach (var VARIABLE in allempnames)
            {
                //Console.WriteLine(VARIABLE);
            }















            Console.ReadLine();
        }

        void temp()
        {
            string[] mycountries = {"India", "China", "Japan", "Australia", "USA", "UK", "Russia"};

            //IEnumerable<string> result = from string country in mycountries
            //                             //where country.StartsWith("U")
            //                             //where country.Length<=5
            //                             orderby country ascending 
            //                             select country;

            Func<string, bool> Startwith = (country) => country.StartsWith("U");
            Func<string, bool> lent5 = (country) => country.Length<=5;
            Func<string, bool> f_ind = (country) => country=="India";
            IEnumerable<string> result = mycountries
                                        .Where(lent5).OrderBy((country) => country.Length)
                                        .Select((country)=> country);

            List<string> mylist=result.ToList();//Immediately execute query




            foreach (string item in result)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
