using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSEntityLayer;

namespace TMSWebApp.Admin
{
    public partial class ManageEmployee : System.Web.UI.Page
    {
        private TMSBL.ManageEmployee manageEmp;
        private TMSBL.DisconnectedManageEmployee.DisconnectedManageEmployee dme;
        protected void Page_Load(object sender, EventArgs e)
        {
            manageEmp=new TMSBL.ManageEmployee();
        }

        protected void GridView1_Load(object sender, EventArgs e)
        {
            List<TMSEntityLayer.Employee> lstEmp = manageEmp.GetEmployees();
            GridView1.DataSource = lstEmp;
            GridView1.DataBind();
        }
    }
}