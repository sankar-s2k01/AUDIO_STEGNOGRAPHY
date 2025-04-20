using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

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
                string hiddenData = ExtractHiddenMessage(selectedFilePath, txtPassword.Text);
                if (hiddenData == null)
                {
                    MessageBox.Show("Invalid password or no hidden data found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] parts = hiddenData.Split('|');
                if (parts.Length != 2)
                {
                    MessageBox.Show("Invalid hidden data format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string message = parts[0];
                string password = parts[1];

                MessageBox.Show("Hidden Message: " + message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error extracting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string DecryptData(byte[] cipherText, string key)
        {
            using (RijndaelManaged rijndael = new RijndaelManaged())
            {
                rijndael.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32)); // Ensure the key is 32 bytes
                rijndael.IV = Encoding.UTF8.GetBytes(key.PadRight(16).Substring(0, 16));  // Ensure the IV is 16 bytes

                ICryptoTransform decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);

                using (MemoryStream memoryStream = new MemoryStream(cipherText))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream, Encoding.UTF8))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }


        private string ExtractHiddenMessage(string filePath, string encryptionKey)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                // Read the last 2048 bytes of the file (to ensure we capture the hidden data)
                fileStream.Seek(-2048, SeekOrigin.End);
                byte[] buffer = new byte[2048];
                int bytesRead = fileStream.Read(buffer, 0, buffer.Length);

                // Decrypt the hidden data
                try
                {
                    return DecryptData(buffer, encryptionKey);
                }
                catch
                {
                    return null; // Decryption failed
                }
            }
        }



    }
}
