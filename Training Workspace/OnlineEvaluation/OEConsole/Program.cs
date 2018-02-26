using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OEBL;
using OEBL.EF;
using OEEntity;

namespace OEConsole
{
    class Program
    {
        

        static void Main(string[] args)
        {
            OEBL.EF.ManageTest mt=new ManageTest();

            //mt.GetAll().ForEach((qu)=>Console.WriteLine(qu.name));
           

            //call1();
            Console.ReadLine();
        }

        public static void call1()
        {
            int total = 0, Testtotal = 0;

            OEBL.TestManager tm = new TestManager();
            List<OEEntity.Question> ques = tm.GetQuestions();

            List<OEEntity.Question> reslist = new List<Question>();
            OEEntity.Question res;


            Console.WriteLine("Welcome to the Test\n\n\n");

            foreach (OEEntity.Question item in ques)
            {
                res = new OEEntity.Question();
                res.question = item.question;
                res.qid = item.qid;
                res.marks = item.marks;
                res.options = new List<OEEntity.Option>();
                res.coptions = new List<Option>(); res.options = new List<Option>();

                Console.WriteLine(item.question + "\t\t(" + item.marks + ") marks");
                foreach (OEEntity.Option op in item.options)
                {
                    Console.WriteLine(op.oid + ". " + op.option);
                }

                Console.WriteLine("\nEnter yout choice");
                int choice = Int16.Parse(Console.ReadLine());

                foreach (OEEntity.Option op in item.options)
                {
                    if (choice == op.oid)
                    {
                        res.options.Add(op);
                    }
                }
                foreach (OEEntity.Option cop in item.coptions)
                {
                    res.coptions.Add(cop);
                }

                Console.Clear();
                reslist.Add(res);
            }

            Console.WriteLine(tm.GetReport(reslist));
        }
    }
}
