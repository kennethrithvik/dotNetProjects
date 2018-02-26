using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionStudy
{
    class Employee
    {
        private static int sintEmpCounter;

        public static int EmployeeCount
        {
            get { return sintEmpCounter; }
          
        }
        


        public Employee()
        {

            sintEmpCounter++;
            EmployeeID = sintEmpCounter;
        }
        public Employee(string name,string gen):this()
        {
 
            Name = name;
            Gender = gen;

        }
        

        private int mintEmployeeID;
        
        public int EmployeeID
        {
            get
            {
                return mintEmployeeID;

            }
            private set { mintEmployeeID = value; }
        }

        private string mstrName;

        public string Name
        {
            get { return mstrName; }
            set {
                if (value!=null)
                    mstrName = value;
                else
                    throw new Exception("Name should not be null");
            }
        }


        private string mstrGender;
        public string Gender
        {
            get { return mstrGender; }
            set
            {
                if (value.Equals("male")||value.Equals("female"))
                    mstrGender = value;
                else
                    throw new Exception("Invalid Gender");
            }
        }
        

        public string Display()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("emp ID: {0}\n", this.EmployeeID);
            sb.AppendFormat("emp Nmae: {0}\n", this.Name);
            sb.AppendFormat("emp Gender: {0}\n", this.Gender);

            return sb.ToString();
        }
        

        
    }
}
