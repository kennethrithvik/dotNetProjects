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
    public partial class frmEva : Form
    {
        private List<CheckBox> customChecks;
        private List<OEEntity.Question> reslist;
        DataGridView dgv = new DataGridView();
        private int dp;
        public frmEva()
        {
            InitializeComponent();
        }

        private void frmEva_Load(object sender, EventArgs e)
        {
            OEBL.TestManager tm = new TestManager();
            List<OEEntity.Question> ques = tm.GetQuestions();
            reslist = new List<Question>();
            customChecks = new List<CheckBox>();
            OEEntity.Question res;
            
            //dataGridView1.DataSource = ques;
            //DataGridViewCheckBoxColumn cbxc=new DataGridViewCheckBoxColumn();
            ////DataGridView
            //cbxc.
            ////cbxc.Text = "Edit";
            //dataGridView1.Columns.Add(cbxc);

            dp = 100;
            List<Label> customLabels = new List<Label>();
            foreach (OEEntity.Question item in ques)
            {
                res = new OEEntity.Question();
                res.question = item.question;
                res.qid = item.qid;
                res.marks = item.marks;
                res.options = new List<OEEntity.Option>();
                res.coptions = new List<Option>(); res.options = new List<Option>();
                foreach (OEEntity.Option cop in item.coptions)
                {
                    res.coptions.Add(cop);
                }
                

                Label label2 = new Label();
                label2.Location = new System.Drawing.Point(500, dp);
                label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label2.Name = item.qid.ToString();
                label2.Text = item.qid+". "+item.question + "                     (" + item.marks + ") marks";
                label2.Size = new System.Drawing.Size(700, 25);
                customLabels.Add(label2);
                Controls.Add(label2);

                dp += 30;
                foreach (OEEntity.Option op in item.options)
                {
                    CheckBox dynamicCheckBox=new CheckBox();
                    dynamicCheckBox.Left = 20;
                    dynamicCheckBox.Top = 20;
                    dynamicCheckBox.Width = 300;
                    dynamicCheckBox.Height = 30;

                    // Set background and foreground
                    //dynamicCheckBox.BackColor = Color.Orange;
                    dynamicCheckBox.ForeColor = Color.Brown;

                    dynamicCheckBox.Text = op.option;
                    dynamicCheckBox.Name = item.qid+","+op.oid;
                    dynamicCheckBox.Location = new System.Drawing.Point(530,dp);
                    dynamicCheckBox.Size = new System.Drawing.Size(700, 25);
                    dynamicCheckBox.Font = new Font("Georgia", 12);
                    customChecks.Add(dynamicCheckBox);
                    Controls.Add(dynamicCheckBox);

                    dp += 30;
                }
                dp += 50;
                reslist.Add(res);
            }

            Button bn=new Button();
            bn.Location = new System.Drawing.Point(650, dp);
            bn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            bn.Name = "btnSubmit";
            bn.Text = "Submit";
            bn.Size = new System.Drawing.Size(100, 25);
            bn.Click += new System.EventHandler(this.bn_Click);
            Controls.Add(bn);


        }

        private void bn_Click(object sender, EventArgs e)
        {
            string[] ans=new string[2];
            byte qid1, oid1;
            Option op;
            OEBL.TestManager tm = new TestManager();
            foreach (var item1 in reslist)
            {
               item1.options=new List<Option>();
            }

            foreach (CheckBox item in customChecks)
            {

                if (item.Checked)
                {
                    ans = item.Name.Split(',');
                    qid1 = byte.Parse(ans[0]);
                    oid1 = byte.Parse(ans[1]);
                    foreach (var item1 in reslist)
                    {
                        //item1.options = new List<Option>();
                        if (item1.qid == qid1)
                        {
                            op=new Option();
                            op.oid = oid1;
                            op.option = item.Text;
                            item1.options.Add(op);
                        }
                    }

                }
            }

            MessageBox.Show(tm.GetReport(reslist));
           

        }
    
    
    }
}
