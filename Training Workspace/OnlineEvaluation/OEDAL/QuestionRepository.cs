using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OEEntity;
using OEEntity.DataSets;

namespace OEDAL
{
    public class QuestionRepository:IQuestionare
    {
        private OEEntity.DataSets.OE mydataset;
        private OEEntity.DataSets.OETableAdapters.QuestionTableAdapter taQues;
        private OEEntity.DataSets.OETableAdapters.UserTableAdapter taUs;
        OptionRepository orepo;

        public QuestionRepository()
        {
            mydataset = new OEEntity.DataSets.OE();
            taQues = new OEEntity.DataSets.OETableAdapters.QuestionTableAdapter();
            taUs = new OEEntity.DataSets.OETableAdapters.UserTableAdapter();

            taQues.Fill(mydataset.Question);
            taUs.Fill(mydataset.User);

            orepo = new OptionRepository();
        }
        public List<OEEntity.Question> GetAll()
        {
            List<OEEntity.Question> ques=new List<OEEntity.Question>();
            OEEntity.Question qobj;
            
            OEEntity.DataSets.OE.QuestionDataTable qdt = mydataset.Question;
            
            foreach (OEEntity.DataSets.OE.QuestionRow item in qdt.Rows)
            {
                qobj = new OEEntity.Question();
                qobj.qid = item.qid;
                qobj.marks = item.marks;
                qobj.question = item.name;

                qobj.options = orepo.GetAllByID(item.qid);


                qobj.coptions = orepo.GetCOptionByQID(item.qid);
                


                ques.Add(qobj);
            }
            return ques;

        }



        public Question GetByID(byte qid)
        {
            OEEntity.Question qobj;

            OEEntity.DataSets.OE.QuestionDataTable qdt = mydataset.Question;

            foreach (OEEntity.DataSets.OE.QuestionRow item in qdt.Rows)
            {
                if (qid == item.qid)
                {
                    qobj = new OEEntity.Question();
                    qobj.qid = item.qid;
                    qobj.marks = item.marks;
                    qobj.question = item.name;

                    qobj.options = orepo.GetAllByID(item.qid);

                    qobj.coptions = orepo.GetCOptionByQID(item.qid);
                    return qobj;
                }

            }
            return new OEEntity.Question();
        }

        public byte GetByQues(string nam)
        {
           
            OEEntity.DataSets.OE.QuestionDataTable qdt = mydataset.Question;

            foreach (OEEntity.DataSets.OE.QuestionRow item in qdt.Rows)
            {
                if (nam.Equals(item.name))
                {
                    return item.qid;
                }

            }
            return 0;
        }

        public void AddUser(OEEntity.User us)
        {
            taUs.AddUser(us.name, us.login, us.password);
           // mydataset.User.AddUserRow(1,us.name, us.login, us.password);
        }

        public List<OEEntity.User> GetUsers()
        {
            OEEntity.User u;
            List<OEEntity.User> ulist=new List<User>();
            OEEntity.DataSets.OE.UserDataTable udt = mydataset.User;

            foreach (OEEntity.DataSets.OE.UserRow item in udt.Rows)
            {
                u = new OEEntity.User();
                u.uid = item.uid;
                u.name = item.name;
                u.login = item.login;
                u.password = item.password;
                
                ulist.Add(u);
            }
            return ulist;
            
        }

        public void AddQuestion(OEEntity.Question q)
        {
            taQues.AddQuestion(q.question, q.marks);
            taQues.Fill(mydataset.Question);
            q.qid = GetByQues(q.question);
            orepo.addOptions(q);
        }


    }
}
