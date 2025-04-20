using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace AUDIO_STEGNOGRAPHY
{
    public static class UserManager
    {
        public static bool Register(string username, string password, string email)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the username already exists
                string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                using (SqlCommand checkUserCommand = new SqlCommand(checkUserQuery, connection))
                {
                    checkUserCommand.Parameters.AddWithValue("@Username", username);
                    int userCount = (int)checkUserCommand.ExecuteScalar();
                    if (userCount > 0)
                    {
                        return false; // Username already exists
                    }
                }

                // Hash the password
                string passwordHash = HashPassword(password);

                // Insert the new user
                string insertUserQuery = "INSERT INTO Users (Username, PasswordHash, Email) VALUES (@Username, @PasswordHash, @Email)";
                using (SqlCommand insertUserCommand = new SqlCommand(insertUserQuery, connection))
                {
                    insertUserCommand.Parameters.AddWithValue("@Username", username);
                    insertUserCommand.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    insertUserCommand.Parameters.AddWithValue("@Email", email);
                    insertUserCommand.ExecuteNonQuery();
                }
            }

            return true; // Registration successful
        }

        public static bool Login(string username, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Hash the password
                string passwordHash = HashPassword(password);

                // Check if the username and password match
                string loginQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";
                using (SqlCommand loginCommand = new SqlCommand(loginQuery, connection))
                {
                    loginCommand.Parameters.AddWithValue("@Username", username);
                    loginCommand.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    int userCount = (int)loginCommand.ExecuteScalar();
                    return userCount > 0;
                }
            }
        }

        public static bool ResetPassword(string username, string email, string newPassword)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the username and email match
                string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Email = @Email";
                using (SqlCommand checkUserCommand = new SqlCommand(checkUserQuery, connection))
                {
                    checkUserCommand.Parameters.AddWithValue("@Username", username);
                    checkUserCommand.Parameters.AddWithValue("@Email", email);
                    int userCount = (int)checkUserCommand.ExecuteScalar();
                    if (userCount == 0)
                    {
                        return false; // Invalid username or email
                    }
                }

                // Hash the new password
                string newPasswordHash = HashPassword(newPassword);

                // Update the password
                string updatePasswordQuery = "UPDATE Users SET PasswordHash = @PasswordHash WHERE Username = @Username AND Email = @Email";
                using (SqlCommand updatePasswordCommand = new SqlCommand(updatePasswordQuery, connection))
                {
                    updatePasswordCommand.Parameters.AddWithValue("@PasswordHash", newPasswordHash);
                    updatePasswordCommand.Parameters.AddWithValue("@Username", username);
                    updatePasswordCommand.Parameters.AddWithValue("@Email", email);
                    updatePasswordCommand.ExecuteNonQuery();
                }
            }

            return true; // Password reset successful
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
