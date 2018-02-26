using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMSWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string company;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text += "<br>Page Load fired";
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            lblMessage.Text += "<br>Page Init fired";
            company = "Tesco";
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            lblMessage.Text += "<br>Page PreRender fired";
        }

        protected void txtName_Init(object sender, EventArgs e)
        {
            lblMessage.Text += "<br>Textbox init fired";
        }

        protected void lblName_Init(object sender, EventArgs e)
        {
            lblMessage.Text += "<br>Name label init fired";
        }

        protected void txtName_Load(object sender, EventArgs e)
        {
            lblMessage.Text += "<br>Textbox load fired";
        }

        protected void txtName_PreRender(object sender, EventArgs e)
        {
            lblMessage.Text += "<br>Textbox prerender fired";
        }

        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text += "<br>Textbox TextChanged fired";
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            //lblMessage.Text += "<br>Welcome" + this.Request.Form["txtName"];
            lblMessage.Text += "<font color='blue' size='4'><br>Welcome "+txtName.Text+@"</font>";
            lblMessage.Text += "<font color='red'><br> The Day is " + DropDownList1.SelectedItem.Text + @"</font>";
        }

        protected void DropDownList1_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                for (int i = 0; i < 10; i++)
                {
                    DropDownList1.Items.Add(new ListItem("Item " + (i + 1).ToString(), (i + 10).ToString()));
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text += "<font color='red'><br> Dropdown changeIndex fired "+ @"</font>";
        }
    }
}