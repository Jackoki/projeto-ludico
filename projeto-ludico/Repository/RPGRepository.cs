using Microsoft.Data.Sqlite;
using projeto_ludico.Database;
using projeto_ludico.Models;
using System;

namespace projeto_ludico.Repository
{
    public class RPGRepository
    {
        public void AddRPG(string name, string description)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                // Realiza a adição do RPG pela Query abaixo
                string sql = "INSERT INTO role_play_games (Name, Description) VALUES (@Name, @Description);";
                //Ocorre a atribuição de variáveis a partir do command, que resgata os valores do RPGModel passado no parâmetro
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Description", description ?? "");
                    command.ExecuteNonQuery();
                }
            }
        }

        //Funcionamento basicamente identico com a função acima, única diferença seria a query do SQL, que é um Update
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

        //Realiza a deleção do RPG pelo Id na query
        public void DeleteRPG(int id)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = "DELETE FROM role_play_games WHERE Id = @Id;";
                using (var command = new SqliteCommand(sql, connection))
                {
                    // Abre a conexão e executa o comando
                    command.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = command.ExecuteNonQuery();

                    // Valida se alguma linha foi alterada
                    if (rowsAffected == 0)
                        throw new InvalidOperationException("Nenhum RPG encontrado.");
                }
            }
        }

        //Retorna todas as informações do RPGModel a partir do SELECT filtrado pelo id no parâmetro
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
                                // Inicializa o modelo apenas se o RPG for encontrado
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
