using System.Collections.Generic;
using projeto_ludico.Models;
using System.Windows.Forms;

namespace projeto_ludico.View.EventsForms.EventsManagement.EventsGames
{
    internal class EventGamesUtil {
        public static void UpdateComboBoxGames(ComboBox comboBox, BoardGamesEventsModel boardGamesEventsModel) {
            if (boardGamesEventsModel != null) {
                comboBox.DataSource = new List<BoardGamesEventsModel> { boardGamesEventsModel };
                comboBox.ValueMember = nameof(boardGamesEventsModel.id_board_game);
                comboBox.DisplayMember = nameof(boardGamesEventsModel.board_games_name);
                comboBox.SelectedValue = boardGamesEventsModel.id_board_game;
            }
            else {
                comboBox.DataSource = null;
                comboBox.Text = string.Empty;
            }
        }

        public static void AdjustColumnNameGame(DataGridView dataGridView) {
            if (dataGridView.Columns.Contains("Nome do Jogo")) {
                var col = dataGridView.Columns["Nome do Jogo"];
                if (col is DataGridViewImageColumn) {
                    int index = col.Index;
                    dataGridView.Columns.RemoveAt(index);
                    dataGridView.Columns.Insert(index, new DataGridViewTextBoxColumn {
                        Name = "Nome do Jogo",
                        HeaderText = "Nome do Jogo",
                        DataPropertyName = "Nome do Jogo"
                    });
                }
            }
        }

    }
}
