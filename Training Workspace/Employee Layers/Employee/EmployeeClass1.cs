using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    partial class EmployeeClass
    {
        public string Display()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("emp ID: {0}\n", this.EmployeeID);
            sb.AppendFormat("emp Nmae: {0}\n", this.Name);
            sb.AppendFormat("emp DOB: {0}\n", this.DOB.ToShortDateString());
            sb.AppendFormat("emp Salary: {0}\n", this.Salary.GetTakeHomeSalary());
            if(Gender==Employee.Gender.Male)
                sb.AppendFormat("Gender: Male\n");
            return sb.ToString();
        }
        
        ~EmployeeClass()
        {

        }
        public void Dispose()
        {

        }
    }
}
