using System;
using Microsoft.Data.Sqlite;
using projeto_ludico.Database;
using projeto_ludico.Models;
using projeto_ludico.Utils;

namespace projeto_ludico.Repository
{
    internal class ParticipantRepository
    {
        public void AddParticipant(ParticipantsModel participantsModel) {
            using (var connection = DatabaseConnection.GetConnection())
            {
                // Realiza a adição do participante pela Query abaixo
                string sql = @"INSERT INTO participants  (id_institution, Name, Email, CPF, Code) 
                             VALUES (@Id_Institution, @Name, @Email, @CPF, @Code);";

                //Ocorre a atribuição de variáveis a partir do command, que resgata os valores do participantModel passado no parâmetro
                using (var command = new SqliteCommand(sql, connection))
                {
                    if(participantsModel.id_institution == 0) {
                        command.Parameters.AddWithValue("@Id_Institution", DBNull.Value);
                    }

                    else {
                        command.Parameters.AddWithValue("@Id_Institution", participantsModel.id_institution);
                    }

                    command.Parameters.AddWithValue("@Name", participantsModel.name);
                    command.Parameters.AddWithValue("@Email", participantsModel.email);
                    command.Parameters.AddWithValue("@CPF", participantsModel.cpf);
                    command.Parameters.AddWithValue("@Code", participantsModel.code);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //Funcionamento basicamente identico com a função acima, única diferença seria a query do SQL, que é um Update
        public void UpdateParticipant(ParticipantsModel participantsModel)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                // Certifique-se de que o nome da tabela e as colunas estejam corretos
                string sql = @"UPDATE participants 
                       SET id_institution = @Id_Institution, 
                           Name = @Name, 
                           Email = @Email, 
                           CPF = @CPF, 
                           Code = @Code 
                       WHERE id = @Id;";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", participantsModel.name);
                    command.Parameters.AddWithValue("@Email", DbNullUtil.GetDBNullIfEmpty(participantsModel.email));
                    command.Parameters.AddWithValue("@CPF", DbNullUtil.GetDBNullIfEmpty(participantsModel.cpf));
                    command.Parameters.AddWithValue("@Code", DbNullUtil.GetDBNullIfEmpty(participantsModel.code));
                    command.Parameters.AddWithValue("@Id_Institution", DbNullUtil.GetDBNullIfEmpty(participantsModel.id_institution));
                    command.Parameters.AddWithValue("@Id", participantsModel.Id);

                    Console.WriteLine(participantsModel.Id);
                    Console.WriteLine(participantsModel.name);
                    Console.WriteLine(participantsModel.email);
                    Console.WriteLine(participantsModel.cpf);
                    Console.WriteLine(participantsModel.code);
                    Console.WriteLine(participantsModel.id_institution);


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
        public void DeleteParticipant(int id)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = "DELETE FROM participants WHERE Id = @Id;";
                using (var command = new SqliteCommand(sql, connection))
                {
                    // Adiciona o parâmetro do ID
                    command.Parameters.AddWithValue("@Id", id);

                    // Executa o comando de exclusão
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0) {
                        throw new InvalidOperationException($"Nenhum participante encontrado.");
                    }
                }
            }
        }

        //Retorna todas as informações do ParticipantModel a partir do SELECT filtrado pelo id no parâmetro
        public ParticipantsModel GetParticipantById(int id) {
            ParticipantsModel participantsModel = new ParticipantsModel();

            try {
                using (var connection = DatabaseConnection.GetConnection()) {
                    string sql = @"SELECT id, Name, Email, cpf, code, id_institution 
                           FROM participants 
                           WHERE Id = @Id;";

                    using (var command = new SqliteCommand(sql, connection)) {
                        // Adiciona o parâmetro do ID
                        command.Parameters.AddWithValue("@Id", id);

                        using (var reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                // Inicializa o modelo apenas se o participante for encontrado
                                participantsModel = new ParticipantsModel {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    name = reader.GetString(reader.GetOrdinal("name")),
                                    email = reader.IsDBNull(reader.GetOrdinal("email")) ? "" : reader.GetString(reader.GetOrdinal("email")),
                                    cpf = reader.IsDBNull(reader.GetOrdinal("cpf")) ? "" : reader.GetString(reader.GetOrdinal("cpf")),
                                    code = reader.IsDBNull(reader.GetOrdinal("code")) ? "" : reader.GetString(reader.GetOrdinal("code")),
                                    id_institution = reader.IsDBNull(reader.GetOrdinal("id_institution")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_institution"))
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
