using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace FriendService
{
    public class FriendData
    {
        public static String[] GetData(string prefixtext)
        {
            if(prefixtext == null || prefixtext.Length == 0)
            {
                return null;
            }
            SqlConnection con = null;
            

            DataSet friendset = new DataSet();
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["Friend"].ToString());
                con.Open();
                string sql = "SELECT FriendName from FriendInfo where FriendNAme Like @prefixtext";

                SqlDataAdapter da = new SqlDataAdapter(sql,con);
                da.SelectCommand.Parameters.AddWithValue("@prefixtext",prefixtext + "%");
                da.Fill(friendset);

                //var myData = friendset.Tables[0].AsEnumerable().Select(r => new Friend
                //{
                //    FriendName = r.Field<string>("FriendName"),
                //    PhoneNumber = r.Field<int>("PhoneNumber"),
                //    EmailId = r.Field<string>("EmailId")

                //});
                // list = myData.ToList();
                // return list;
                String[] result = new String[friendset.Tables[0].Rows.Count];
                int i = 0;
                foreach (DataTable item in friendset.Tables)
                {
                    foreach(DataRow item1 in item.Rows)
                    {
                        result[i] = item1["FriendName"].ToString();
                        i++;
                    }
                }
                return result;
              }
            catch(SqlException ex)
            {
                throw;
            }
           }
            
            
        }
    }
