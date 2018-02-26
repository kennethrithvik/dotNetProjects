using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEDAL
{
    public class RepoFactory
    {
        private RepoFactory()
        {
            
        }
        static RepoFactory rf=new RepoFactory();
        public static RepoFactory GetInstance()
        {
            return rf;
        }
        IQuestionare qref;
        IOptionRepository oref;

        public IQuestionare GetQuestionRepo()
        {
            qref=new QuestionRepository();
            return qref;
        }
        public IOptionRepository GetoptionRepo()
        {
            oref = new OptionRepository();
            return oref;
        }
    }
}
