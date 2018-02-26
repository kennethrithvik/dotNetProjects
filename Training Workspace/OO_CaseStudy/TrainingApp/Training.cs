using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp
{
    class Training
    {
        public int TrainingId { get; private set; }
        public string TrainingName { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public Trainer Trainer1 { get; private set; }
        public Course Course1 { get; private set; }

        public Training(int trainingId, string trainingName, DateTime startDate, DateTime endDate)
        {
            TrainingId = trainingId;
            TrainingName = trainingName;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void AddTrainer( Trainer trainer1)
        {
            Trainer1 = trainer1;
        }
        public void AddCourse(Course crs)
        {
            Course1 = crs;
        }
        public List<Trainee> Trainees =new List<Trainee>();

        public int getNumOfTrainees()
        {
            return Trainees.Count();
        }

        public string getTrainingOrganization()
        {
            return Trainer1.GetOrg();
        }

        public int getTrainingDuration()
        {
            //return EndDate.Subtract(StartDate).Days * 24;
            int dur = 0;
            foreach (var v1 in Course1.getModule())
            {
                foreach (var v2 in v1.getUnits())
                {
                    dur += v2.getDuration();
                }
            }
            return dur;
        }
    }
}
