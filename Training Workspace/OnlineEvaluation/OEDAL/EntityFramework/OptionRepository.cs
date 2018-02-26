using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEDAL.EntityFramework
{
    public class OptionRepository:BaseRepository,IOptionRepo
    {


        public List<OEEntity.EntityFramework.Option> GetCOptionByQID(byte qid)
        {
            throw new NotImplementedException();
        }

        public List<OEEntity.EntityFramework.Option> GetAllByID(byte qid)
        {
            IEnumerable<OEEntity.EntityFramework.Option> result = mycontext.Options
                                                                    .Where((op) => op.qid == qid)
                                                                    .OrderBy((op) => op.name)
                                                                    .Select((op) => op);
            return result.ToList();
        }

        public void addOptions(OEEntity.EntityFramework.Question q)
        {
            foreach (var item in q.Options)
            {
                mycontext.Options.Add(item);
            }
            mycontext.SaveChanges();
        }

        public void addCOption(byte qid, byte oid)
        {
            throw new NotImplementedException();
        }
        public OEEntity.EntityFramework.Option GetByID(byte oid)
        {
            OEEntity.EntityFramework.Option result = (mycontext.Options
                                                                    .Where((op) => op.oid == oid)
                                                                    .OrderBy((op) => op.name)
                                                                    .Select((op) => op)).SingleOrDefault();
            return result;
        }
    }
}
