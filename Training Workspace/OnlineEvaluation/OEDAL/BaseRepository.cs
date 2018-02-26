using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OEDAL
{
    public class BaseRepository
    {
        protected string MyConString;

        public BaseRepository()
        {
            MyConString = System.Configuration.ConfigurationManager.ConnectionStrings["oecstring"].ConnectionString;
        }
    }
}
