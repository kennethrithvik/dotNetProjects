using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEDAL.EntityFramework
{
    public class QuestionRepository:BaseRepository,IQuestionRepo
    {
        public List<OEEntity.EntityFramework.Question> GetAll()
        {
            IEnumerable<OEEntity.EntityFramework.Question> result = mycontext.Questions
                                                                    .Include("Options")
                                                                    .Include("Options1")
                                                                    .OrderBy((qu) => qu.qid)
                                                                    .Select((qu) => qu);
            return result.ToList();
        }

        public OEEntity.EntityFramework.Question GetByID(byte id)
        {
            OEEntity.EntityFramework.Question  result = (mycontext.Questions
                                                                    .Include("Options")
                                                                    .Include("Options1")
                                                                    .Where((qu)=>qu.qid==id)
                                                                    .Select((qu) => qu)).SingleOrDefault();
            return result;
        }

        public void AddQuestion(OEEntity.EntityFramework.Question q)
        {
            mycontext.Questions.Add(q);
            mycontext.SaveChanges();
        }

      
    }
}
