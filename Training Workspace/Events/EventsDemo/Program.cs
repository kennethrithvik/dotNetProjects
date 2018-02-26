using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo
{
    class Program
    {
        //subscriber
        static void Main(string[] args)
        {
            Person obj= new Person("Tesco");
            obj.NameChange +=new PersonDelegate(MyEventHandler);
            obj.ChangeName("new Tesco");



            Console.ReadLine();
        }

        static void MyEventHandler(object sender, PersonEventArgs e)
        {
            Console.WriteLine(e.oldName+"  "+e.newName);
        }
    }
}
