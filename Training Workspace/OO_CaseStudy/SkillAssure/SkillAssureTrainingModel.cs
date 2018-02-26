using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkillAssure
{
    class SkillAssureTrainingModel
    {
        public string ClientName { get; set; }

       public  Iteration[] _iteration = new Iteration[3];

        public int getTotalAssessmentsInTheTraining()
        {
            int no = 0;
            for (int i = 0; i < 3; i++)
            {
                no += _iteration[i].Assessments.Count;
            }

            return no;
        } 
        public int getNumMCQBasedAssessments()
        {
            int no = 0;
            for (int i = 0; i < 3; i++)
            {
                foreach (Assessment assess in _iteration[i].Assessments)
                {
                    foreach (Question item in assess.Questions)
                    {
                        if(item is MCQQuestion)
                        {
                            no++;
                        }
                    }
                }
            }
            return no;
        }

        public int getNumHandsOnBasedAssessments()
        {
            int no = 0;
            for (int i = 0; i < 3; i++)
            {
                foreach (Assessment assess in _iteration[i].Assessments)
                {
                    foreach (Question item in assess.Questions)
                    {
                        if (item is HandsOnQuestion)
                        {
                            no++;
                        }
                    }
                }
            }
            return no;
        }

        public int getTotalScoreOfAllAssessments()
        {
           int no = 0;
           for (int i = 0; i < 3; i++)
           {
               foreach (Assessment assess in _iteration[i].Assessments)
               {
                   no += assess.getTotalMarks();
               }
           }
           return no;
        }
    }
}
