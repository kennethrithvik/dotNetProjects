using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method|AttributeTargets.Property,AllowMultiple = true)]
    class BugAttribute:System.Attribute
    {
        public BugAttribute(string dev,string dt,string msg)
        {
            Developer = dev;
            FoundDate = dt;
            Message = msg;
        }

        public string Developer { get; set; }
        public string FoundDate { get; set; }
        public string Corrected { get; set; }
        public string Message { get; set; }
        public string CorrectedDate { get; set; }

        public string GetBug()
        {
            string msg = "Developer-" + Developer;
            msg += "\nFoundDate-" + FoundDate;
            msg += "\nMessage-" + Message;
            msg += "\nCorrected-" + Corrected;
            msg += "\nCorrectedDate-" + CorrectedDate;
            return msg;
        }
    }
}
