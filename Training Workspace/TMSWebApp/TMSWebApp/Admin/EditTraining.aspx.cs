using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSEntityLayer.EF;

namespace TMSWebApp.Admin
{
    public partial class EditTraining : System.Web.UI.Page
    {
        private TMSBL.EF.EFManageTraining mtr;
        private byte tid;
        protected void Page_Load(object sender, EventArgs e)
        {
            string tid1 = Request.QueryString["tid"];
             tid= Convert.ToByte(tid1);
            mtr = new TMSBL.EF.EFManageTraining();
            TMSEntityLayer.EF.Training tr = mtr.GetByID(tid);
            if (!Page.IsPostBack)
            {
                txtName.Text = tr.Title;
                txtSD.Text = tr.StartDate.ToShortDateString();
                txtED.Text = tr.EndDate.ToShortDateString();
                txtCredits.Text = tr.Credits.ToString();
                ddlDomain.DataSource = mtr.GetDomains();
                ddlDomain.DataTextField = "Name";
                ddlDomain.DataValueField = "DomainID";
                ddlDomain.DataBind();
                ddlDomain.SelectedIndex = ddlDomain.Items.IndexOf(ddlDomain.Items.FindByValue(tr.DomainID.ToString()));
                ddlDomain.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

       
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            TMSEntityLayer.EF.Training tr = new Training();
            tr.TrainingID = tid;
            tr.StartDate = Convert.ToDateTime(txtSD.Text);
            tr.EndDate = Convert.ToDateTime(txtED.Text);
            //var n = ;
            tr.DomainID = Convert.ToByte(ddlDomain.SelectedItem.Value);
            tr.Title = txtName.Text;
            tr.Credits = byte.Parse(txtCredits.Text);
            tr.Status = 1;
            mtr.Update(tr);
            Server.TransferRequest("~/Admin/EFManageTraining.aspx");
        }
    }
}