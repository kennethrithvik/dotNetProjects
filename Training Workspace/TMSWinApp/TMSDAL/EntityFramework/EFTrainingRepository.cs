using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSEntityLayer.EF;

namespace TMSDAL.EntityFramework
{
    public class EFTrainingRepository:BaseRepository,ITrainingRepo
    {
        public List<TMSEntityLayer.EF.Training> GetAll()
        {
            IEnumerable<TMSEntityLayer.EF.Training> result = mycontext.Trainings
                                                        .Include("Domain")
                                                        .Where((train)=>train.Status==1)
                                                        .OrderBy((train)=>train.Title)
                                                        .Select((train) => train);
            return result.ToList();
        }

        public TMSEntityLayer.EF.Training  GetByID(int id)
        {
            TMSEntityLayer.EF.Training result =(mycontext.Trainings
                                                        .Include("Domain")
                                                        .Where((train)=>train.TrainingID==id && train.Status==1)
                                                        .OrderBy((train) => train.Title)
                                                        .Select((train) => train)).SingleOrDefault();
            return result;
        }

        public List<TMSEntityLayer.EF.Training> GetByName(string nam)
        {
            IEnumerable<TMSEntityLayer.EF.Training> result = mycontext.Trainings
                                                        .Include("Domain")
                                                        .Where((train)=>train.Title.Contains(nam) && train.Status==1)
                                                        .OrderBy((train) => train.Title)
                                                        .Select((train) => train);
            return result.ToList();
        }

        public void Add(TMSEntityLayer.EF.Training tr)
        {
            //TMSEntityLayer.EF.Training newtr = tr;
            mycontext.Trainings.Add(tr);
            mycontext.SaveChanges();
        }

        public void Update(TMSEntityLayer.EF.Training tr)
        {
            TMSEntityLayer.EF.Training dbemp = new Training();
            dbemp = GetByID(tr.TrainingID);
            dbemp.Title = tr.Title;
            dbemp.DomainID = tr.DomainID;
            dbemp.StartDate = tr.StartDate;
            dbemp.EndDate = tr.EndDate;
            dbemp.Credits = tr.Credits;


            int ret = mycontext.SaveChanges();
        }

        public void Delete(int id)
        {
            //mycontext.Trainings.Remove(dbemp);
            TMSEntityLayer.EF.Training dbemp = GetByID(id);
            dbemp.Status = 2;
            mycontext.SaveChanges();
        }

        public List<TMSEntityLayer.EF.Training> GetByDate(DateTime sd, DateTime ed)
        {
            IEnumerable<TMSEntityLayer.EF.Training> result = mycontext.Trainings
                                                        .Include("Domain")
                                                        .Where((train) => (train.StartDate >= sd) && (train.StartDate <= ed) && train.Status == 1)
                                                        .OrderBy((train) => train.Title)
                                                        .Select((train) => train);
            return result.ToList();
        }

        public List<TMSEntityLayer.EF.Training> GetByDateName(string name, DateTime sd, DateTime ed)
        {
            IEnumerable<TMSEntityLayer.EF.Training> result = mycontext.Trainings
                                                        .Include("Domain")
                                                        .Where((train) => (train.StartDate >= sd) && (train.StartDate <= ed) && train.Title.Contains(name)
                                                        && train.Status == 1)
                                                        .OrderBy((train) => train.Title)
                                                        .Select((train) => train);
            return result.ToList();
        }

        public List<TMSEntityLayer.EF.Domain> GetDomains()
        {
            IEnumerable<TMSEntityLayer.EF.Domain> result = mycontext.Domains 
                                                        .OrderBy((dom) => dom.Name)
                                                        .Select((dom) => dom);
            return result.ToList();
        }
    }
}
