using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkillAssure
{
    class Iteration
    {
        public int IterationNo { get; set; }

        public string goal { get; set; }

        public Course _Course;

        public List<Assessment> Assessments { get; set; }
    }
}
