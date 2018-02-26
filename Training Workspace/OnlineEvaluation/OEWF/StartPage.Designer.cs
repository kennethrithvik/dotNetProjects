namespace OEWF
{
    partial class frmSPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(129, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Test Management System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(348, 183);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(131, 104);
            this.btnUser.TabIndex = 1;
            this.btnUser.Text = "User";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(32, 183);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(135, 104);
            this.btnAdmin.TabIndex = 2;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // frmSPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 418);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.label1);
            this.Name = "frmSPage";
            this.Text = "StartPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnAdmin;
    }
}