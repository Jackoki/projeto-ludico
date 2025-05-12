using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;

namespace projeto_ludico.Database
{
    internal class DatabaseConnection
    {
        //Variavel de conexão ao SQLite
        private static SqliteConnection _connection;
        public static SqliteConnection GetConnection()
        {
            //Será pego o diretório, voltar 2 pastas e então pegar o diretório do Database.db
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string databasePath = Path.Combine(directoryPath, @"..\..\Database\Database.db");
            databasePath = Path.GetFullPath(databasePath);

            //Realiza a conexão a partir da string acima, retornando assim a conexão
            string connectionString = $"Data Source={databasePath}";
            var connection = new SqliteConnection(connectionString);
            connection.Open();
            return connection;
        }



        public void Dispose()
        {
            //Função para desconectar no banco de dados
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }


    }
}
