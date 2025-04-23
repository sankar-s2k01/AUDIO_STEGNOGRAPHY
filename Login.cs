using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AUDIO_STEGNOGRAPHY
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public void btnRegister_Click(object sender, EventArgs e)
        {
            // Open the Register form
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide(); // Optionally hide the login form
        }


        public void btnLogin_Click(object sender, EventArgs e)
        {
            // Clear previous error messages
            errorProvider.Clear();

            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, "Username is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "Password is required.");
                return;
            }

            // Check user credentials
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@PasswordHash", txtPassword.Text.Trim()); // Hash password in production

                try
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        // Retrieve the UserId of the logged-in user
                        string getUserIdQuery = "SELECT UserId FROM Users WHERE Username = @Username";
                        SqlCommand getUserIdCmd = new SqlCommand(getUserIdQuery, conn);
                        getUserIdCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        int userId = (int)getUserIdCmd.ExecuteScalar();

                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Redirect to the Dashboard
                        this.Hide();
                        Dashboard dashboard = new Dashboard(userId);
                        dashboard.Show();
                    }

                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
