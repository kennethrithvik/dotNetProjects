using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInheritance
{
    class Person
    {
        public Person()
        {
            Console.WriteLine("base constructor");
        }
        public void Name()
        {
            Console.WriteLine("base Name");
        }
        public virtual void DOB()
        {
            Console.WriteLine("base DOB");
        }
        private void PrivateM()
        {
            Console.WriteLine("base PrivateM");
        }
        protected void ProtectedM()
        {
            Console.WriteLine("base ProtectedM");
        }
    }

    class Employee:Person
    {
        public Employee()
        {
            Console.WriteLine("derived constructor");
        }
        public void Salary()
        {
            Console.WriteLine("Derived salary");
        }
        public override void DOB()
        {
            Console.WriteLine("Derived DOB");
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person obj;
            obj = new Person();
            obj.DOB();

            Employee obj1;
            obj1 = new Employee();
            obj1.DOB();
            obj1.Salary();

            Person obj2 = new Employee();
            obj2.DOB();
            obj2.Name();

            object obj3 = new Employee();

            Console.ReadLine();
        }
    }
}
