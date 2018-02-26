using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    partial class EmployeeClass:IDisposable
    {
        
        private static int sintEmpCounter;

        public static int EmployeeCount
        {
            get { return sintEmpCounter; }
          
        }
        


        public EmployeeClass()
        {
            DOB = DateTime.Now;
            sintEmpCounter++;
        }
        public EmployeeClass(int eid,string name):this()
        {
            EmployeeID = eid;
            Name = name;
            
        }
        

        private int mintEmployeeID;
        
        public int EmployeeID
        {
            get
            {
                return mintEmployeeID;

            }
            set
            {
                if (value > 0)
                {
                    mintEmployeeID = value;
                }
                else
                    throw new Exception("invalid ID");

            }
        }

        private string mstrName;

        public string Name
        {
            get { return mstrName; }
            set {
                if (value.Length > 3)
                    mstrName = value;
                else
                    throw new Exception("Length should be atleast 3");
            }
        }

        private DateTime mdtDOB;

        public DateTime DOB 
        {
            get { return mdtDOB; }
            set { mdtDOB = value; }
        }


        

        public short Age
        {
            get {
                TimeSpan ts = DateTime.Now.Subtract(DOB);
                   // ts.Days
                return (short)(ts.Days/365); }
            
        }
        public string Email { get; set; }

        public Gender Gender;
        public Salary Salary;

        
    }
}
