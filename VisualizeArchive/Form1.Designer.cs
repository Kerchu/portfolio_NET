namespace VisualizeArchive
{
    partial class Form1
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
            this.btnSeeArch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSeeArch
            // 
            this.btnSeeArch.Location = new System.Drawing.Point(24, 12);
            this.btnSeeArch.Name = "btnSeeArch";
            this.btnSeeArch.Size = new System.Drawing.Size(106, 23);
            this.btnSeeArch.TabIndex = 0;
            this.btnSeeArch.Text = "Open Archive";
            this.btnSeeArch.UseVisualStyleBackColor = true;
            this.btnSeeArch.Click += new System.EventHandler(this.btnSeeArch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(155, 52);
            this.Controls.Add(this.btnSeeArch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSeeArch;
    }
}

