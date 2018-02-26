using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMSWinApp
{
    public partial class TMSLogin : Form
    {
        public TMSLogin()
        {
            InitializeComponent();
        }

        private void TMSLogin_Load(object sender, EventArgs e)
        {

        }

        private void TMSLogin_Activated(object sender, EventArgs e)
        {

        }

        private void TMSLogin_Deactivate(object sender, EventArgs e)
        {

        }

        private void TMSLogin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void TMSLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.ToLower() == "admin" && txtPassword.Text == "admin")
            {
                TMSGlobal.UserName = txtUserName.Text.ToLower();
                TMSGlobal.RoleID = 1;
                this.Close();
            }
        }

       
    }
}
