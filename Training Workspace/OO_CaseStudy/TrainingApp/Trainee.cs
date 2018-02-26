using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp
{
    class Trainee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Trainer Trainer1 { get; private set; }

        public List<Training> Trainings =new List<Training>();

        public Trainee(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void AddTrainer(Trainer trainer1)
        {
            Trainer1 = trainer1;
        }
    }
}
