using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OEBL;
using OEBL.EF;
using OEEntity.EntityFramework;

namespace OEWebApp
{
    public partial class TestPage : System.Web.UI.Page
    {
        private OEBL.EF.ManageTest mt=new OEBL.EF.ManageTest();
        //private List<Label> listl;

        private static List<CheckBox> listchk = new List<CheckBox>();
        private List<OEEntity.EntityFramework.Question> listq;
        private static List<OEEntity.EntityFramework.Question> result;
        private static int c = -1;
        private int qc ;
        static CheckBox cb;
      

 
        protected void Page_Load(object sender, EventArgs e)
        {
            listq = mt.GetAll();
            qc = listq.Count;
            

            
            if (!Page.IsPostBack)
            {
                result = new List<OEEntity.EntityFramework.Question>();
                OEEntity.EntityFramework.Question q;
                for (int i = 0; i < qc; i++)
                {
                    q = new Question();
                    q.Options1 = listq[i].Options1;
                    q.name = listq[i].name;
                    q.marks = listq[i].marks;
                    q.qid = listq[i].qid;
                    result.Add(q);
                }
                DispalyQues();
            }
        }

        protected void DispalyQues()
        {
            
            c++;
            btnPrev.Visible = true;
            if (c <= 0)
            {
                c = 0;
                btnPrev.Visible = false;
            }
            //lblQues.Style.Add(HtmlTextWriterStyle.FontSize,"20");
            
          
            result[c].Options=new List<OEEntity.EntityFramework.Option>();

            lblQues.ForeColor = Color.Red;
            lblQues.Text = listq[c].qid + ". " + listq[c].name + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                                                                  + listq[c].marks + " marks";
            foreach (var item in listq[c].Options)
            {
                cb=new CheckBox();
                cb.Text = item.name;
                cb.ID = item.oid.ToString();
                cb.AutoPostBack = false;
                cb.ViewStateMode=ViewStateMode.Enabled;
                cb.EnableViewState = true;
                pnlOP.Controls.Add(cb);
                pnlOP.Controls.Add(new LiteralControl("<br />"));
                pnlOP.Controls.Add(new LiteralControl("<br />"));
                listchk.Add(cb);
            }          
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (c >= qc - 1)
            {
                foreach (var item in listchk)
                {

                    if (item.Checked)
                    {
                        result[c].Options.Add(mt.GetOptionByID(Convert.ToByte(item.ID)));
                    }
                }
                Label lblRes = new Label();
                lblRes.Style.Add(HtmlTextWriterStyle.FontSize, "20");
                lblRes.ForeColor = Color.Red;
                string tmp=mt.GetReport(result);
                lblRes.Text = tmp.Replace("\n", "<br/>");
                pnlOP.Controls.Add(lblRes);
                lblQues.Visible = false;
                btnNext.Visible = false;
                btnPrev.Visible = false;

            }
            else
            {
                
                foreach (var item in listchk)
                {
                    //if (item.Text.Equals("New Delhi")) item.Checked = true;

                    if (Request.Form[item.UniqueID]!=null)
                    {
                        result[c].Options.Add(mt.GetOptionByID(Convert.ToByte(item.ID)));
                    }
                }
                listchk = new List<CheckBox>();
                DispalyQues();
            }
            
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            c -= 2;
            DispalyQues();
        }
    }
}