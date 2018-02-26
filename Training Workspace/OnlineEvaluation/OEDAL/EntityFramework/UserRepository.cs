using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEDAL.EntityFramework
{
    public class UserRepository:BaseRepository,IUsers
    {
        public void AddUser(OEEntity.EntityFramework.User us)
        {
            mycontext.Users.Add(us);
            mycontext.SaveChanges();
        }

        public List<OEEntity.EntityFramework.User> GetUsers()
        {
            IEnumerable<OEEntity.EntityFramework.User> result = mycontext.Users    
                                                                    .Where((us)=>us.Status==1)
                                                                    .OrderBy((us) => us.name)
                                                                    .Select((us) => us);
            return result.ToList();
        }

        public int GetScore(byte uid)
        {
            return GetByID(uid).score;
 
        }

        public OEEntity.EntityFramework.User GetByID(byte id)
        {
            OEEntity.EntityFramework.User result = (mycontext.Users
                                                    .Where((qu) => qu.uid == id && qu.Status==1)
                                                    .Select((qu) => qu)).SingleOrDefault();
            return result;
        }
        public void SetScore(byte uid,int sc)
        {
           OEEntity.EntityFramework.User result= GetByID(uid);
            result.score = sc;
            mycontext.SaveChanges();

        }


        public List<OEEntity.EntityFramework.User> GetByName(string name1)
        {
            IEnumerable<OEEntity.EntityFramework.User> result = mycontext.Users
                                                                    .Where((us) => us.Status == 1 && us.name.Contains(name1))
                                                                    .OrderBy((us) => us.name)
                                                                    .Select((us) => us);
            return result.ToList();
        }
    }
}
