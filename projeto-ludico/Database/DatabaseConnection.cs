using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;

namespace projeto_ludico.Database
{
    internal class DatabaseConnection
    {
        private static SqliteConnection _connection;


        public static SqliteConnection GetConnection()
        {
            if (_connection == null)
            {
                string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
                string databasePath = Path.Combine(directoryPath, @"..\..\Database\Database.db");
                databasePath = Path.GetFullPath(databasePath);

                string connectionString = $"Data Source={databasePath}";
                _connection = new SqliteConnection(connectionString);
                _connection.Open();
            }

            return _connection;
        }

        
    }
}
