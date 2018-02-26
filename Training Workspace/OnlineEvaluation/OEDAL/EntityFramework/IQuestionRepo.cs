using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEDAL.EntityFramework
{
   public interface IQuestionRepo
    {
        List<OEEntity.EntityFramework.Question> GetAll();
        OEEntity.EntityFramework.Question GetByID(byte id);
      
        void AddQuestion(OEEntity.EntityFramework.Question q);
    }
}
