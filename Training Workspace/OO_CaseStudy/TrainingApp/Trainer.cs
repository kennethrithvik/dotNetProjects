using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp
{
    class Trainer
    {
        public string Name { get; private set; }
        public int Id { get; private set; }

        public Organization Org { get; private set; }

        public Trainer(int id, string name, Organization org)
        {
            Id = id;
            Name = name;
            Org = org;
        }

        public List<Training> Trainings =new List<Training>();

        public string GetOrg()
        {
            return this.Org.getName();
        }


    }
}
