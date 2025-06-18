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
    public class RPGCampaignRepository
    {
        public void AddRPGCampaign(RPGCampaignModel rpgCampaignModel) {
            using (var connection = DatabaseConnection.GetConnection())  {
                // Realiza a adição da campanha pela Query abaixo
                string sql = "INSERT INTO role_play_games_campaigns (name, description, id_role_play_game, id_event) " +
                             "VALUES (@Name, @Description, @Id_role_play_game, @Id_event);";

                //Ocorre a atribuição de variáveis a partir do command, que resgata os valores do rpgCampaignModel passado no parâmetro
                using (var command = new SqliteCommand(sql, connection)) {
                    if (rpgCampaignModel.id_event == 0) {
                        command.Parameters.AddWithValue("@Id_event", DBNull.Value);
                    }

                    else {
                        command.Parameters.AddWithValue("@Id_event", rpgCampaignModel.id_event);
                    }

                    command.Parameters.AddWithValue("@Name", rpgCampaignModel.name);
                    command.Parameters.AddWithValue("@Description", rpgCampaignModel.description ?? "");
                    command.Parameters.AddWithValue("@Id_role_play_game", rpgCampaignModel.id_role_play_game);
                    command.ExecuteNonQuery();
                }
            }
        }

        //Realiza a deleção da campanha pelo Id na query
        public void DeleteRPGCampaign(int id)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = "DELETE FROM role_play_games_campaigns WHERE Id = @Id;";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        throw new InvalidOperationException("Nenhuma campanha encontrada.");
                }
            }
        }

        public void AddParticipant(int id_role_play_game_campaign, int id_participant)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                // Verifica se o participante já está registrado na campanha
                string checkSql = "SELECT COUNT(*) FROM participants_role_play_games_campaign " +
                                  "WHERE id_role_play_game_campaign = @Id_role_play_game_campaign " +
                                  "AND id_participant = @Id_participant;";

                using (var checkCommand = new SqliteCommand(checkSql, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Id_role_play_game_campaign", id_role_play_game_campaign);
                    checkCommand.Parameters.AddWithValue("@Id_participant", id_participant);

                    long count = (long)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        throw new InvalidOperationException("O participante já está registrado nesta campanha.");
                    }
                }

                // Insere o participante na campanha
                string insertSql = "INSERT INTO participants_role_play_games_campaign (id_role_play_game_campaign, id_participant) " +
                                   "VALUES (@Id_role_play_game_campaign, @Id_participant);";

                using (var insertCommand = new SqliteCommand(insertSql, connection))
                {
                    insertCommand.Parameters.AddWithValue("@Id_role_play_game_campaign", id_role_play_game_campaign);
                    insertCommand.Parameters.AddWithValue("@Id_participant", id_participant);
                    insertCommand.ExecuteNonQuery();
                }
            }
        }


        //Realiza a deleção do participante na campanha pelo Id na query
        public void RemoveParticipant(int id) {
            using (var connection = DatabaseConnection.GetConnection()) {
                string sql = "DELETE FROM participants_role_play_games_campaign WHERE Id = @Id;";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        throw new InvalidOperationException("Nenhuma campanha encontrada.");
                }
            }
        }

        


    }
}
