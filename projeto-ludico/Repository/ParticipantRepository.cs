using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using projeto_ludico.Database;
using projeto_ludico.Models;

namespace projeto_ludico.Repository
{
    internal class ParticipantRepository
    {

        public void AddParticipant(ParticipantsModel participantsModel) {
            using (var connection = DatabaseConnection.GetConnection())
            {
                // Certifique-se de que o nome da tabela e as colunas estejam corretos
                string sql = @"INSERT INTO participants  (id_institution, Name, Email, CPF, Code) 
                             VALUES (@Id_Institution, @Name, @Email, @CPF, @Code);";

                using (var command = new SqliteCommand(sql, connection))
                {
                    // Adiciona os parâmetros com base nas propriedades do modelo
                    command.Parameters.AddWithValue("@Id_Institution", participantsModel.id_institution);
                    command.Parameters.AddWithValue("@Name", participantsModel.name);
                    command.Parameters.AddWithValue("@Email", participantsModel.email);
                    command.Parameters.AddWithValue("@CPF", participantsModel.cpf);
                    command.Parameters.AddWithValue("@Code", participantsModel.code);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


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
    }
}
