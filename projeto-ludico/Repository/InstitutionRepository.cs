using Microsoft.Data.Sqlite;
using projeto_ludico.Database;
using projeto_ludico.Models;

public class InstitutionRepository
{
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
}
