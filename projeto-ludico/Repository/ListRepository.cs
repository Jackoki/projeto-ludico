﻿using Microsoft.Data.Sqlite;
using projeto_ludico.Database;
using projeto_ludico.Models;
using System;
using System.Windows.Forms;

namespace projeto_ludico.Repository
{
    internal class ListRepository
    {
        public void CreateList(ListModel listModel)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql;
                SqliteCommand command;

                // Realiza a adição da lista pela Query abaixo
                sql = "INSERT INTO lists (name, id_event) VALUES (@name, @id_event);";
                //Ocorre a atribuição de variáveis a partir do command, que resgata os valores do listModel passado no parâmetro
                command = new SqliteCommand(sql, connection);

                if (listModel.EventId == 0)
                {
                    command.Parameters.AddWithValue("@id_event", DBNull.Value);
                }

                else
                {
                    command.Parameters.AddWithValue("@id_event", listModel.EventId);
                }

                command.Parameters.AddWithValue("@name", listModel.name);

                command.ExecuteNonQuery();
            }
        }

        //Funcionamento basicamente identico com a função acima, única diferença seria a query do SQL, que é um Update
        public void UpdateList(ListModel listModel)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                // Certifique-se de que o nome da tabela e as colunas estejam corretos
                string sql = "UPDATE lists SET name = @Name WHERE id = @Id;";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", listModel.name);
                    command.Parameters.AddWithValue("@Id", listModel.id);
                    command.ExecuteNonQuery();
                }
            }
        }

        //Realiza a deleção da lista pelo Id na query
        public void DeleteList(int id)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string deleteGamesSql = "DELETE FROM board_games_list WHERE id_list = @id;";
                using (var deleteDependentsCommand = new SqliteCommand(deleteGamesSql, connection))
                {
                    // Adiciona o parâmetro do ID
                    deleteDependentsCommand.Parameters.AddWithValue("@id", id);
                    deleteDependentsCommand.ExecuteNonQuery();
                }

                string deleteListSql = "DELETE FROM lists WHERE id = @id;";
                using (var deleteListCommand = new SqliteCommand(deleteListSql, connection))
                {
                    deleteListCommand.Parameters.AddWithValue("@id", id);
                    deleteListCommand.ExecuteNonQuery();
                }
            }
        }

        //Funções abaixo adicionam e removem jogos à lista
        public void AddGameToList(int id_list, int id_board_game)
        {
            
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string checkSql = "SELECT COUNT(*) FROM board_games_list WHERE id_list = @id_list AND id_board_game = @id_board_game;";
                using (var checkCmd = new SqliteCommand(checkSql, connection))
                {
                    checkCmd.Parameters.AddWithValue("@id_list", id_list);
                    checkCmd.Parameters.AddWithValue("@id_board_game", id_board_game);

                    long count = (long)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Este jogo já está na lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Para aqui, não insere
                    }
                }

                string insertSql = "INSERT INTO board_games_list (id_list, id_board_game) VALUES (@id_list, @id_board_game);";
                using (var insertCmd = new SqliteCommand(insertSql, connection))
                {
                    insertCmd.Parameters.AddWithValue("@id_list", id_list);
                    insertCmd.Parameters.AddWithValue("@id_board_game", id_board_game);
                    insertCmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Jogo adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void RemoveGameFromList(int id_list, int id_board_game)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = "DELETE FROM board_games_list WHERE id_list = @id_list AND id_board_game = @id_board_game;";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_list", id_list);
                    command.Parameters.AddWithValue("@id_board_game", id_board_game);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
