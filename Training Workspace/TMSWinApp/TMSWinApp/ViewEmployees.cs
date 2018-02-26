using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TMSBL;

namespace TMSWinApp
{
    public partial class ViewEmployees : TMSWinApp.TMSTemplate
    {
        private TMSBL.ManageEmployee manageEmp;
        private TMSBL.DisconnectedManageEmployee.DisconnectedManageEmployee disconnectedEmp;
        public ViewEmployees()
        {
            InitializeComponent();
        }

        private void ViewEmployees_Load(object sender, EventArgs e)
        {
            manageEmp=new ManageEmployee();

            disconnectedEmp = new TMSBL.DisconnectedManageEmployee.DisconnectedManageEmployee();
            dataGridView1.DataSource = disconnectedEmp.GetEmployees();

            //List<TMSEntityLayer.Employee> mylist = manageEmp.GetEmployees();
            //dataGridView1.DataSource = mylist;

            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;

            DataGridViewButtonColumn btnedit=new DataGridViewButtonColumn();
            btnedit.UseColumnTextForButtonValue = true;
            btnedit.Text = "Edit";
            dataGridView1.Columns.Add(btnedit);
            btnedit.DisplayIndex = 0;

            DataGridViewButtonColumn btndel = new DataGridViewButtonColumn();
            btndel.UseColumnTextForButtonValue = true;
            btndel.Text = "Delete";
            dataGridView1.Columns.Add(btndel);
            btndel.DisplayIndex = 1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            disconnectedEmp=new TMSBL.DisconnectedManageEmployee.DisconnectedManageEmployee();
            int empid = (int) dataGridView1.Rows[e.RowIndex].Cells[2].Value;
            //MessageBox.Show(empid.ToString());
            if (e.ColumnIndex == 0)
            {
                //edit of the row
                //show edit dialog
                //fill it up with employee detail of employee id
                //user click save call update on repository


                EditEmployee ee=new EditEmployee(empid);
                //ee.MdiParent = this;
                ee.Show();
            }
            else if (e.ColumnIndex == 1)
            {
                //delete of the row
                DialogResult dialogResult = MessageBox.Show("Delete " + dataGridView1.Rows[e.RowIndex].Cells[3].Value,"", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    disconnectedEmp.Delete(empid);
                    
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = manageEmp.GetEmployeesByName(textBox1.Text);
        }
    }
}
