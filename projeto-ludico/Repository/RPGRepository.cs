using Microsoft.Data.Sqlite;
using projeto_ludico.Database;
using projeto_ludico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_ludico.Repository
{
    public class RPGRepository
    {
        public void AddRPG(string name, string description)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = "INSERT INTO role_play_games (Name, Description) VALUES (@Name, @Description);";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Description", description ?? "");
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateRPG(RPGModel rpgModel)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = "UPDATE role_play_games SET Name = @Name, Description = @Description WHERE Id = @Id;";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", rpgModel.name);
                    command.Parameters.AddWithValue("@Description", rpgModel.description ?? "");
                    command.Parameters.AddWithValue("@Id", rpgModel.id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRPG(int id)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = "DELETE FROM role_play_games WHERE Id = @Id;";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        throw new InvalidOperationException("Nenhum RPG encontrado.");
                }
            }
        }

        public RPGModel GetRpg(int id)
        {
            RPGModel rpgModel = new RPGModel();

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    string sql = @"SELECT id, name, description 
                           FROM role_play_games 
                           WHERE id = @Id;";

                    using (var command = new SqliteCommand(sql, connection))
                    {
                        // Adiciona o parâmetro do ID
                        command.Parameters.AddWithValue("@Id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                rpgModel = new RPGModel
                                {
                                    id = reader.GetInt32(reader.GetOrdinal("id")),
                                    name = reader.GetString(reader.GetOrdinal("name")),
                                    description = reader.GetString(reader.GetOrdinal("description"))
                                };
                            }
                        }
                    }
                }

                return rpgModel;
            }

            catch (Exception)
            {
                throw new InvalidOperationException("Erro ao buscar evento no banco de dados.");
            }
        }
    }
}
