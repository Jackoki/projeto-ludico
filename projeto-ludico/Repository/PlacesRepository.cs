using System;
using Microsoft.Data.Sqlite;
using projeto_ludico.Database;
using projeto_ludico.Models;

public class PlacesRepository
{
    public void AddPlace(string name)
    {
        using (var connection = DatabaseConnection.GetConnection())
        {
            // Realiza a adição do local pela Query abaixo
            string sql = "INSERT INTO events_local (Name) VALUES (@Name);";
            //Ocorre a atribuição de variáveis a partir do command, que resgata os valores do placeModel passado no parâmetro
            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
            }
        }
    }

     //Funcionamento basicamente identico com a função acima, única diferença seria a query do SQL, que é um Update
    public void UpdatePlace(PlacesModel placesModel)
    {
        using (var connection = DatabaseConnection.GetConnection())
        {
            string sql = "UPDATE events_local SET Name = @Name WHERE Id = @Id;";
            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Name", placesModel.name);
                command.Parameters.AddWithValue("@Id", placesModel.id);
                command.ExecuteNonQuery();
            }
        }
    }

    //Realiza a deleção do local pelo Id na query
    public void DeletePlace(int id)
    {
        using (var connection = DatabaseConnection.GetConnection())
        {
            string sql = "DELETE FROM events_local WHERE Id = @Id;";
            using (var command = new SqliteCommand(sql, connection))
            {
                // Adiciona o parâmetro do ID
                command.Parameters.AddWithValue("@Id", id);
                // Executa o comando de exclusão
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                    throw new InvalidOperationException("Nenhum local encontrado.");
            }
        }
    }
}
