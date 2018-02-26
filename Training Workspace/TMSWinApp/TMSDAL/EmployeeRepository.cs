using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TMSEntityLayer;

namespace TMSDAL
{
    public class BaseRepository
    {
        protected string MyConString;

        public BaseRepository()
        {
            MyConString = System.Configuration.ConfigurationManager.ConnectionStrings["tmscstring"].ConnectionString;
        }
    }

 
    public class EmployeeRepository:BaseRepository, IRepository<TMSEntityLayer.Employee>,IManagerRepository<TMSEntityLayer.Employee>
    {

        public List<TMSEntityLayer.Employee> GetAll()
        {
            try
            {
                SqlConnection con=new SqlConnection();
                con.ConnectionString = MyConString;
                con.Open();

                SqlCommand com=new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "GetEmployees";
                com.Connection = con;

                SqlDataReader dr = com.ExecuteReader();
                
                List<TMSEntityLayer.Employee> mylist=new List<TMSEntityLayer.Employee>();

                while (dr.Read())
                {
                    TMSEntityLayer.Employee emp = new TMSEntityLayer.Employee();
                    emp.EmployeeID = dr.GetInt32(0);   //dr.IsDBNull(0);
                    emp.Name = dr.GetString(1);
                    emp.DOB = dr.GetDateTime(2);
                    emp.DOJ = dr.GetDateTime(3);
                    emp.DepartmentName = dr.GetString(4);
                    emp.RoleName = dr.GetString(5);
                    emp.MgrID = dr.GetInt32(6);

                    mylist.Add(emp);
                }

                dr.Close();
                con.Close();
                con.Dispose();
                return mylist;

            }
            catch (SqlException ex)
            {
                
                throw new Exception("Error",ex);
            }
        }

        public TMSEntityLayer.Employee GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<TMSEntityLayer.Employee> GetByName(string nam)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = MyConString;
                con.Open();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "GetEmployeesByName";
                com.Connection = con;

                SqlParameter prm = com.Parameters.Add("@name",SqlDbType.NVarChar,50);
                prm.Direction = ParameterDirection.Input;
                prm.Value = nam;

                SqlDataReader dr = com.ExecuteReader();

                List<TMSEntityLayer.Employee> mylist = new List<TMSEntityLayer.Employee>();

                while (dr.Read())
                {
                    TMSEntityLayer.Employee emp = new TMSEntityLayer.Employee();
                    emp.EmployeeID = dr.GetInt32(0);   //dr.IsDBNull(0);
                    emp.Name = dr.GetString(1);
                    emp.DOB = dr.GetDateTime(2);
                    emp.DOJ = dr.GetDateTime(3);
                    emp.DepartmentName = dr.GetString(4);
                    emp.RoleName = dr.GetString(5);
                    emp.MgrID = dr.GetInt32(6);

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

        public void Add(TMSEntityLayer.Employee emp)
        {
            //call addemployee sp
            //pass 7 parameters
            //com.ExecuteNonQuery()
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = MyConString;
                con.Open();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "AddEmployee";
                com.Connection = con;

                SqlParameter prm = com.Parameters.Add("@name", SqlDbType.NVarChar, 30);
                prm.Direction = ParameterDirection.Input;
                prm.Value = emp.Name;

                prm = com.Parameters.Add("@dob", SqlDbType.SmallDateTime);
                prm.Direction = ParameterDirection.Input;
                prm.Value = emp.DOB;

                prm = com.Parameters.Add("@doj", SqlDbType.SmallDateTime);
                prm.Direction = ParameterDirection.Input;
                prm.Value = emp.DOJ;

                prm = com.Parameters.Add("@rid", SqlDbType.TinyInt);
                prm.Direction = ParameterDirection.Input;
                prm.Value = emp.RoleID;

                prm = com.Parameters.Add("@dpid", SqlDbType.TinyInt);
                prm.Direction = ParameterDirection.Input;
                prm.Value = emp.DepartmentID;

                prm = com.Parameters.Add("@mgrid", SqlDbType.Int);
                prm.Direction = ParameterDirection.Input;
                prm.Value = emp.MgrID;

                prm = com.Parameters.Add("@logname", SqlDbType.NVarChar, 50);
                prm.Direction = ParameterDirection.Input;
                prm.Value = emp.LoginName;

                prm = com.Parameters.Add("@pass", SqlDbType.NVarChar, 50);
                prm.Direction = ParameterDirection.Input;
                prm.Value = emp.Password;

                SqlDataReader dr = com.ExecuteReader();
                
                dr.Close();
                con.Close();
                con.Dispose();
            }
            catch (SqlException ex)
            {

                throw new Exception("Error", ex);
            }
        }

        public void Update(TMSEntityLayer.Employee emp)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public List<TMSEntityLayer.Employee> GetManagers()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = MyConString;
                con.Open();

                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "getmanagers";
                com.Connection = con;

                SqlDataReader dr = com.ExecuteReader();

                List<TMSEntityLayer.Employee> mylist = new List<TMSEntityLayer.Employee>();

                while (dr.Read())
                {
                    TMSEntityLayer.Employee emp = new TMSEntityLayer.Employee();
                    emp.EmployeeID = dr.GetInt32(0);   //dr.IsDBNull(0);
                    emp.Name = dr.GetString(1);
                   
                    mylist.Add(emp);
                }

                //Employee e1 = new Employee();
                //e1.EmployeeID = -1;
                //e1.Name = "No manager";
                //mylist.Add(e1);

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
    }
}
