namespace General_Hospital_Management_System
{
    partial class FrmAddNewDepartment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddNewDepartment));
            this.tbAddNewDept = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewDept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbAddNewDept
            // 
            this.tbAddNewDept.BackColor = System.Drawing.Color.White;
            this.tbAddNewDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddNewDept.Location = new System.Drawing.Point(144, 38);
            this.tbAddNewDept.Name = "tbAddNewDept";
            this.tbAddNewDept.Size = new System.Drawing.Size(242, 26);
            this.tbAddNewDept.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Depatment";
            // 
            // btnNewDept
            // 
            this.btnNewDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnNewDept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNewDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewDept.Location = new System.Drawing.Point(295, 94);
            this.btnNewDept.Name = "btnNewDept";
            this.btnNewDept.Size = new System.Drawing.Size(89, 38);
            this.btnNewDept.TabIndex = 2;
            this.btnNewDept.Text = "Save";
            this.btnNewDept.UseVisualStyleBackColor = false;
            this.btnNewDept.Click += new System.EventHandler(this.btnNewDept_Click);
            // 
            // FrmAddNewDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(426, 144);
            this.Controls.Add(this.btnNewDept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAddNewDept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAddNewDepartment";
            this.Text = "AddNewDepartment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAddNewDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewDept;
    }
}