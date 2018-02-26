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
    public partial class ULogin : Form
    {
        public ULogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            frmEva f1=new frmEva();
            TestManager tm=new TestManager();
            foreach (var item in tm.GetUsers())
            {
                if (item.login == textBox1.Text && item.password == textBox2.Text)
                {
                    f1.Show();
                    flag = true;
                }
            }
            if(flag==false)
            MessageBox.Show("Invalid Credentials");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewUser nu=new NewUser();
            nu.Show();
        }
    }
}
