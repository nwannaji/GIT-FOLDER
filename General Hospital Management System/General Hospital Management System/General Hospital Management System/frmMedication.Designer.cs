namespace General_Hospital_Management_System
{
    partial class frmMedication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedication));
            this.tbMedication = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbMedication
            // 
            this.tbMedication.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbMedication.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMedication.Location = new System.Drawing.Point(13, 8);
            this.tbMedication.Multiline = true;
            this.tbMedication.Name = "tbMedication";
            this.tbMedication.Size = new System.Drawing.Size(433, 190);
            this.tbMedication.TabIndex = 0;
            // 
            // frmMedication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(459, 205);
            this.Controls.Add(this.tbMedication);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMedication";
            this.Text = "Patient Medication History    GHMS.";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbMedication;
    }
}