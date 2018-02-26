using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TMSDAL
{
    public class RoleRepository:BaseRepository,IRepository<TMSEntityLayer.Role>
    {
        public List<TMSEntityLayer.Role> GetAll()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = MyConString;
                con.Open();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.Text;
                com.CommandText = "Select RoleID,name from role";
                com.Connection = con;

                SqlDataReader dr = com.ExecuteReader();

                List<TMSEntityLayer.Role> mylist = new List<TMSEntityLayer.Role>();

                while (dr.Read())
                {
                    TMSEntityLayer.Role emp = new TMSEntityLayer.Role();
                    emp.RoleID = dr.GetByte(0);   //dr.IsDBNull(0);
                    emp.Name = dr.GetString(1);


                    mylist.Add(emp);
                }

                dr.Close();
                con.Close();
                con.Dispose();
                return mylist;

            }
            catch (SqlException ex)
            {

                throw new Exception("Error", ex);
            }
        }

        public TMSEntityLayer.Role GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<TMSEntityLayer.Role> GetByName(string nam)
        {
            throw new NotImplementedException();
        }

        public void Add(TMSEntityLayer.Role emp)
        {
            throw new NotImplementedException();
        }

        public void Update(TMSEntityLayer.Role emp)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
