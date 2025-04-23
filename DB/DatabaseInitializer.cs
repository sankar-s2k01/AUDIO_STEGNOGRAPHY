using System;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace AudioSteganography
{
    public class DatabaseInitializer
    {
        public static void InitializeDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string scriptPath = Path.Combine("C:\\Users\\Dell\\OneDrive\\Desktop\\AUDIO_STEGNOGRAPHY\\DB", "database_initialize.sql");
            Console.WriteLine("DB Initalizer Script Path :" + scriptPath);
            ExecuteSqlScript(connectionString, scriptPath);
        }

        public static void ExecuteSqlScript(string connectionString, string scriptPath)
        {
            string script = File.ReadAllText(scriptPath);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("DB Initalizer Script Path :vsdavjsahjvdashjd" );
                SqlCommand command = new SqlCommand(script, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
