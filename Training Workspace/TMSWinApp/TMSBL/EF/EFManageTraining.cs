using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSDAL.EntityFramework;

namespace TMSBL.EF
{
    public class EFManageTraining
    {
        private TMSDAL.ITrainingRepo trrepo;

        public EFManageTraining()
        {
            trrepo=new EFTrainingRepository();
        }
        public List<TMSEntityLayer.EF.Training> GetAll()
        {
            return trrepo.GetAll();
        }

        public TMSEntityLayer.EF.Training GetByID(int id)
        {
            return trrepo.GetByID(id);
        }

        public List<TMSEntityLayer.EF.Training> GetByName(string nam)
        {
            return trrepo.GetByName(nam);
        }

        public void Add(TMSEntityLayer.EF.Training tr)
        {
            trrepo.Add(tr);
        }

        public void Update(TMSEntityLayer.EF.Training tr)
        {
            trrepo.Update(tr);
        }

        public void Delete(int id)
        {
            trrepo.Delete(id);
        }

        public List<TMSEntityLayer.EF.Training> GetByDate(DateTime sd, DateTime ed)
        {
            return trrepo.GetByDate(sd, ed);
        }

        public List<TMSEntityLayer.EF.Training> GetByDateName(string name, DateTime sd, DateTime ed)
        {
            return trrepo.GetByDateName(name, sd, ed);
        }
        public List<TMSEntityLayer.EF.Domain> GetDomains()
        {
            return trrepo.GetDomains();
        }
    }
}
