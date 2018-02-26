using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp
{
    class Unit
    {
        public int DurationHrs { get; private set; }

        public int getDuration()
        {
            return DurationHrs;
        }

        public List<Topic> Topics=new List<Topic>();
    }
}
