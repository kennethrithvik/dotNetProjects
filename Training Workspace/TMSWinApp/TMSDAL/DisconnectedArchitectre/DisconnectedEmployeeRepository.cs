using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSEntityLayer;
using TMSEntityLayer.MyDataSet;

namespace TMSDAL.DisconnectedArchitectre
{
    public class DisconnectedEmployeeRepository:IRepository<TMSEntityLayer.Employee>
    {
        private TMSEntityLayer.MyDataSet.TMS mydataset;
        private TMSEntityLayer.MyDataSet.TMSTableAdapters.DepartmentTableAdapter taDept;
        private TMSEntityLayer.MyDataSet.TMSTableAdapters.EmployeeTableAdapter taEmp;
        private TMSEntityLayer.MyDataSet.TMSTableAdapters.RoleTableAdapter taRole;
        public DisconnectedEmployeeRepository()
        {
            mydataset = new TMSEntityLayer.MyDataSet.TMS();
            taDept = new TMSEntityLayer.MyDataSet.TMSTableAdapters.DepartmentTableAdapter();
            taEmp = new TMSEntityLayer.MyDataSet.TMSTableAdapters.EmployeeTableAdapter();
            taRole = new TMSEntityLayer.MyDataSet.TMSTableAdapters.RoleTableAdapter();

            taDept.Fill(mydataset.Department);
            taEmp.Fill(mydataset.Employee);
            taRole.Fill(mydataset.Role);
        }
        
        public List<TMSEntityLayer.Employee> GetAll()
        {
            List<TMSEntityLayer.Employee> mylist = new List<TMSEntityLayer.Employee>();
            TMSEntityLayer.MyDataSet.TMS.EmployeeDataTable empdt = mydataset.Employee;
            foreach (TMSEntityLayer.MyDataSet.TMS.EmployeeRow item in empdt.Rows)
            {
                TMSEntityLayer.Employee emp = new TMSEntityLayer.Employee();
                emp.EmployeeID = item.EmployeeID;
                emp.Name = item.Name;
                emp.DOB = item.DOB;
                emp.DOJ = item.DOJ;
                emp.DepartmentName = item.DepartmentRow.Name;
                emp.RoleName = item.RoleRow.Name;
                if (item.EmpStatus == 2)
                    continue;

                mylist.Add(emp);
            }

            return mylist;
        }

        public TMSEntityLayer.Employee GetByID(int id)
        {
            TMS.EmployeeRow empdt= mydataset.Employee.FindByEmployeeID(id);
            TMSEntityLayer.Employee emp = new TMSEntityLayer.Employee();
            emp.EmployeeID = empdt.EmployeeID;
            emp.Name = empdt.Name;
            emp.DOB = empdt.DOB;
            emp.DOJ = empdt.DOJ;
            emp.DepartmentName = empdt.DepartmentRow.Name;
            emp.RoleName = empdt.RoleRow.Name;
            
            

            return emp;
        }

        public List<TMSEntityLayer.Employee> GetByName(string nam)
        {
            throw new NotImplementedException();
        }

        public void Add(TMSEntityLayer.Employee emp)
        {
            taEmp.AddEmployee(emp.Name, emp.DOB, emp.DOJ, emp.RoleID, emp.DepartmentID, emp.MgrID, emp.LoginName,
                emp.Password);
        }

        public void Update(TMSEntityLayer.Employee emp)
        {
            taEmp.EditEmployee(emp.EmployeeID,emp.Name, emp.DOB, emp.DOJ, emp.RoleID, emp.DepartmentID, emp.MgrID, emp.LoginName,
                emp.Password);
        }

        public void Delete(int id)
        {
            taEmp.DeleteEmp(id);
        }
    }
}
