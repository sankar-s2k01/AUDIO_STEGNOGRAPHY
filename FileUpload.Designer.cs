namespace AUDIO_STEGNOGRAPHY
{
    partial class FileUpload
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.Button btnUpload;

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
            this.lblFilePath = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblArtist = new System.Windows.Forms.Label();
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblFilePath
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(20, 20);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(80, 13);
            this.lblFilePath.TabIndex = 0;
            this.lblFilePath.Text = "Select a File:";

            // txtFilePath
            this.txtFilePath.Location = new System.Drawing.Point(20, 50);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(300, 20);
            this.txtFilePath.TabIndex = 1;

            // btnBrowse
            this.btnBrowse.Location = new System.Drawing.Point(330, 48);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 90);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Title:";

            // txtTitle
            this.txtTitle.Location = new System.Drawing.Point(20, 110);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(300, 20);
            this.txtTitle.TabIndex = 4;

            // lblArtist
            this.lblArtist.AutoSize = true;
            this.lblArtist.Location = new System.Drawing.Point(20, 150);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(33, 13);
            this.lblArtist.TabIndex = 5;
            this.lblArtist.Text = "Artist:";

            // txtArtist
            this.txtArtist.Location = new System.Drawing.Point(20, 170);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(300, 20);
            this.txtArtist.TabIndex = 6;

            // lblGenre
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(20, 210);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(39, 13);
            this.lblGenre.TabIndex = 7;
            this.lblGenre.Text = "Genre:";

            // txtGenre
            this.txtGenre.Location = new System.Drawing.Point(20, 230);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(300, 20);
            this.txtGenre.TabIndex = 8;

            // btnUpload
            this.btnUpload.Location = new System.Drawing.Point(150, 270);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(100, 30);
            this.btnUpload.TabIndex = 9;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);

            // FileUpload
            this.ClientSize = new System.Drawing.Size(420, 320);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.txtArtist);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.btnUpload);
            this.Name = "FileUpload";
            this.Text = "Upload Audio File";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
