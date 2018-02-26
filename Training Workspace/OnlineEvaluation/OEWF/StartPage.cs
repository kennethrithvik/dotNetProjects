using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OEWF
{
    public partial class frmSPage : Form
    {
        public frmSPage()
        {
            InitializeComponent();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            ULogin f2 = new ULogin();
            //f2.MdiParent = this;
            f2.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Admin f3 = new Admin();
            //f2.MdiParent = this;
            f3.Show();
        }
    }
}
