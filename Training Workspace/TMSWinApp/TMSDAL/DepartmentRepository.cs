using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TMSDAL
{
    public class DepartmentRepository:BaseRepository,IRepository<TMSEntityLayer.Department>
    {
        public List<TMSEntityLayer.Department> GetAll()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = MyConString;
                con.Open();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.Text;
                com.CommandText = "Select DepartmentID,name from department";
                com.Connection = con;

                SqlDataReader dr = com.ExecuteReader();

                List<TMSEntityLayer.Department> mylist = new List<TMSEntityLayer.Department>();

                while (dr.Read())
                {
                    TMSEntityLayer.Department emp = new TMSEntityLayer.Department();
                    emp.DepartmentID = dr.GetByte(0);   //dr.IsDBNull(0);
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

        public TMSEntityLayer.Department GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<TMSEntityLayer.Department> GetByName(string nam)
        {
            throw new NotImplementedException();
        }

        public void Add(TMSEntityLayer.Department emp)
        {
            throw new NotImplementedException();
        }

        public void Update(TMSEntityLayer.Department emp)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
