using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace AUDIO_STEGNOGRAPHY.Tests
{
    [TestClass]
    public class LoginAndRegisterTests
    {
        // Login Tests
        [TestMethod]
        public void TestValidLogin()
        {
            // Arrange
            var loginForm = new Login();
            loginForm.txtUsername.Text = "testuser";
            loginForm.txtPassword.Text = "password123";

            // Act
            loginForm.btnLogin.PerformClick();

            // Assert
            Assert.AreEqual("Dashboard", loginForm.CurrentView, "The dashboard should be displayed after a successful login.");
        }

        [TestMethod]
        public void TestInvalidLogin()
        {
            // Arrange
            var loginForm = new Login();
            loginForm.txtUsername.Text = "invaliduser";
            loginForm.txtPassword.Text = "wrongpassword";

            // Act
            loginForm.btnLogin.PerformClick();

            // Assert
            Assert.AreEqual("Invalid credentials", loginForm.ErrorMessage, "An error message should be displayed for invalid login.");
        }

        [TestMethod]
        public void TestEmptyUsernameInLogin()
        {
            // Arrange
            var loginForm = new Login();
            loginForm.txtUsername.Text = "";
            loginForm.txtPassword.Text = "password123";

            // Act
            loginForm.btnLogin.PerformClick();

            // Assert
            Assert.AreEqual("Username cannot be empty", loginForm.ErrorMessage, "An error message should be displayed for empty username.");
        }

        [TestMethod]
        public void TestEmptyPasswordInLogin()
        {
            // Arrange
            var loginForm = new Login();
            loginForm.txtUsername.Text = "testuser";
            loginForm.txtPassword.Text = "";

            // Act
            loginForm.btnLogin.PerformClick();

            // Assert
            Assert.AreEqual("Password cannot be empty", loginForm.ErrorMessage, "An error message should be displayed for empty password.");
        }

        // Register Tests
        [TestMethod]
        public void TestValidRegistration()
        {
            // Arrange
            var registerForm = new Register();
            registerForm.txtUsername.Text = "newuser";
            registerForm.txtEmail.Text = "newuser@example.com";
            registerForm.txtPassword.Text = "password123";
            registerForm.txtConfirmPassword.Text = "password123";

            // Act
            registerForm.btnRegister.PerformClick();

            // Assert
            Assert.AreEqual("Registration successful", registerForm.SuccessMessage, "A success message should be displayed after successful registration.");
        }

        [TestMethod]
        public void TestEmptyUsernameInRegistration()
        {
            // Arrange
            var registerForm = new Register();
            registerForm.txtUsername.Text = "";
            registerForm.txtEmail.Text = "newuser@example.com";
            registerForm.txtPassword.Text = "password123";
            registerForm.txtConfirmPassword.Text = "password123";

            // Act
            registerForm.btnRegister.PerformClick();

            // Assert
            Assert.AreEqual("Username cannot be empty", registerForm.ErrorMessage, "An error message should be displayed for empty username.");
        }

        [TestMethod]
        public void TestInvalidEmailInRegistration()
        {
            // Arrange
            var registerForm = new Register();
            registerForm.txtUsername.Text = "newuser";
            registerForm.txtEmail.Text = "invalid-email";
            registerForm.txtPassword.Text = "password123";
            registerForm.txtConfirmPassword.Text = "password123";

            // Act
            registerForm.btnRegister.PerformClick();

            // Assert
            Assert.AreEqual("Invalid email address", registerForm.ErrorMessage, "An error message should be displayed for invalid email.");
        }

        [TestMethod]
        public void TestPasswordMismatchInRegistration()
        {
            // Arrange
            var registerForm = new Register();
            registerForm.txtUsername.Text = "newuser";
            registerForm.txtEmail.Text = "newuser@example.com";
            registerForm.txtPassword.Text = "password123";
            registerForm.txtConfirmPassword.Text = "password456";

            // Act
            registerForm.btnRegister.PerformClick();

            // Assert
            Assert.AreEqual("Passwords do not match", registerForm.ErrorMessage, "An error message should be displayed for password mismatch.");
        }

        [TestMethod]
        public void TestEmptyPasswordInRegistration()
        {
            // Arrange
            var registerForm = new Register();
            registerForm.txtUsername.Text = "newuser";
            registerForm.txtEmail.Text = "newuser@example.com";
            registerForm.txtPassword.Text = "";
            registerForm.txtConfirmPassword.Text = "";

            // Act
            registerForm.btnRegister.PerformClick();

            // Assert
            Assert.AreEqual("Password cannot be empty", registerForm.ErrorMessage, "An error message should be displayed for empty password.");
        }
    }

    public class Login
    {
        // Existing code for the Login class

        public string CurrentView { get; set; }

        public Login()
        {
            CurrentView = "Login"; // Default view
        }

        public void btnLogin_PerformClick()
        {
            // Simulate login logic
            if (txtUsername.Text == "testuser" && txtPassword.Text == "password123")
            {
                CurrentView = "Dashboard";
            }
            else
            {
                ErrorMessage = "Invalid credentials";
            }
        }

        public string ErrorMessage { get; set; }
        public TextBox txtUsername { get; set; } = new TextBox();
        public TextBox txtPassword { get; set; } = new TextBox();
        public Button btnLogin { get; set; } = new Button();
    }

    public class Register
    {
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public TextBox txtUsername { get; set; } = new TextBox();
        public TextBox txtEmail { get; set; } = new TextBox();
        public TextBox txtPassword { get; set; } = new TextBox();
        public TextBox txtConfirmPassword { get; set; } = new TextBox();
        public Button btnRegister { get; set; } = new Button();

        public void btnRegister_PerformClick()
        {
            // Simulate registration logic
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ErrorMessage = "Username cannot be empty";
            }
            else if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                ErrorMessage = "Invalid email address";
            }
            else if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ErrorMessage = "Password cannot be empty";
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ErrorMessage = "Passwords do not match";
            }
            else
            {
                SuccessMessage = "Registration successful";
            }
        }
    }
}
