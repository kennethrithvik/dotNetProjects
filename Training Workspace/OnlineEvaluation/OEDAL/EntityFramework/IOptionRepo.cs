using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEDAL.EntityFramework
{
    public interface IOptionRepo
    {
        List<OEEntity.EntityFramework.Option> GetCOptionByQID(byte qid);
        List<OEEntity.EntityFramework.Option> GetAllByID(byte qid);
        void addOptions(OEEntity.EntityFramework.Question q);
        void addCOption(byte qid, byte oid);
        OEEntity.EntityFramework.Option GetByID(byte oid);
    }
}
