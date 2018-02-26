using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSEntityLayer
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public byte DepartmentID { get; set; }
        public byte RoleID { get; set; }
        public int MgrID { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string DepartmentName { get; set; }
        public string RoleName { get; set; }

       
    }
}
