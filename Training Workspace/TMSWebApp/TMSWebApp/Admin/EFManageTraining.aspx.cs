using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSEntityLayer.EF;

namespace TMSWebApp.Admin
{
    public partial class EFManageTraining : System.Web.UI.Page
    {
        private TMSBL.EF.EFManageTraining mtr;
            
        protected void Page_Load(object sender, EventArgs e)
        {
            mtr=new TMSBL.EF.EFManageTraining();
            
        }

        protected void GridView1_Load(object sender, EventArgs e)
        {
            List<TMSEntityLayer.EF.Training> tlist = mtr.GetAll();
            if (!IsPostBack)
            {
                gridDisplay(tlist);
            }
        }

        protected void chkName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkName.Checked)
            {
                Panel1.Visible = true;
                btnSearch.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
                if (!Panel2.Visible)
                    btnSearch.Visible = false;
            }
        }

        protected void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
            {
                Panel2.Visible = true;
                btnSearch.Visible = true;
            }
            else
            {
                Panel2.Visible = false;
                if (!Panel1.Visible)
                    btnSearch.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<TMSEntityLayer.EF.Training> tlist=new List<Training>();
            
            if (Panel1.Visible && !Panel2.Visible)
                tlist=mtr.GetByName(txtName.Text);

            else if (!Panel1.Visible && Panel2.Visible)
                tlist=mtr.GetByDate(Convert.ToDateTime(txtSd.Text), Convert.ToDateTime(txtED.Text));

            else if(Panel1.Visible && Panel2.Visible)
                tlist=mtr.GetByDateName(txtName.Text,Convert.ToDateTime(txtSd.Text), Convert.ToDateTime(txtED.Text));

            gridDisplay(tlist);

        }

        protected void gridDisplay(List<TMSEntityLayer.EF.Training> tlist)
        {
            var newtrdata = from tr in tlist
                            select new
                            {
                                TrainingID = tr.TrainingID,
                                Training = tr.Title,
                                StartDate = tr.StartDate,
                                EndDate = tr.EndDate,
                                Domain = tr.Domain.Name,
                                Credits = tr.Credits

                            };

            GridView1.DataSource = newtrdata;
            GridView1.DataBind();
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //editing
            if (e.CommandName.Equals("edt"))
            {
                Server.TransferRequest("~/Admin/EditTraining.aspx?tid="+e.CommandArgument);
            }

            //Delete
            if (e.CommandName.Equals("del"))
            {
                int id = int.Parse(e.CommandArgument.ToString());
                int a = 2;
                mtr.Delete(id);
                List<TMSEntityLayer.EF.Training> tlist = mtr.GetAll();
                gridDisplay(tlist);
            }
        }
    }
}