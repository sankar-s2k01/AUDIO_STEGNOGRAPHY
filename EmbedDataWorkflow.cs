using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AUDIO_STEGNOGRAPHY
{
    public partial class EmbedDataWorkflow : Form
    {
        private int currentStep = 1;
        private string selectedFilePath;
        private string authorMessage = ""; // Initialize to an empty string 
        private string uniquePassword = "";
        private int userId;
        private Dashboard dashboard;
        public EmbedDataWorkflow(int userId, Dashboard dashboard)
        {
            this.dashboard = dashboard;
            this.userId = userId;
            InitializeComponent();
            LoadStep();
        }

        public EmbedDataWorkflow()
        {
            InitializeComponent();
            LoadStep();
        }

        private void LoadStep()
        {
            panelContent.Controls.Clear();

            switch (currentStep)
            {
                case 1:
                    LoadStep1();
                    break;
                case 2:
                    LoadStep2();
                    break;
                case 3:
                    LoadStep3();
                    break;
                case 4:
                    LoadStep4();
                    break;
            }

            btnPrevious.Enabled = currentStep > 1;
            btnNext.Text = currentStep < 4 ? "Next" : "Finish";
            if (currentStep == 4)
                btnNext.Hide();
            else
                btnNext.Show();
        }

        private void LoadStep1()
        {
            Label lblUpload = new Label
            {
                Text = "Step 1: Upload Audio File",
                AutoSize = true,
                Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(20, 20)
            };
            Button btnBrowse = new Button
            {
                Text = "Browse",
                Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold), // Bold font
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(120, 30), // Adjusted size
                BackColor = System.Drawing.Color.Green, // Background color
                ForeColor = System.Drawing.Color.White, // Text color
            };
            btnBrowse.FlatAppearance.BorderSize = 1; // Border thickness
            btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue; // Border color
            btnBrowse.Click += BtnBrowse_Click;

            panelContent.Controls.Add(lblUpload);
            panelContent.Controls.Add(btnBrowse);
        }

        private void LoadStep2()
        {
            Label lblMessage = new Label
            {
                Text = "Step 2: Enter Music Author Message",
                AutoSize = true,
                Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(20, 20)
            };
            TextBox txtMessage = new TextBox
            {
                Name = "txtMessage",
                Font = new System.Drawing.Font("Open Sans", 10F),
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(200, 40),
                Text = authorMessage // Set the initial text to the current message
            };

            txtMessage.TextChanged += (s, e) => { authorMessage = txtMessage.Text; };

            panelContent.Controls.Add(lblMessage);
            panelContent.Controls.Add(txtMessage);
        }

        private void LoadStep3()
        {
            Label lblPassword = new Label
            {
                Text = "Step 3: Enter Unique Password",
                AutoSize = true,
                Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(20, 20)
            };
            TextBox txtPassword = new TextBox
            {
                Name = "txtPassword",
                Font = new System.Drawing.Font("Open Sans", 10F),
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(200, 30),
                PasswordChar = '*',
                Text = uniquePassword // Set the initial text to the current password
                
            };

            txtPassword.TextChanged += (s, e) => { uniquePassword = txtPassword.Text; };

            panelContent.Controls.Add(lblPassword);
            panelContent.Controls.Add(txtPassword);
        }

        private void LoadStep4()
        {
            Label lblPreview = new Label
            {
                Text = "Step 4: Preview and Upload",
                AutoSize = true,
                Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(20, 20)
            };

            Label lblFilePath = new Label
            {
                Text = "File Path: " + (selectedFilePath ?? "No file selected"),
                AutoSize = true,
                Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(20, 60)
            };

            Label lblMessagePreview = new Label
            {
                Text = "Hidden Message: " + (authorMessage ?? "No message entered"),
                AutoSize = true,
                Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(20, 100)
            };

            Button btnUpload = new Button
            {
                Text = "Embed and Save",
                Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(20, 140),
                Size = new System.Drawing.Size(220, 30), // Adjusted size
                BackColor = System.Drawing.Color.Green, // Background color
                ForeColor = System.Drawing.Color.White, // Text color
            };
            btnUpload.Click += BtnUpload_Click;

            panelContent.Controls.Add(lblPreview);
            panelContent.Controls.Add(lblFilePath);
            panelContent.Controls.Add(lblMessagePreview);
            panelContent.Controls.Add(btnUpload);
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;
                    MessageBox.Show("File selected: " + selectedFilePath, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnNext_Click(sender, e);
                }
            }
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedFilePath) || string.IsNullOrWhiteSpace(authorMessage) || string.IsNullOrWhiteSpace(uniquePassword))
            {
                MessageBox.Show("Please complete all steps before embedding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fileName = Path.GetFileName(selectedFilePath);
            byte[] fileData;

            try
            {
                // Embed the hidden message and password in the audio file
                fileData = EmbedHiddenMessage(selectedFilePath, authorMessage, uniquePassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error embedding data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save file data to the database
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO AudioFiles (UserId, FileName, FileData, AuthorMessage, Password, CreatedAt) " +
                               "VALUES (@UserId, @FileName, @FileData, @AuthorMessage, @Password, @CreatedAt)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@FileName", fileName);
                cmd.Parameters.AddWithValue("@FileData", fileData);
                cmd.Parameters.AddWithValue("@AuthorMessage", authorMessage);
                cmd.Parameters.AddWithValue("@Password", uniquePassword);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("File uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Notify the Dashboard to reload audio files
                    dashboard.LoadAudioFiles();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error uploading file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private byte[] EmbedHiddenMessage(string filePath, string message, string password)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (FileStream inputFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // Copy the original audio file to the memory stream
                    inputFileStream.CopyTo(memoryStream);
                }

                // Embed the hidden message and password with delimiters
                string hiddenData = "|HIDDEN_DATA_START|" + message + "|" + password + "|HIDDEN_DATA_END|";
                byte[] hiddenDataBytes = System.Text.Encoding.UTF8.GetBytes(hiddenData);

                // Append the hidden data to the file
                memoryStream.Write(hiddenDataBytes, 0, hiddenDataBytes.Length);

                return memoryStream.ToArray();
            }
        }



        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentStep > 1)
            {
                currentStep--;
                LoadStep();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentStep < 4)
            {
                currentStep++;
            }
            LoadStep();
        }
    }
}