using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace AUDIO_STEGNOGRAPHY
{
    public partial class FileUpload : Form
    {
        public FileUpload()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilePath.Text) || string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtArtist.Text) || string.IsNullOrWhiteSpace(txtGenre.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string filePath = txtFilePath.Text;
            string fileName = Path.GetFileName(filePath);
            string title = txtTitle.Text.Trim();
            string artist = txtArtist.Text.Trim();
            string genre = txtGenre.Text.Trim();
            byte[] fileData;

            try
            {
                // Read the file as a byte array
                fileData = File.ReadAllBytes(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save file data and details to the database
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO AudioFiles (UserId, FileName, FileData, Title, Artist, Genre) " +
                               "VALUES (@UserId, @FileName, @FileData, @Title, @Artist, @Genre)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", 1); // Assuming admin user with UserId = 1
                cmd.Parameters.AddWithValue("@FileName", fileName);
                cmd.Parameters.AddWithValue("@FileData", fileData);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Artist", artist);
                cmd.Parameters.AddWithValue("@Genre", genre);
                //cmd.Parameters.AddWithValue("@UserId", userId);


                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("File uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error uploading file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
