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
    public partial class TMSMain : Form
    {
        public TMSMain()
        {
            InitializeComponent();
        }

        private void TMSMain_Load(object sender, EventArgs e)
        {

            //TMSLogin log=new TMSLogin();
            //log.ShowDialog();
            //label1.Text = "Welcome " + TMSGlobal.UserName;
            adminToolStripMenuItem.Visible = true;
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewEmployees ve=new ViewEmployees();
            ve.MdiParent = this;
            ve.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewEmployee ne = new NewEmployee();
            ne.MdiParent = this;
            ne.Show();
        }
    }
}
