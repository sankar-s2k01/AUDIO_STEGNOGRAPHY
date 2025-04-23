namespace AUDIO_STEGNOGRAPHY
{
    partial class EmbedDataWorkflow
    {
        public System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Panel panelContent;
        public System.Windows.Forms.Button btnPrevious;
        public System.Windows.Forms.Button btnNext;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Showcard Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTitle.Location = new System.Drawing.Point(88, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(429, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Embed Data Workflow";
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
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.White;
            this.btnPrevious.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnPrevious.Location = new System.Drawing.Point(20, 400);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(120, 40);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNext.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(480, 400);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 40);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // EmbedDataWorkflow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 460);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EmbedDataWorkflow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Embed Data Workflow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
