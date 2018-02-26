using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkillAssure
{
    class Program
    {
        static void Main(string[] args)
        {
            Question q1;
            Question q2;

            q1 = new MCQQuestion();
            q2 = new HandsOnQuestion();

            q1.Marks = 10;
            q2.Marks = 10;

            Assessment assess = new Assessment();
            assess.Questions = new List<Question>();
            assess.Questions.Add(q1);
            assess.Questions.Add(q2);

            Iteration i1 = new Iteration();
            Iteration i2 = new Iteration();
            Iteration i3 = new Iteration();

            i1.Assessments = new List<Assessment>();
            i1.Assessments.Add(assess);

            i2.Assessments = new List<Assessment>();
            i2.Assessments.Add(assess);

            i3.Assessments = new List<Assessment>();
            i3.Assessments.Add(assess);

            SkillAssureTrainingModel skt = new SkillAssureTrainingModel();

            skt._iteration[0] = i1;
            skt._iteration[1] = i2;
            skt._iteration[2] = i3;


            Console.WriteLine("Total assessments");
            Console.WriteLine(skt.getTotalAssessmentsInTheTraining());
            Console.WriteLine("Num of mcq questions:");
            Console.WriteLine(skt.getNumMCQBasedAssessments());
            Console.WriteLine("Num of Hands on questions:");
            Console.WriteLine(skt.getNumHandsOnBasedAssessments());
            Console.WriteLine("Total Marks");
            Console.WriteLine(skt.getTotalScoreOfAllAssessments());
        }
    }
}
