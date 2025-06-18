using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using projeto_ludico.Database;
using projeto_ludico.Models;
using projeto_ludico.Utils;
using projeto_ludico.View.BoardGamesForms;

namespace projeto_ludico.Repository
{
    internal class BoardGamesEventsRepository {
        public void AddBoardGamesEvent(BoardGamesEventsModel boardGamesEventModel) {
            using (var connection = DatabaseConnection.GetConnection()) {
                // Verificar se o registro já existe
                string checkSql = @"SELECT COUNT(1) FROM board_games_events 
                                  WHERE id_event = @Id_event AND id_board_game = @Id_board_game;";

                using (var checkCommand = new SqliteCommand(checkSql, connection)) {
                    checkCommand.Parameters.AddWithValue("@Id_event", boardGamesEventModel.id_event);
                    checkCommand.Parameters.AddWithValue("@Id_board_game", boardGamesEventModel.id_board_game);

                    connection.Open();
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                    connection.Close();

                    if (count > 0) {
                        throw new InvalidOperationException("Já existe um registro com o mesmo jogo.");
                    }
                }

                // Inserir o novo registro
                string insertSql = @"INSERT INTO board_games_events 
                             (details, is_available, removal_time, id_participant, id_board_game, id_event) 
                             VALUES (@Details, @Is_available, @Removal_time, @Id_participant, @Id_board_game, @Id_event);";

                using (var insertCommand = new SqliteCommand(insertSql, connection)) {
                    if (boardGamesEventModel.id_participant == 0) {
                        insertCommand.Parameters.AddWithValue("@Id_participant", DBNull.Value);
                    }

                    else {
                        insertCommand.Parameters.AddWithValue("@Id_participant", boardGamesEventModel.id_participant);
                    }

                    insertCommand.Parameters.AddWithValue("@Details", boardGamesEventModel.details);
                    insertCommand.Parameters.AddWithValue("@Is_available", boardGamesEventModel.is_available ? 1 : 0);
                    insertCommand.Parameters.AddWithValue("@Removal_time", DateTime.Now);
                    insertCommand.Parameters.AddWithValue("@Id_board_game", boardGamesEventModel.id_board_game);
                    insertCommand.Parameters.AddWithValue("@Id_event", boardGamesEventModel.id_event);

                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                }
            }
        }



        //Realiza a deleção do participante pelo Id na query
        public void DeleteBoardGamesEvent(int id) {
            using (var connection = DatabaseConnection.GetConnection()) {
                string sql = "DELETE FROM board_games_events WHERE Id = @Id;";
                using (var command = new SqliteCommand(sql, connection)) {
                    // Adiciona o parâmetro do ID
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0) {
                        throw new InvalidOperationException($"Nenhum jogo encontrado.");
                    }
                }
            }
        }
        public BoardGamesEventsModel PerformSearch(string searchText)
        {
            BoardGamesEventsModel boardGamesEventsModel = null;

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    // Consulta que busca pelo Name, Code ou Cpf
                    string sql = @"SELECT bg.id, bgn.name FROM board_games bg
                                 LEFT JOIN board_games_bar_codes bgbc ON (bgbc.id_board_game = bg.id)
                                 LEFT JOIN board_games_names bgn ON (bgn.id_board_game = bg.id AND bgn.is_principal = 1)
                                 WHERE bgn.name LIKE @SearchText OR bgbc.bar_code LIKE @SearchText";

                    using (var command = new SqliteCommand(sql, connection))
                    {
                        // Adiciona o parâmetro com wildcard para a busca
                        command.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Inicializa o modelo apenas se o participante for encontrado
                                boardGamesEventsModel = new BoardGamesEventsModel
                                {
                                    id_board_game = reader.GetInt32(reader.GetOrdinal("id")),
                                    board_games_name = reader.GetString(reader.GetOrdinal("name"))
                                };

                            }
                        }
                    }
                }
            }

            catch (Exception ex) {
                throw new InvalidOperationException("Erro ao buscar jogo no banco de dados.", ex);
            }

            return boardGamesEventsModel;
        }

        // Método que busca todos os participantes associados a um evento específico
        public List<ParticipantsModel> GetParticipantsByEventId(int eventId){
            string query = @"SELECT p.id, p.name 
                     FROM participants_events pe
                     LEFT JOIN participants p ON pe.id_participant = p.id
                     WHERE pe.id_event = @IdEvent";

            // Lista que irá armazenar os participantes encontrados
            List<ParticipantsModel> participants = new List<ParticipantsModel>();

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdEvent", eventId);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                participants.Add(new ParticipantsModel
                                {
                                    Id = reader.GetInt32(0),
                                    name = reader.GetString(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw new InvalidOperationException("Erro ao buscar participantes no banco de dados.", ex);
            }

            return participants;
        }

        // Método que retorna todas as listas cadastradas no banco de dados
        public List<ListModel> GetListsByEventId() {
            string query = @"SELECT l.id, l.name  FROM lists l";

            // Lista que irá armazenar os resultados
            List<ListModel> lists = new List<ListModel>();

            try {
                using (var connection = DatabaseConnection.GetConnection()) {
                    using (var command = new SqliteCommand(query, connection)) {
                        using (var reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                lists.Add(new ListModel {
                                    id = reader.GetInt32(0),
                                    name = reader.GetString(1)
                                });
                            }
                        }
                    }
                }
            }

            catch (Exception ex) {
                throw new InvalidOperationException("Erro ao buscar listas no banco de dados.", ex);
            }

            return lists;
        }


        public void AddBoardGamesEventByList(int id_list, int id_event) {
            using (var connection = DatabaseConnection.GetConnection()) {
                // Recuperar os jogos associados ao id_list
                string fetchSql = @"SELECT id_board_game FROM board_games_list WHERE id_list = @Id_list;";
                List<int> boardGameIds = new List<int>();

                using (var fetchCommand = new SqliteCommand(fetchSql, connection)) {
                    fetchCommand.Parameters.AddWithValue("@Id_list", id_list);
                    connection.Open();

                    using (var reader = fetchCommand.ExecuteReader()) { 
                        while (reader.Read()) {
                            boardGameIds.Add(reader.GetInt32(0));
                        }
                    }
                }

                if (boardGameIds.Count == 0) {
                    throw new InvalidOperationException("Nenhum jogo encontrado para a lista escolhida.");
                }

                string insertSql = @"INSERT INTO board_games_events (details, is_available, id_participant, id_board_game, id_event)
                                   SELECT NULL, @IsAvailable, NULL, @IdBoardGame, @IdEvent
                                   WHERE NOT EXISTS (SELECT 1 FROM board_games_events WHERE id_board_game = @IdBoardGame AND id_event = @IdEvent);";

                using (var insertCommand = new SqliteCommand(insertSql, connection)) {
                    connection.Open();

                    foreach (var boardGameId in boardGameIds) {
                        try {
                            insertCommand.Parameters.Clear();
                            insertCommand.Parameters.AddWithValue("@IsAvailable", true);
                            insertCommand.Parameters.AddWithValue("@IdBoardGame", boardGameId);
                            insertCommand.Parameters.AddWithValue("@IdEvent", id_event);

                            insertCommand.ExecuteNonQuery();
                        }

                        catch (SqliteException ex) {
                            Console.WriteLine($"Erro ao inserir jogo: {ex.Message}");
                        }
                    }
                }
            }
        }





    }




}

