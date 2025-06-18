using System;
using Microsoft.Data.Sqlite;
using projeto_ludico.Database;
using projeto_ludico.Models;

namespace projeto_ludico.Repository
{
    internal class ParticipantEventRepository
    {
        public void AddParticipant(ParticipantsEventsModel participantsEventsModel)
        {
            using (var connection = DatabaseConnection.GetConnection()) {
                connection.Open();

                // Verifica se o participante já está cadastrado no evento
                string checkSql = @"SELECT COUNT(*) FROM participants_events 
                                  WHERE id_event = @IdEvent AND id_participant = @IdParticipant;";

                using (var checkCommand = new SqliteCommand(checkSql, connection)) {
                    checkCommand.Parameters.AddWithValue("@IdEvent", participantsEventsModel.id_event);
                    checkCommand.Parameters.AddWithValue("@IdParticipant", participantsEventsModel.id_participant);

                    // Executa a consulta e obtém o resultado
                    long count = (long)checkCommand.ExecuteScalar();

                    if (count > 0) {
                        throw new InvalidOperationException("O participante já está cadastrado neste evento.");
                    }
                }

                // Insere o novo participante no evento
                string insertSql = @"INSERT INTO participants_events (arrived_hour, id_event, id_participant) 
                                   VALUES (@ArrivedHour, @IdEvent, @IdParticipant);";

                using (var insertCommand = new SqliteCommand(insertSql, connection)) {
                    insertCommand.Parameters.AddWithValue("@ArrivedHour", participantsEventsModel.arrived_hour);
                    insertCommand.Parameters.AddWithValue("@IdEvent", participantsEventsModel.id_event);
                    insertCommand.Parameters.AddWithValue("@IdParticipant", participantsEventsModel.id_participant);

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    if (rowsAffected == 0) {
                        throw new InvalidOperationException("Não foi possível adicionar o participante.");
                    }
                }
            }
        }



        //Realiza a deleção do participante pelo Id na query
        public void DeleteParticipant(int id)
        {
            using (var connection = DatabaseConnection.GetConnection()) {
                string sql = "DELETE FROM participants_events WHERE Id = @Id;";

                using (var command = new SqliteCommand(sql, connection)) {
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0) {
                        throw new InvalidOperationException("Participante não encontrado para deletar.");
                    }
                }
            }
        }


        //Retorna todas as informações do ParticipantModel a partir do SELECT filtrado pelo id no parâmetro
        // Retorna todas as informações do ParticipantModel a partir do SELECT filtrado pelo searchText nos parâmetros
        public ParticipantsModel PerformSearch(string searchText)
        {
            ParticipantsModel participantsModel = null;

            try {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    // Consulta que busca pelo Name, Code ou Cpf
                    string sql = @"SELECT id, Name 
                                 FROM participants 
                                 WHERE name LIKE @SearchText 
                                 OR code LIKE @SearchText 
                                 OR cpf LIKE @SearchText;";

                    using (var command = new SqliteCommand(sql, connection)) {
                        // Adiciona o parâmetro com wildcard para a busca
                        command.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                        using (var reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                // Inicializa o modelo apenas se o participante for encontrado
                                participantsModel = new ParticipantsModel
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    name = reader.GetString(reader.GetOrdinal("Name"))
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

            return participantsModel;
        }






    }
}
