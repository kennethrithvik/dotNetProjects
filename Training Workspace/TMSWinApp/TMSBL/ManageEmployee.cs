using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSBL
{
    public class ManageEmployee
    {
        private TMSDAL.IRepository<TMSEntityLayer.Employee> emprepo;
        private TMSDAL.IRepository<TMSEntityLayer.Department> deptrepo;
        private TMSDAL.IRepository<TMSEntityLayer.Role> rolerepo;
        private TMSDAL.IManagerRepository<TMSEntityLayer.Employee> managerrepo; 

        public ManageEmployee()
        {
            emprepo = new TMSDAL.EmployeeRepository();
            deptrepo = new TMSDAL.DepartmentRepository();
            rolerepo = new TMSDAL.RoleRepository();
            managerrepo = new TMSDAL.EmployeeRepository();
        }
        public List<TMSEntityLayer.Employee> GetEmployees()
        {
            return emprepo.GetAll();
        }
        public List<TMSEntityLayer.Employee> GetEmployeesByName(string nm)
        {
            return emprepo.GetByName(nm);
        }

        public TMSEntityLayer.ViewModels.EditEmployeeViewModel PrepareInsert()
        {
            TMSEntityLayer.ViewModels.EditEmployeeViewModel vm = new TMSEntityLayer.ViewModels.EditEmployeeViewModel();
            vm.Departments = deptrepo.GetAll();
            vm.Roles = rolerepo.GetAll();
            //vm.Managers = managerrepo.GetManagers();
            return vm;
        }

        public TMSEntityLayer.ViewModels.EditEmployeeViewModel PrepareEdit(int eid)
        {          
            //take eid get the emp object for eid
            //assign this to the view models employee property
            //all the steps will be same as what is done for prepare insert
            TMSEntityLayer.ViewModels.EditEmployeeViewModel vm = new TMSEntityLayer.ViewModels.EditEmployeeViewModel();
            vm.Departments = deptrepo.GetAll();
            vm.Employee = emprepo.GetByID(eid);
            //vm.Roles = rolerepo.GetAll();
            //vm.Managers = managerrepo.GetManagers();
            return vm;
        }

        public List<TMSEntityLayer.Employee> GetManagers()
        {
            return managerrepo.GetManagers();
        }

        public void AddEmployee(TMSEntityLayer.Employee emp)
        {
            emprepo.Add(emp);
        }
    }
}
