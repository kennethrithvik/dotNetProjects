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
using OEEntity;

namespace OEWF
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            TestManager tm=new TestManager();
            OEEntity.User us = new OEEntity.User();
            us.name = txtLName.Text;
            us.login = txtLName.Text;
            us.password = txtPass.Text;
            tm.AddUser(us);
            MessageBox.Show("User Added");
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            TestManager tm=new TestManager();
            dataGridView1.DataSource = tm.GetUsers();
        }

        private void btnQues_Click(object sender, EventArgs e)
        {
            TestManager tm=new TestManager();
            OEEntity.Question q=new Question();q.options=new List<Option>();q.coptions=new List<Option>();
            OEEntity.Option op;
            q.question = txtQues.Text;
            q.marks = byte.Parse(txtMarks.Text);
            string[] ops = txtOption.Text.Split(',');
            string[] cops = txtCOptions.Text.Split(',');
            for(int i=0;i<ops.Length;i++)
            {
                op= new Option();
                op.option = ops[i];
                q.options.Add(op);
                foreach (var item in cops)
                {
                    byte dx=Byte.Parse(item);
                    if((dx-1)==i)
                        q.coptions.Add(op);
                    
                }
            }

            tm.AddQuestion(q);
            MessageBox.Show("Question added");

        }
    }
}
