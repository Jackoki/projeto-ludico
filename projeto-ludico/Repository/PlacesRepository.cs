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
            string sql = "INSERT INTO events_local (Name) VALUES (@Name);";
            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
            }
        }
    }

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

    public void DeletePlace(int id)
    {
        using (var connection = DatabaseConnection.GetConnection())
        {
            string sql = "DELETE FROM events_local WHERE Id = @Id;";
            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                    throw new InvalidOperationException("Nenhum local encontrado.");
            }
        }
    }
}
