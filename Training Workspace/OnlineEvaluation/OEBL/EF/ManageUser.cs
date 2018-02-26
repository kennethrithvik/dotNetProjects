using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OEDAL.EntityFramework;

namespace OEBL.EF
{
    public class ManageUser
    {
        private OEDAL.EntityFramework.IUsers ur;

        public ManageUser()
        {
            ur=new UserRepository();
        }
        public void AddUser(OEEntity.EntityFramework.User us)
        {
            ur.AddUser(us);
        }

        public List<OEEntity.EntityFramework.User> GetUsers()
        {
            return ur.GetUsers();
        }

        public int GetScore(byte uid)
        {
            return ur.GetScore(uid);

        }

        public OEEntity.EntityFramework.User GetByID(byte id)
        {
            return ur.GetByID(id);
        }
        public void SetScore(byte uid, int sc)
        {
            ur.SetScore(uid,sc);

        }
        public List<OEEntity.EntityFramework.User> GetByName(string name)
        {
            return ur.GetByName(name);
        }

    }
}
