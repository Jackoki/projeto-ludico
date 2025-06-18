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

namespace projeto_ludico.Repository
{
    internal class EscapeRoomsRepository
    {
        public void AddEscapeRooms(EscapeRoomsModel escapeRoomsModel) {
            using (var connection = DatabaseConnection.GetConnection())
            {
                // Realiza a adição do escape room pela Query abaixo
                string sql = @"INSERT INTO escape_rooms  (id_event, Name, Description) 
                             VALUES (@Id_Event, @Name, @Description);";

                //Ocorre a atribuição de variáveis a partir do command, que resgata os valores do escaperoomModel passado no parâmetro
                using (var command = new SqliteCommand(sql, connection))
                {
                    if(escapeRoomsModel.id_event == 0) {
                        command.Parameters.AddWithValue("@Id_Event", DBNull.Value);
                    }

                    else {
                        command.Parameters.AddWithValue("@Id_Event", escapeRoomsModel.id_event);
                    }

                    command.Parameters.AddWithValue("@Name", escapeRoomsModel.name);
                    command.Parameters.AddWithValue("@Description", escapeRoomsModel.description);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //Funcionamento basicamente identico com a função acima, única diferença seria a query do SQL, que é um Update
        public void UpdateEscapeRooms(EscapeRoomsModel escapeRoomsModel)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                // Certifique-se de que o nome da tabela e as colunas estejam corretos
                string sql = @"UPDATE escape_rooms 
                       SET id_event = @Id_Event, 
                           Name = @Name, 
                           Description = @Description
                       WHERE id = @Id;";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", escapeRoomsModel.name);
                    command.Parameters.AddWithValue("@Description", DbNullUtil.GetDBNullIfEmpty(escapeRoomsModel.description));
                    command.Parameters.AddWithValue("@Id_Event", DbNullUtil.GetDBNullIfEmpty(escapeRoomsModel.id_event));
                    command.Parameters.AddWithValue("@Id", escapeRoomsModel.Id);

                    // Abre a conexão e executa o comando
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    // Valida se alguma linha foi alterada
                    if (rowsAffected == 0) {
                        throw new InvalidOperationException("Nenhum escape room foi encontrado para atualização.");
                    }
                }
            }
        }

        //Realiza a deleção do escape room pelo Id na query
        public void DeleteEscapeRooms(int id)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = "DELETE FROM escape_rooms WHERE Id = @Id;";
                using (var command = new SqliteCommand(sql, connection))
                {
                    // Adiciona o parâmetro do ID
                    command.Parameters.AddWithValue("@Id", id);

                    // Executa o comando de exclusão
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0) {
                        throw new InvalidOperationException($"Nenhum escape room encontrado.");
                    }
                }
            }
        }

        //Retorna todas as informações do EscapeRoomModel a partir do SELECT filtrado pelo id no parâmetro
        public EscapeRoomsModel GetEscapeRoomsById(int id) {
            EscapeRoomsModel escapeRoomsModel = new EscapeRoomsModel();

            try {
                using (var connection = DatabaseConnection.GetConnection()) {
                    string sql = @"SELECT id, Name, Description, id_event 
                           FROM escape_rooms 
                           WHERE Id = @Id;";

                    using (var command = new SqliteCommand(sql, connection)) {
                        // Adiciona o parâmetro do ID
                        command.Parameters.AddWithValue("@Id", id);

                        using (var reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                // Inicializa o modelo apenas se o participante for encontrado
                                escapeRoomsModel = new EscapeRoomsModel
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    name = reader.GetString(reader.GetOrdinal("name")),
                                    description = reader.IsDBNull(reader.GetOrdinal("description")) ? "" : reader.GetString(reader.GetOrdinal("description")),
                                    id_event = reader.IsDBNull(reader.GetOrdinal("id_event")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_event"))
                                };
                            }
                        }
                    }
                }
            }

            catch (Exception ex) {
                // Lidar com exceções relacionadas ao banco de dados ou outras
                throw new InvalidOperationException("Erro ao buscar escape rooms no banco de dados.", ex);
            }

            return escapeRoomsModel;
        }



    }
}
