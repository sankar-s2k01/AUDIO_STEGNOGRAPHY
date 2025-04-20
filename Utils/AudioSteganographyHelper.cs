using System;
using System.IO;
using System.Text; // Add this line

public static class AudioSteganographyHelper
{
    public static void EmbedText(string audioFilePath, string text, string outputFilePath)
    {
        byte[] audioBytes = File.ReadAllBytes(audioFilePath);
        byte[] textBytes = Encoding.UTF8.GetBytes(text);
        byte[] textLengthBytes = BitConverter.GetBytes(textBytes.Length);

        using (MemoryStream ms = new MemoryStream())
        {
            ms.Write(audioBytes, 0, audioBytes.Length);
            ms.Write(textLengthBytes, 0, textLengthBytes.Length);
            ms.Write(textBytes, 0, textBytes.Length);
            File.WriteAllBytes(outputFilePath, ms.ToArray());
        }
    }

    public static string ExtractText(string audioFilePath)
    {
        byte[] audioBytes = File.ReadAllBytes(audioFilePath);
        int textLength = BitConverter.ToInt32(audioBytes, audioBytes.Length - 4);
        byte[] textBytes = new byte[textLength];
        Array.Copy(audioBytes, audioBytes.Length - 4 - textLength, textBytes, 0, textLength);
        return Encoding.UTF8.GetString(textBytes);
    }
}
