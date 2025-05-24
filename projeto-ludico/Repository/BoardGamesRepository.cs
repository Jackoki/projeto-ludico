using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    internal class BoardGamesRepository
    {
        public void AddBoardGames(BoardGamesModel boardgamesModel) {
            using (var connection = DatabaseConnection.GetConnection())
            {
                // Realiza a adição do participante pela Query abaixo
                string sql = @"INSERT INTO board_games  (name, description, min_players, max_players, game_time) 
                             VALUES (@Name, @Description, @Min_players, @Max_players, @Game_time);";

                //Ocorre a atribuição de variáveis a partir do command, que resgata os valores do participantModel passado no parâmetro
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", boardgamesModel.name);
                    command.Parameters.AddWithValue("@Description", boardgamesModel.description);
                    command.Parameters.AddWithValue("@Min_players", boardgamesModel.min_players);
                    command.Parameters.AddWithValue("@Max_players", boardgamesModel.max_players);
                    command.Parameters.AddWithValue("@Game_time", boardgamesModel.game_time);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //Funcionamento basicamente identico com a função acima, única diferença seria a query do SQL, que é um Update
        public void UpdateBoardGames(BoardGamesModel boardgamesModel)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                // Certifique-se de que o nome da tabela e as colunas estejam corretos
                string sql = @"UPDATE board_games 
                       SET Name = @Name,
                           Description = @Description, 
                           Min_players = @Min_players, 
                           Max_players = @Max_players, 
                           Game_time = @Game_time 
                       WHERE id = @Id;";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", boardgamesModel.name);
                    command.Parameters.AddWithValue("@Description", boardgamesModel.description);
                    command.Parameters.AddWithValue("@Min_players", DbNullUtil.GetDBNullIfEmpty(boardgamesModel.min_players));
                    command.Parameters.AddWithValue("@Max_players", DbNullUtil.GetDBNullIfEmpty(boardgamesModel.max_players));
                    command.Parameters.AddWithValue("@Game_time", DbNullUtil.GetDBNullIfEmpty(boardgamesModel.game_time));
                    command.Parameters.AddWithValue("@Id", boardgamesModel.id);

                    Console.WriteLine(boardgamesModel.id);
                    Console.WriteLine(boardgamesModel.name);
                    Console.WriteLine(boardgamesModel.description);
                    Console.WriteLine(boardgamesModel.min_players);
                    Console.WriteLine(boardgamesModel.max_players);
                    Console.WriteLine(boardgamesModel.game_time);


                    // Abre a conexão e executa o comando
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    // Valida se alguma linha foi alterada
                    if (rowsAffected == 0) {
                        throw new InvalidOperationException("Nenhum participante foi encontrado para atualização.");
                    }
                }
            }
        }

        //Realiza a deleção do participante pelo Id na query
        public void DeleteBoardGames(int id)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = "DELETE FROM board_games WHERE Id = @Id;";
                using (var command = new SqliteCommand(sql, connection))
                {
                    // Adiciona o parâmetro do ID
                    command.Parameters.AddWithValue("@Id", id);

                    // Executa o comando de exclusão
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0) {
                        throw new InvalidOperationException($"Nenhum jogo encontrado.");
                    }
                }
            }
        }

        //Retorna todas as informações do ParticipantModel a partir do SELECT filtrado pelo id no parâmetro
        public BoardGamesModel GetBoardGamesById(int id) {
            BoardGamesModel boardgamesModel = new BoardGamesModel();

            try {
                using (var connection = DatabaseConnection.GetConnection()) {
                    string sql = @"SELECT id, Description, Min_players, Max_players, Game_time 
                           FROM board_games
                           WHERE Id = @Id;";

                    using (var command = new SqliteCommand(sql, connection)) {
                        // Adiciona o parâmetro do ID
                        command.Parameters.AddWithValue("@Id", id);

                        using (var reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                // Inicializa o modelo apenas se o participante for encontrado
                                boardgamesModel = new BoardGamesModel {
                                    id = reader.GetInt32(reader.GetOrdinal("id")),
                                    name = reader.GetString(reader.GetOrdinal("name")),
                                    description = reader.GetString(reader.GetOrdinal("description")),
                                    min_players = reader.GetInt32(reader.GetOrdinal("min_players")),
                                    max_players = reader.GetInt32(reader.GetOrdinal("max_players")),
                                    game_time = reader.GetInt32(reader.GetOrdinal("game_time"))
                                };
                            }
                        }
                    }
                }
            }

            catch (Exception ex) {
                // Lidar com exceções relacionadas ao banco de dados ou outras
                throw new InvalidOperationException("Erro ao buscar participante no banco de dados.", ex);
            }

            return boardgamesModel;
        }



    }
}
