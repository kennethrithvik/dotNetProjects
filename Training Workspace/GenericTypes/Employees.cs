using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
    public class Employees
    {
        private List<EmployeeClass> listEmps;

        public Employees()
        {
                listEmps=new List<EmployeeClass>();
        }

        public void Add(EmployeeClass emp)
        {
            listEmps.Add(emp);
        }

        public EmployeeClass GetByID(int id)
        {
            foreach (EmployeeClass item in listEmps)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }
        public void Remove(int id)
        {
            foreach (EmployeeClass item in listEmps)
            {
                if (item.ID == id)
                {
                    listEmps.Remove(item);
                }
            }
            return ;
        }
    }
}
