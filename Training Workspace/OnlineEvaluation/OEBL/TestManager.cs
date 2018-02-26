using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OEDAL;

namespace OEBL
{
    public class TestManager
    {
        private OEDAL.IQuestionare qrepo;
        

        public TestManager()
        {
            OEDAL.RepoFactory rf = OEDAL.RepoFactory.GetInstance();
            qrepo = rf.GetQuestionRepo();
        }

        public List<OEEntity.Question> GetQuestions()
        {
            return qrepo.GetAll();
        }

        public string GetReport(List<OEEntity.Question> reslist)
        {
            int testtotal = 0, score = 0;
            StringBuilder sb=new StringBuilder();
            foreach (OEEntity.Question item in reslist)
            {
                testtotal += item.marks;
                bool fl = true;
                if (item.coptions.Count != item.options.Count)
                {
                    fl = false;
                }
                else
                {
                    for(int i=0;i<item.options.Count;i++)
                    {
                        if (item.options[i].option != item.coptions[i].option)
                        {
                            fl = false;
                            break;
                        }
                    }
                }

                if (fl == true)
                {
                    score += item.marks;
                    sb.Append("\n\n" + item.question + "  ---------  RIGHT ANSWER");
                }
                else
                {
                    sb.Append("\n\n" + item.question + "  ---------  WRONG ANSWER");
                }
            }

            sb.Append("\n\n\nYou Scored " + score + " marks out of a total of "+testtotal+" marks");

            return sb.ToString();
        }

        public void AddUser(OEEntity.User us)
        {
            qrepo.AddUser(us);
        }

        public List<OEEntity.User> GetUsers()
        {
           return qrepo.GetUsers();
        }

        public void AddQuestion(OEEntity.Question q)
        {
            qrepo.AddQuestion(q);
        }
    }
}
