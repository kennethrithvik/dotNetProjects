using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSEntityLayer.EF;

namespace TMSDAL.EntityFramework
{
    public class BaseRepository
    {
        protected TMSEntityLayer.EF.TrainingManagementEntities mycontext;

        public BaseRepository()
        {
            
            mycontext = new TMSEntityLayer.EF.TrainingManagementEntities();
        }
    }
    public class EFEmployeeRepository:BaseRepository,IRepository<TMSEntityLayer.EF.Employee>
    {


        public List<TMSEntityLayer.EF.Employee> GetAll()
        {
            IEnumerable<TMSEntityLayer.EF.Employee> result = from emp in mycontext.Employees
                                                                .Include("Department")
                                                                .Include("Role")
                                                                .Include("Manager")
                                                                where emp.EmpStatus == 1
                                                                orderby emp.Name ascending
                                                                select emp;

            IEnumerable<TMSEntityLayer.EF.Employee> result1 = mycontext.Employees
                                                                .Where((emp) => emp.EmpStatus == 1)
                                                                .OrderBy((emp) => emp.Name)
                                                                .Select((emp) => emp);

            return result.ToList();//result1.ToList();

        }

        public TMSEntityLayer.EF.Employee GetByID(int id)
        {
            TMSEntityLayer.EF.Employee result = (from emp in mycontext.Employees
                                                  .Include("Department")
                                                   .Include("Role")
                                                where emp.EmployeeID == id && emp.EmpStatus == 1
                                                select emp).SingleOrDefault();

            TMSEntityLayer.EF.Employee result1 =( mycontext.Employees
                                                 .Where((emp) => emp.EmpStatus == 1&& emp.EmployeeID==id)
                                                  .Select((emp) => emp)).SingleOrDefault();
            return result;
        }

        public List<TMSEntityLayer.EF.Employee> GetByName(string nam)
        {
            IEnumerable<TMSEntityLayer.EF.Employee> result = from emp in mycontext.Employees
                                                              .Include("Department")
                                                                .Include("Role")
                                                             where emp.EmpStatus == 1 &&emp.Name.Contains(nam)
                                                             orderby emp.Name ascending
                                                             select emp;

            return result.ToList();
        }

        public void Add(TMSEntityLayer.EF.Employee emp)
        {
            mycontext.Employees.Add(emp);
            mycontext.SaveChanges();
        }

        public void Update(TMSEntityLayer.EF.Employee emp)
        {
            TMSEntityLayer.EF.Employee dbemp = GetByID(emp.EmployeeID);
            dbemp.Name = emp.Name;
            dbemp.DepartmentID = emp.DepartmentID;
            dbemp.RoleID = emp.RoleID;

            int ret = mycontext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
