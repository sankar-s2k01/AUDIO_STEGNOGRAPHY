using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AUDIO_STEGNOGRAPHY
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Clear previous error messages
            errorProvider.Clear();

            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, "Username is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !Regex.IsMatch(txtEmail.Text, @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"))
            {
                errorProvider.SetError(txtEmail, "Valid email is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "Password is required.");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider.SetError(txtConfirmPassword, "Passwords do not match.");
                return;
            }

            // Save user to database
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Email, PasswordHash) VALUES (@Username, @Email, @PasswordHash)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@PasswordHash", txtPassword.Text.Trim()); // Hash password in production

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Login loginForm = new Login();
                    loginForm.Show();
                    this.Hide();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
