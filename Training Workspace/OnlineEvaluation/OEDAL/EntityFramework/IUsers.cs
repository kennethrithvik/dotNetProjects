using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEDAL.EntityFramework
{
    public interface IUsers
    {
        void AddUser(OEEntity.EntityFramework.User us);
        List<OEEntity.EntityFramework.User> GetUsers();
        int GetScore(byte uid);

        OEEntity.EntityFramework.User GetByID(byte id);

        void SetScore(byte uid, int sc);

        List<OEEntity.EntityFramework.User> GetByName(string name);

    }
}
