using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSEntityLayer.EF;

namespace TMSWebApp.Admin
{
    public partial class AddTraining : System.Web.UI.Page
    {
        private TMSBL.EF.EFManageTraining mtr;
        protected void Page_Load(object sender, EventArgs e)
        {
            mtr = new TMSBL.EF.EFManageTraining();
            if (!Page.IsPostBack)
            {
                ddlDomain.DataSource = mtr.GetDomains();
                ddlDomain.DataTextField = "Name";
                ddlDomain.DataValueField = "DomainID";
                ddlDomain.DataBind();
                ddlDomain.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            TMSEntityLayer.EF.Training tr=new Training();
            tr.StartDate = Convert.ToDateTime(txtSD.Text);
            tr.EndDate = Convert.ToDateTime(txtED.Text);
            //var n = ;
            tr.DomainID = Convert.ToByte(ddlDomain.SelectedItem.Value);
            tr.Title = txtName.Text;
            tr.Credits = byte.Parse(txtCredits.Text);
            tr.Status = 1;
            mtr.Add(tr);
            Server.TransferRequest("~/Admin/EFManageTraining.aspx");
        }
    }
}