using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo
{

    class PersonEventArgs:EventArgs
    {
        public string oldName{ get; set; }
        public string newName { get; set; }

        public PersonEventArgs(string oldName, string newName)
        {
            this.oldName = oldName;
            this.newName = newName;
        }
    }

    internal delegate void PersonDelegate(object sender, PersonEventArgs e);

    //Publisher or event listener or source
    class Person
    {
        private string strName;
        public event PersonDelegate NameChange; 

        public Person(string strName)
        {
            this.strName = strName;
        }


        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }
        

        public void ChangeName(string newName)
        {
            string OldName = strName;
            strName = newName;

            //raise notification here
            if (NameChange != null)
            {
                NameChange.Invoke(this,new PersonEventArgs(OldName,newName));
            }
        }
    }
}
