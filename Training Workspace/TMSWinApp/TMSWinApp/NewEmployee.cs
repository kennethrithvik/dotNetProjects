using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMSWinApp
{
    public partial class NewEmployee : TMSWinApp.TMSTemplate
    {
        private TMSBL.ManageEmployee manageEmp;
        private TMSBL.DisconnectedManageEmployee.DisconnectedManageEmployee disconnectedEmp;
        public NewEmployee()
        {
            InitializeComponent();
        }

        private void NewEmployee_Load(object sender, EventArgs e)
        {
            manageEmp = new TMSBL.ManageEmployee();
            disconnectedEmp = new TMSBL.DisconnectedManageEmployee.DisconnectedManageEmployee();

            TMSEntityLayer.ViewModels.EditEmployeeViewModel vm = manageEmp.PrepareInsert();
            comboBox1.DataSource = vm.Departments;
            comboBox1.DisplayMember = "Name";
            comboBox2.DataSource = vm.Roles;
            comboBox2.DisplayMember = "Name";

            comboBox3.DataSource = manageEmp.GetManagers();
            comboBox3.DisplayMember = "Name";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TMSEntityLayer.Employee emp = new TMSEntityLayer.Employee();
            emp.Name = textBox1.Text;
            emp.DOB = dateTimePicker1.Value;
            emp.DOJ = dateTimePicker2.Value;

            TMSEntityLayer.Department dept = comboBox1.SelectedItem as TMSEntityLayer.Department;
            emp.DepartmentID = dept.DepartmentID;

            //collect roleid
            TMSEntityLayer.Role role = comboBox2.SelectedItem as TMSEntityLayer.Role;
            emp.RoleID = role.RoleID;

            //collect mrgid
            TMSEntityLayer.Employee manager = comboBox3.SelectedItem as TMSEntityLayer.Employee;
            emp.MgrID = manager.EmployeeID;

            emp.LoginName = textBox2.Text;
            emp.Password = textBox3.Text;

            //TMSBL.add() --> TMSDAL.Add()
            //manageEmp = new TMSBL.ManageEmployee();
            //manageEmp.AddEmployee(emp);

            disconnectedEmp.Add(emp);

            MessageBox.Show("Employee Added");
            this.Close();
        }
    }
}
