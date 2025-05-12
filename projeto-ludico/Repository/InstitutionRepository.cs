using System;
using Microsoft.Data.Sqlite;
using projeto_ludico.Database;
using projeto_ludico.Models;

public class InstitutionRepository
{
    //Função realiza a conexão no banco de dados e então insere na tabela institutions
    public void AddInstitution(string name)
    {
        using (var connection = DatabaseConnection.GetConnection())
        {
            string sql = "INSERT INTO institutions (Name) VALUES (@Name);";
            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
            }
        }
    }

    public void UpdateInstitution(InstitutionsModel institutionsModel)
    {
        using (var connection = DatabaseConnection.GetConnection())
        {
            string sql = "UPDATE institutions SET Name = @Name WHERE Id = @Id;";
            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Name", institutionsModel.Name);
                command.Parameters.AddWithValue("@Id", institutionsModel.Id);
                command.ExecuteNonQuery();
            }
        }
    }


    public void DeleteInstitution(int id)
    {
        using (var connection = DatabaseConnection.GetConnection())
        {
            string sql = "DELETE FROM institutions WHERE Id = @Id;";
            using (var command = new SqliteCommand(sql, connection))
            {
                // Adiciona o parâmetro do ID
                command.Parameters.AddWithValue("@Id", id);

                // Executa o comando de exclusão
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new InvalidOperationException($"Nenhuma instituição encontrada.");
                }
            }
        }
    }

}
