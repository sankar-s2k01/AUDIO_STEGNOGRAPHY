using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AUDIO_STEGNOGRAPHY
{
    public partial class ExtractDataWorkflow : Form
    {
        private string selectedFilePath;

        public ExtractDataWorkflow()
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
                    selectedFilePath = openFileDialog.FileName;
                    lblFilePath.Text = "Selected File: " + selectedFilePath;
                }
            }
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedFilePath))
            {
                MessageBox.Show("Please select a file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter the password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string hiddenData = ExtractHiddenMessage(selectedFilePath);
                if (hiddenData == null)
                {
                    MessageBox.Show("No hidden data found in the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] parts = hiddenData.Split('|');
                if (parts.Length != 2)
                {
                    MessageBox.Show($"Invalid hidden data format: {hiddenData}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string message = parts[0];
                string password = parts[1];

                if (password != txtPassword.Text)
                {
                    MessageBox.Show("Incorrect password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Hidden Message: " + message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error extracting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ExtractHiddenMessage(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                // Read the last 2048 bytes of the file (to ensure we capture the hidden data)
                fileStream.Seek(-2048, SeekOrigin.End);
                byte[] buffer = new byte[2048];
                int bytesRead = fileStream.Read(buffer, 0, buffer.Length);

                // Convert the bytes to a string
                string extractedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                // Locate the hidden data using the delimiters
                int startIndex = extractedData.IndexOf("|HIDDEN_DATA_START|");
                int endIndex = extractedData.IndexOf("|HIDDEN_DATA_END|");

                if (startIndex != -1 && endIndex != -1 && endIndex > startIndex)
                {
                    // Extract the hidden data
                    return extractedData.Substring(startIndex + "|HIDDEN_DATA_START|".Length, endIndex - startIndex - "|HIDDEN_DATA_START|".Length);
                }

                return null; // No hidden data found
            }
        }



    }
}