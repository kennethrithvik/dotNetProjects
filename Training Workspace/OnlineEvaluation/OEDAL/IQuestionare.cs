using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OEEntity;

namespace OEDAL
{
    public interface IQuestionare
    {
        List<OEEntity.Question> GetAll();
        OEEntity.Question GetByID(byte id);
        void AddUser(OEEntity.User us);
        List<OEEntity.User> GetUsers();
        void AddQuestion(OEEntity.Question q);

    }
}
