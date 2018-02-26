using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10, b = 20;
            GenericSwap<int>(ref a, ref b);
            MyGenericClass<EmployeeClass> empCollection=new MyGenericClass<EmployeeClass>();

            //MyGenericClass<Salary> salaryCollection = new MyGenericClass<Salary>();
            //salaryCollection.Add(new Salary());
            Console.ReadLine();
        }

        public static void GenericSwap<Targ1>(ref Targ1 a1,ref Targ1 a2)
        {
            Targ1 temp;
            temp = a2;
            a2 = a1;
            a1 = temp;

        }
    }
}
