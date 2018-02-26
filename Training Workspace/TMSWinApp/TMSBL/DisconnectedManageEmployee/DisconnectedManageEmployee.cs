using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSDAL.DisconnectedArchitectre;

namespace TMSBL.DisconnectedManageEmployee
{
    public class DisconnectedManageEmployee
    {
        private TMSDAL.DisconnectedArchitectre.DisconnectedEmployeeRepository repo;

        public DisconnectedManageEmployee()
        {
            this.repo = new TMSDAL.DisconnectedArchitectre.DisconnectedEmployeeRepository();
        }

        public List<TMSEntityLayer.Employee> GetEmployees()
        {
            return repo.GetAll();
        }
        public void Add(TMSEntityLayer.Employee emp)
        {
            repo.Add(emp);
        }
        public void Update(TMSEntityLayer.Employee emp)
        {
            repo.Update(emp);
        }
        public void Delete(int eid)
        {
            repo.Delete(eid);
        }
    }
}
