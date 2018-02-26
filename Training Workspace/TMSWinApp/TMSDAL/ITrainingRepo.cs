using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSDAL
{
    public interface ITrainingRepo:IRepository<TMSEntityLayer.EF.Training>
    {
        List<TMSEntityLayer.EF.Training> GetByDate(DateTime sd, DateTime ed);
        List<TMSEntityLayer.EF.Training> GetByDateName(string name,DateTime sd, DateTime ed);
        List<TMSEntityLayer.EF.Domain> GetDomains();


    }
}
