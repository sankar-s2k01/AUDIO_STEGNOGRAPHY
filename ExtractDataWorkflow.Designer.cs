namespace AUDIO_STEGNOGRAPHY
{
    partial class ExtractDataWorkflow
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblFilePath;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Showcard Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTitle.Location = new System.Drawing.Point(150, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(331, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Extract Hidden Data";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Location = new System.Drawing.Point(20, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(560, 300);
            this.panelContent.TabIndex = 1;
            // 
            // btnExtract
            // 
            this.btnExtract.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExtract.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExtract.ForeColor = System.Drawing.Color.White;
            this.btnExtract.Location = new System.Drawing.Point(400, 400);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(150, 40);
            this.btnExtract.TabIndex = 2;
            this.btnExtract.Text = "Extract";
            this.btnExtract.UseVisualStyleBackColor = false;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.White;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnBrowse.Location = new System.Drawing.Point(20, 400);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(150, 40);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse File";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(200, 350);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 30);
            this.txtPassword.TabIndex = 4;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPassword.Location = new System.Drawing.Point(100, 350);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(94, 23);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password:";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFilePath.Location = new System.Drawing.Point(20, 300);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(0, 23);
            this.lblFilePath.TabIndex = 6;
            // 
            // ExtractDataWorkflow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 460);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ExtractDataWorkflow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extract Hidden Data";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
