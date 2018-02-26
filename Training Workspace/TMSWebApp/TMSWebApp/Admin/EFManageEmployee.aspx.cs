using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMSWebApp.Admin
{
    public partial class EFManageEmployee : System.Web.UI.Page
    {
        private TMSBL.EF.EFManageEmployee me;
        protected void Page_Load(object sender, EventArgs e)
        {
            me=new TMSBL.EF.EFManageEmployee();
            
        }

        protected void GridView1_Load(object sender, EventArgs e)
        {
            List<TMSEntityLayer.EF.Employee> elist = me.GetEmployees();
            //GridView1.DataSource = me.GetEmployees();
            var newempdata = from em in elist
                            select new
                            {
                                EmployeeID = em.EmployeeID,
                                Name = em.Name,
                                DOB = em.DOB,
                                Department = em.Department.Name,
                                Role = em.Role.Name
                                //Manager=em.Manager.Name
                            };

            GridView1.DataSource = newempdata;
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<TMSEntityLayer.EF.Employee> elist = me.GetEmpByName(txtName.Text);
            //GridView1.DataSource = me.GetEmployees();
            var newempdata = from em in elist
                             select new
                             {
                                 EmployeeID = em.EmployeeID,
                                 Name = em.Name,
                                 DOB = em.DOB,
                                 Department = em.Department.Name,
                                 Role = em.Role.Name,
                                 //Manager=em.Manager.Name
                             };

            GridView1.DataSource = newempdata;
            GridView1.DataBind();
        }
    }
}