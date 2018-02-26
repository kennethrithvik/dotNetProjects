namespace OEWF
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.btnUser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQues = new System.Windows.Forms.TextBox();
            this.txtOption = new System.Windows.Forms.TextBox();
            this.btnQues = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCOptions = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMarks = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAd.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAd.Location = new System.Drawing.Point(409, 9);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(119, 25);
            this.lblAd.TabIndex = 1;
            this.lblAd.Text = "Admin Page";
            this.lblAd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Login Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(163, 119);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 5;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(163, 224);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(100, 20);
            this.txtPass.TabIndex = 6;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(163, 168);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(100, 20);
            this.txtLName.TabIndex = 7;
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(101, 313);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(75, 23);
            this.btnUser.TabIndex = 8;
            this.btnUser.Text = "Create User";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "New Question";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(457, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Options Seperated by Commas";
            // 
            // txtQues
            // 
            this.txtQues.Location = new System.Drawing.Point(676, 118);
            this.txtQues.Name = "txtQues";
            this.txtQues.Size = new System.Drawing.Size(100, 20);
            this.txtQues.TabIndex = 11;
            // 
            // txtOption
            // 
            this.txtOption.Location = new System.Drawing.Point(676, 165);
            this.txtOption.Multiline = true;
            this.txtOption.Name = "txtOption";
            this.txtOption.Size = new System.Drawing.Size(170, 93);
            this.txtOption.TabIndex = 12;
            // 
            // btnQues
            // 
            this.btnQues.Location = new System.Drawing.Point(652, 371);
            this.btnQues.Name = "btnQues";
            this.btnQues.Size = new System.Drawing.Size(86, 41);
            this.btnQues.TabIndex = 13;
            this.btnQues.Text = "Create Question";
            this.btnQues.UseVisualStyleBackColor = true;
            this.btnQues.Click += new System.EventHandler(this.btnQues_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 371);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 251);
            this.dataGridView1.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(391, 355);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "List of Users";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(457, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = " Correct Option no Seperated by Commas";
            // 
            // txtCOptions
            // 
            this.txtCOptions.Location = new System.Drawing.Point(676, 329);
            this.txtCOptions.Name = "txtCOptions";
            this.txtCOptions.Size = new System.Drawing.Size(100, 20);
            this.txtCOptions.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(457, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = " Marks";
            // 
            // txtMarks
            // 
            this.txtMarks.Location = new System.Drawing.Point(676, 282);
            this.txtMarks.Name = "txtMarks";
            this.txtMarks.Size = new System.Drawing.Size(100, 20);
            this.txtMarks.TabIndex = 19;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 634);
            this.Controls.Add(this.txtMarks);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCOptions);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnQues);
            this.Controls.Add(this.txtOption);
            this.Controls.Add(this.txtQues);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAd);
            this.Name = "Admin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQues;
        private System.Windows.Forms.TextBox txtOption;
        private System.Windows.Forms.Button btnQues;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCOptions;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMarks;
    }
}