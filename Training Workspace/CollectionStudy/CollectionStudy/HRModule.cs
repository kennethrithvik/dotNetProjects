using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionStudy
{
    class HRModule
    {
        private static Dictionary<int,Employee> ListEmps1= new Dictionary<int, Employee>();

        public static Dictionary<int, Employee> ListEmps
        {
            get { return ListEmps1; }
        }

        public static void AddEmployee(Employee e)
        {
            ListEmps1.Add(e.EmployeeID,e);
        }
    }
}
