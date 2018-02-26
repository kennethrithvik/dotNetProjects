using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OEDAL.EntityFramework;

namespace OEBL.EF
{
    public class ManageTest
    {
        private OEDAL.EntityFramework.IQuestionRepo qr;
        private OEDAL.EntityFramework.IOptionRepo or;

        public ManageTest()
        {
            qr=new QuestionRepository();
            or = new OptionRepository();
        }

        public List<OEEntity.EntityFramework.Question> GetAll()
        {
            
            return qr.GetAll();
        }

        public OEEntity.EntityFramework.Question GetByID(byte id)
        {
            return qr.GetByID(id);
        }

        public void AddQuestion(OEEntity.EntityFramework.Question q)
        {
            qr.AddQuestion(q);
        }

        public OEEntity.EntityFramework.Option GetOptionByID(byte oid)
        {
            
            return or.GetByID(oid);
        }

        public string GetReport(List<OEEntity.EntityFramework.Question> reslist)
        {
            int testtotal = 0, score = 0;
            StringBuilder sb = new StringBuilder();
            foreach (OEEntity.EntityFramework.Question item in reslist)
            {
                testtotal += item.marks;
                bool fl = true;
                if (item.Options1.Count != item.Options.Count)
                {
                    fl = false;
                }
                else
                {
                    for (int i=0;i<item.Options.Count;i++ )
                    {
                        if (item.Options.ToList()[i].oid!=item.Options1.ToList()[i].oid)
                        {
                            fl = false;
                            break;
                        }
                    }
                    
                }

                if (fl == true)
                {
                    score += item.marks;
                    sb.Append("\n\n" + item.name + "  ---------  RIGHT ANSWER");
                }
                else
                {
                    sb.Append("\n\n" + item.name + "  ---------  WRONG ANSWER");
                }
            }

            sb.Append("\n\n\nYou Scored " + score + " marks out of a total of " + testtotal + " marks");

            return sb.ToString();
        }

    }
}
