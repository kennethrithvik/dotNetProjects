using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkillAssure
{
    class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }

        public List<Assessment> Assessments { get; set; }
    }
}
