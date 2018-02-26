using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp
{
    class Organization
    {
        public string OrgName { get; private set; }

        public Organization(string orgName)
        {
            OrgName = orgName;
        }

        public string getName()
        {
            return OrgName;
        }

    }

}
