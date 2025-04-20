using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace AUDIO_STEGNOGRAPHY
{
    public partial class Dashboard : Form
    {
        private int userId;
        public Dashboard(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadAudioFiles();
        }

        public void LoadAudioFiles()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AudioFileId, FileName, CreatedAt FROM AudioFiles WHERE UserId = @UserId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@UserId", userId);
                DataTable dataTable = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(dataTable);
                    dgvAudioFiles.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading audio files: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (dgvAudioFiles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a file to download.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int fileId = Convert.ToInt32(dgvAudioFiles.SelectedRows[0].Cells["AudioFileId"].Value);
            string fileName = dgvAudioFiles.SelectedRows[0].Cells["FileName"].Value.ToString();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT FileData FROM AudioFiles WHERE AudioFileId = @AudioFileId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AudioFileId", fileId);

                try
                {
                    conn.Open();
                    byte[] fileData = (byte[])cmd.ExecuteScalar();

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.FileName = fileName;
                        saveFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllBytes(saveFileDialog.FileName, fileData);
                            MessageBox.Show("File downloaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error downloading file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEmbedData_Click(object sender, EventArgs e)
        {
            // Open the Embed Data workflow
            EmbedDataWorkflow embedDataWorkflow = new EmbedDataWorkflow(userId, this);
            embedDataWorkflow.Show();
        }

        private void btnExtractData_Click(object sender, EventArgs e)
        {
            // Open the Extract Data workflow
            ExtractDataWorkflow extractDataWorkflow = new ExtractDataWorkflow();
            extractDataWorkflow.Show();
        }
    }
}
