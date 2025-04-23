using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace AUDIO_STEGNOGRAPHY.Tests
{
    [TestClass]
    public class EmbedAndExtractTests
    {
        // Mock data for testing
        public const string TestMessage = "Test Message";
        public const string TestPassword = "1234";
        public const string InvalidPassword = "wrongpassword";
        public const string TestFilePath = "test.mp3";
        public const string InvalidFilePath = "test.txt";

        [TestMethod]
        public void TestCompleteEmbedWorkflow()
        {
            // Arrange
            var embedWorkflow = new EmbedDataWorkflow();
            embedWorkflow.selectedFilePath = TestFilePath;
            embedWorkflow.authorMessage = TestMessage;
            embedWorkflow.uniquePassword = TestPassword;

            // Act
            try
            {
                byte[] result = embedWorkflow.EmbedHiddenMessage(TestFilePath, TestMessage, TestPassword);

                // Assert
                Assert.IsNotNull(result, "The file should be successfully embedded with hidden data.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed with exception: {ex.Message}");
            }
        }

        [TestMethod]
        public void TestMissingFileInEmbed()
        {
            // Arrange
            var embedWorkflow = new EmbedDataWorkflow();
            embedWorkflow.selectedFilePath = null;
            embedWorkflow.authorMessage = TestMessage;
            embedWorkflow.uniquePassword = TestPassword;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                embedWorkflow.EmbedHiddenMessage(embedWorkflow.selectedFilePath, TestMessage, TestPassword);
            }, "An exception should be thrown when no file is selected.");
        }

        [TestMethod]
        public void TestCompleteExtractWorkflow()
        {
            // Arrange
            var extractWorkflow = new ExtractDataWorkflow();
            string encryptedFilePath = TestFilePath; // Assume this file has encrypted data

            // Act
            try
            {
                string result = extractWorkflow.ExtractHiddenMessage(encryptedFilePath, TestPassword);

                // Assert
                Assert.IsNotNull(result, "The hidden message should be successfully extracted.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed with exception: {ex.Message}");
            }
        }

        [TestMethod]
        public void TestIncorrectPasswordInExtract()
        {
            // Arrange
            var extractWorkflow = new ExtractDataWorkflow();
            string encryptedFilePath = TestFilePath; // Assume this file has encrypted data

            // Act & Assert
            Assert.ThrowsException<UnauthorizedAccessException>(() =>
            {
                extractWorkflow.ExtractHiddenMessage(encryptedFilePath, InvalidPassword);
            }, "An exception should be thrown for an incorrect password.");
        }

        [TestMethod]
        public void TestEncryptAndDecryptData()
        {
            // Arrange
            var embedWorkflow = new EmbedDataWorkflow();
            string key = "12345678901234567890123456789012"; // 32-byte key
            string iv = "1234567890123456"; // 16-byte IV

            // Act
            byte[] encryptedData = embedWorkflow.EncryptData(TestMessage, key, iv);
            string decryptedData = embedWorkflow.DecryptData(encryptedData, key, iv);

            // Assert
            Assert.AreEqual(TestMessage, decryptedData, "The decrypted data should match the original message.");
        }

        [TestMethod]
        public void TestInvalidFileFormatInEmbed()
        {
            // Arrange
            var embedWorkflow = new EmbedDataWorkflow();
            embedWorkflow.selectedFilePath = InvalidFilePath;
            embedWorkflow.authorMessage = TestMessage;
            embedWorkflow.uniquePassword = TestPassword;

            // Act & Assert
            Assert.ThrowsException<InvalidDataException>(() =>
            {
                embedWorkflow.EmbedHiddenMessage(embedWorkflow.selectedFilePath, TestMessage, TestPassword);
            }, "An exception should be thrown for an invalid file format.");
        }
    }
}
