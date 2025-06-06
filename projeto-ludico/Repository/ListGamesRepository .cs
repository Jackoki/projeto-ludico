using Microsoft.Data.Sqlite;
using projeto_ludico.Database;
using projeto_ludico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_ludico.Repository
{
    internal class ListGamesRepository
    {
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
                        return;
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
