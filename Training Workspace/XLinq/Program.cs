using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace XLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(@"..\..\tms.xml");
            IEnumerable<XElement> alldepts = doc.Descendants("Department");
            IEnumerable<XElement> allemps = doc.Descendants("Employee");
            var result = from XElement dept in alldepts
                        join XElement emp in allemps
                        on dept.Element("DepartmentID").Value equals emp.Element("DepartmentID").Value
                        orderby emp.Element("Name").Value descending 
                        select new
                        {
                            name = emp.Element("Name").Value,
                            DOB = DateTime.Parse(emp.Element("DOB").Value),
                            DeptName = dept.Element("Name").Value
                        };
            foreach (var item in result)
            {
                Console.WriteLine("{0,-10}{1,-15}{2,-10}",item.name,item.DOB.ToShortDateString(),item.DeptName);
            }










            //GetData();
            Console.ReadLine();
        }

        static void GetData()
        {
            string cs = @"data source=.;database=TrainingManagement;integrated security=true";
            DataSet ds=new DataSet("TMS");
            SqlConnection con=new SqlConnection();
            con.ConnectionString = cs;

            SqlDataAdapter da1, da2;
            da1=new SqlDataAdapter("Select * from Department",con);
            da1.Fill(ds, "Department");
            da2 = new SqlDataAdapter("Select * from Employee", con);
            da2.Fill(ds, "Employee");

            ds.WriteXml(@"..\..\tms.xml");
        }
    }
}
