using Microsoft.Data.Sqlite;
using projeto_ludico.Controllers;
using projeto_ludico.Database;
using projeto_ludico.Models;
using projeto_ludico.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_ludico.View.ListForms
{
    public partial class ListManager : BaseForm
    {
        private int id_list;

        public ListManager()
        {
            InitializeComponent();
            LoadBoardGames();
            dataViewer.CellContentClick += DataViewer_CellContentClick;
        }

        private void LoadBoardGames()
        {
            var comboBoxLoader = new ComboBoxLoader();
            comboBoxLoader.LoadComboBox(comboBox1, "board_games_names", "id", "name");
        }

        internal void ManageList(DataGridViewRow row)
        {
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id))
            {
                id_list = id;
                ConfigureGameListViewer(id_list);
            }
        }

        private void ConfigureGameListViewer(int listId)
        {
            var jogos = new List<(int id, string name)>();

            using (var connection = GetOpenConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = @"
            SELECT bgl.id_board_game, bgn.name
            FROM board_games_list bgl
            INNER JOIN board_games_names bgn 
                ON bgn.id = bgl.id_board_game
            WHERE bgl.id_list = $listId
        ";
                command.Parameters.AddWithValue("$listId", listId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idGame = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        jogos.Add((idGame, name));
                    }
                }
            }

            // Limpa e configura manualmente o DataGridView
            dataViewer.Columns.Clear();
            dataViewer.Rows.Clear();

            dataViewer.Columns.Add("id", "ID do Jogo");
            dataViewer.Columns.Add("name", "Nome do Jogo");

            foreach (var jogo in jogos)
            {
                dataViewer.Rows.Add(jogo.id, jogo.name);
            }

            dataViewer.Columns["id"].Visible = false;

            // Botão de ação
            if (!dataViewer.Columns.Contains("btnRemove"))
            {
                var btnRemove = new DataGridViewButtonColumn
                {
                    Name = "btnRemove",
                    HeaderText = "",
                    Text = "Remover",
                    UseColumnTextForButtonValue = true
                };
                dataViewer.Columns.Add(btnRemove);
            }
        }
        private SqliteConnection GetOpenConnection()
        {
            var connection = DatabaseConnection.GetConnection();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            return connection;
        }

        private void DataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Confere se clicou na coluna do botão "Remover"
            if (dataViewer.Columns[e.ColumnIndex].Name == "btnRemove" && e.RowIndex >= 0)
            {
                // Obtem o id do jogo daquela linha
                int idGame = Convert.ToInt32(dataViewer.Rows[e.RowIndex].Cells["id"].Value);

                // Chama o método para remover o jogo da lista
                var controller = new ListController();
                controller.RemoveGame(id_list, idGame);
            }
            ConfigureGameListViewer(id_list);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Selecione um jogo para adicionar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id_board_game = Convert.ToInt32((comboBox1.SelectedValue ?? 0));
            if (id_board_game == 0)
            {
                MessageBox.Show("Erro ao obter o ID do jogo selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var controller = new ListController();
            controller.AddGame(id_list, id_board_game);
            ConfigureGameListViewer(id_list);
        }


    }
}
