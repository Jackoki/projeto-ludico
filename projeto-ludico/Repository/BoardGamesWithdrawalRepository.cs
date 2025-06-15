using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using projeto_ludico.Database;
using projeto_ludico.Models;

namespace projeto_ludico.Repository
{
    internal class BoardGamesEventsWithdrawalRepository {
        public void AddGame(int id_event, int id_board_game, int id_participant)
        {
            using (var connection = DatabaseConnection.GetConnection()) {
                string insertSql = @"INSERT INTO board_games_event_withdrawal 
                             (id_event, id_participant, id_board_game, hour_withdrawal, hour_devolution) 
                             VALUES (@Id_event, @Id_participant, @Id_board_game, @Hour_withdrawal, NULL);";

                using (var insertCommand = new SqliteCommand(insertSql, connection)) {
                    insertCommand.Parameters.AddWithValue("@Id_event", id_event);
                    insertCommand.Parameters.AddWithValue("@Id_participant", id_participant);
                    insertCommand.Parameters.AddWithValue("@Id_board_game", id_board_game);
                    insertCommand.Parameters.AddWithValue("@Hour_withdrawal", DateTime.Now);

                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void RemoveGameWithdrawal(int id) {
            using (var connection = DatabaseConnection.GetConnection()) {
                string deleteSql = "DELETE FROM board_games_event_withdrawal WHERE id = @Id";

                using (var deleteCommand = new SqliteCommand(deleteSql, connection)) {
                    deleteCommand.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    deleteCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void ReturnGameWithdrawal(int id) {
            using (var connection = DatabaseConnection.GetConnection()) {
                string updateSql = "UPDATE board_games_event_withdrawal SET hour_devolution = @HourDevolution WHERE id = @Id";

                using (var updateCommand = new SqliteCommand(updateSql, connection)) {
                    updateCommand.Parameters.AddWithValue("@HourDevolution", DateTime.Now);
                    updateCommand.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }



        public Dictionary<int, string> PerformSearchBoardGame(string searchText) {
            var results = new Dictionary<int, string>();

            try {
                using (var connection = DatabaseConnection.GetConnection()) {
                    string sql = @"SELECT bg.id, bgn.name FROM board_games bg
                           INNER JOIN board_games_events bge ON (bge.id_board_game = bg.id)
                           LEFT JOIN board_games_bar_codes bgbc ON (bgbc.id_board_game = bg.id)
                           LEFT JOIN board_games_names bgn ON (bgn.id_board_game = bg.id)
                           WHERE bgn.name LIKE @SearchText OR bgbc.bar_code LIKE @SearchText";

                    using (var command = new SqliteCommand(sql, connection)) {
                        command.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                        using (var reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                string name = reader.GetString(reader.GetOrdinal("name"));

                                if (!results.ContainsKey(id)) {
                                    results.Add(id, name);
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception ex)  {
                throw new InvalidOperationException("Erro ao buscar jogos no banco de dados.", ex);
            }

            return results;
        }

        public ParticipantsModel PerformSearchParticipant(string searchText) {
            ParticipantsModel participantsModel = null; // Inicializa como null
            bool found = false;

            try  {
                using (var connection = DatabaseConnection.GetConnection()) {
                    string sql = @"SELECT p.id, p.name FROM participants p
                           INNER JOIN participants_events pe ON (pe.id_participant = p.id)
                           WHERE p.name LIKE @SearchText";

                    using (var command = new SqliteCommand(sql, connection)) {
                        command.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                        using (var reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                participantsModel = new ParticipantsModel
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    name = reader.GetString(reader.GetOrdinal("name"))
                                };
                                found = true;
                            }
                        }
                    }
                }

                if (!found) {
                    throw new InvalidOperationException("Nenhum participante encontrado com o texto pesquisado.");
                }
            }

            catch (Exception ex) when (!(ex is InvalidOperationException)) {
                throw new InvalidOperationException("Erro ao buscar participante no banco de dados.", ex);
            }

            return participantsModel;
        }







    }
}
