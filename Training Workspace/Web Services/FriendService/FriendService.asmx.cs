using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;

namespace FriendService
{
    /// <summary>
    /// Summary description for FriendService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class FriendService : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet FriendInfo()
        {
            DataSet friendset = new DataSet();
            string connectionstring = ConfigurationManager.ConnectionStrings["Friend"].ConnectionString;

            string sql = "Select * from FriendInfo";
            SqlDataAdapter da = new SqlDataAdapter(sql, connectionstring);
            da.Fill(friendset);
            return friendset;


        }
        [WebMethod]
        public String[] GetFriendList(string prefixText)
        {
            return FriendData.GetData(prefixText);
            
        }
    }
}
