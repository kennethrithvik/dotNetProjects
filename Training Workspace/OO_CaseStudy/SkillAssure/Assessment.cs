using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkillAssure
{
    class Assessment
    {
        public int AssessmentId { get; set; }
        public string desc { get; set; }
        public int Question { get; set; }

        public DateTime DtAssessment { get; set; }

        public List<Question> Questions { get; set; }
        public int getTotalMarks()
        {
            int total=0;
            foreach (Question item in Questions)
            {
                total = total + item.Marks;
            }
            return total;
        }
    }
}
