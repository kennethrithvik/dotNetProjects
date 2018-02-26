using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OEBL.EF;

namespace OEWebApp.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        private OEBL.EF.ManageUser mu;
        protected void Page_Load(object sender, EventArgs e)
        {
            mu = new ManageUser();
            if (!Page.IsPostBack)
            {
                
            }
        }

        protected void GridView1_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                GridView1.DataSource = mu.GetUsers();
                GridView1.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {           
            GridView1.DataSource = mu.GetByName(txtName.Text);
            GridView1.DataBind();
        }
    }
}