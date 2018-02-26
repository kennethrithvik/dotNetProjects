using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSDAL.EntityFramework;
using BaseRepository = TMSDAL.BaseRepository;

namespace TMSBL.EF
{
    public class EFManageEmployee:BaseRepository
    {
        private TMSDAL.IRepository<TMSEntityLayer.EF.Employee> emprepo;

        public EFManageEmployee()
        {
            emprepo=new EFEmployeeRepository();
        }

        public List<TMSEntityLayer.EF.Employee> GetEmployees()
        {
            return emprepo.GetAll();
        }

        public List<TMSEntityLayer.EF.Employee> GetEmpByName(string name)
        {
            return emprepo.GetByName(name);
        }
    }
}
