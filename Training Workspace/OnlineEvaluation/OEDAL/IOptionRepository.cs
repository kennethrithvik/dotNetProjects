using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEDAL
{
    public interface IOptionRepository
    {
        List<OEEntity.Option> GetCOptionByQID(byte qid);
        List<OEEntity.Option> GetAllByID(byte qid);
        void addOptions(OEEntity.Question q);
        void addCOption(byte qid, byte oid);
    }
}
