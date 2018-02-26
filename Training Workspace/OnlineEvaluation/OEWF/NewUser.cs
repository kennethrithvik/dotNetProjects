using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OEBL;

namespace OEWF
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            TestManager tm = new TestManager();
            OEEntity.User us = new OEEntity.User();
            us.name = txtLName.Text;
            us.login = txtLName.Text;
            us.password = txtPass.Text;
            tm.AddUser(us);
            MessageBox.Show("User Added");
            this.Close();
        }
    }
}
