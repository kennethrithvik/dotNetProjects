using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSEntityLayer.ViewModels
{
    public class EditEmployeeViewModel
    {
        public Employee Employee { get; set; }
        public List<Department> Departments  { get; set; }
        //public List<Role> Roles  { get; set; }
        public List<Employee> Managers  { get; set; }
        public List<Role> Roles { get; set; } 
    }
    
}
