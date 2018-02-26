using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Organization org = new Organization("Pratian");
            Trainer tr = new Trainer(1, "Trainer 1", org);
            Training trng = new Training(1, "Tesco Batch 5", new DateTime(2015, 01, 01), new DateTime(2015, 09, 09));
            trng.AddTrainer(tr);
            tr.Trainings = new List<Training>();
            tr.Trainings.Add(trng);



            Console.WriteLine("Organization Name:{0}", trng.getTrainingDuration());
            Console.ReadLine();

        }
    }
}
