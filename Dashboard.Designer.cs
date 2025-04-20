namespace AUDIO_STEGNOGRAPHY
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnEmbedData;
        private System.Windows.Forms.Button btnExtractData;
        private System.Windows.Forms.DataGridView dgvAudioFiles;
        private System.Windows.Forms.Button btnDownload;

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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.btnEmbedData = new System.Windows.Forms.Button();
            this.btnExtractData = new System.Windows.Forms.Button();
            this.dgvAudioFiles = new System.Windows.Forms.DataGridView();
            this.btnDownload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudioFiles)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Showcard Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTitle.Location = new System.Drawing.Point(250, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(331, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // splitContainer
            this.splitContainer.Location = new System.Drawing.Point(20, 80);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Size = new System.Drawing.Size(760, 360);
            this.splitContainer.SplitterDistance = 200;
            this.splitContainer.TabIndex = 1;

            // Left Panel
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer.Panel1.Controls.Add(this.btnEmbedData);
            this.splitContainer.Panel1.Controls.Add(this.btnExtractData);

            // Right Panel
            this.splitContainer.Panel2.Controls.Add(this.dgvAudioFiles);
            this.splitContainer.Panel2.Controls.Add(this.btnDownload);

            // btnEmbedData
            this.btnEmbedData.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEmbedData.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEmbedData.ForeColor = System.Drawing.Color.White;
            this.btnEmbedData.Location = new System.Drawing.Point(20, 50);
            this.btnEmbedData.Name = "btnEmbedData";
            this.btnEmbedData.Size = new System.Drawing.Size(150, 40);
            this.btnEmbedData.TabIndex = 0;
            this.btnEmbedData.Text = "Embed Data";
            this.btnEmbedData.UseVisualStyleBackColor = false;
            this.btnEmbedData.Click += new System.EventHandler(this.btnEmbedData_Click);

            // btnExtractData
            this.btnExtractData.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExtractData.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExtractData.ForeColor = System.Drawing.Color.White;
            this.btnExtractData.Location = new System.Drawing.Point(20, 120);
            this.btnExtractData.Name = "btnExtractData";
            this.btnExtractData.Size = new System.Drawing.Size(150, 40);
            this.btnExtractData.TabIndex = 1;
            this.btnExtractData.Text = "Extract Data";
            this.btnExtractData.UseVisualStyleBackColor = false;
            this.btnExtractData.Click += new System.EventHandler(this.btnExtractData_Click);

            // dgvAudioFiles
            this.dgvAudioFiles.AllowUserToAddRows = false;
            this.dgvAudioFiles.AllowUserToDeleteRows = false;
            this.dgvAudioFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAudioFiles.Location = new System.Drawing.Point(20, 20);
            this.dgvAudioFiles.Name = "dgvAudioFiles";
            this.dgvAudioFiles.ReadOnly = true;
            this.dgvAudioFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAudioFiles.Size = new System.Drawing.Size(520, 280);
            this.dgvAudioFiles.TabIndex = 0;

            // btnDownload
            this.btnDownload.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDownload.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.Location = new System.Drawing.Point(20, 320);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(120, 40);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);

            // Dashboard
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudioFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
