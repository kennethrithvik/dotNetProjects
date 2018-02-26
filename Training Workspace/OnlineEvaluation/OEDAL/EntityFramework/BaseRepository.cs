using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OEEntity.EntityFramework;

namespace OEDAL.EntityFramework
{
    public class BaseRepository
    {
        protected OEEntity.EntityFramework.OnlineTestEntities1 mycontext;

        public BaseRepository()
        {
            mycontext=new OnlineTestEntities1();
        }
    }
}
