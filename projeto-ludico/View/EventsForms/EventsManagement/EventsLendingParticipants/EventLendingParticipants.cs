using System;
using System.Collections.Generic;
using System.Windows.Forms;
using projeto_ludico.Controllers;
using projeto_ludico.View.EventsForms.EventsLendingParticipants;

namespace projeto_ludico.View.EventsForms.EventsManagement
{
    public partial class EventLendingParticipants : BaseForm
    {
        BoardGamesEventsWithdrawalController boardGamesEventsWithdrawalController = new BoardGamesEventsWithdrawalController();
        public int id_event;
        public EventLendingParticipants(int id_event) {
            this.id_event = id_event;
            InitializeComponent();
            ConfigureBoardGamesViewer();
        }

        public void ConfigureBoardGamesViewer() {
            dataViewer.Columns.Clear();
            dataViewer.DataSource = null;

            string[] desiredColumns = { "board_games_event_withdrawal.id as id", "COALESCE(board_games_names.name, '') AS board_game_name",
                                        "board_games_event_withdrawal.hour_withdrawal", "participants.name" };

            var columnMappings = new Dictionary<string, string> {
                { "id", "Id" },
                { "board_game_name", "Nome do Jogo" },
                { "hour_withdrawal", "Hora da Retirada" },
                { "name", "Nome do Participante" }
            };

            string joinClause = "INNER JOIN board_games ON (board_games.id = board_games_event_withdrawal.id_board_game and board_games_event_withdrawal.hour_devolution IS NULL)" +
                                "INNER JOIN participants ON (participants.id = board_games_event_withdrawal.id_participant and board_games_event_withdrawal.id_event = " + id_event + ")" +
                                "LEFT JOIN board_games_names ON (board_games_names.id_board_game = board_games.id AND board_games_names.is_principal = 1)";

            ConfigureDataViewerWithoutButtons(dataViewer, "board_games_event_withdrawal", desiredColumns, columnMappings, joinClause);

            OccultColumns(dataViewer, "id");

            // Define a ordem fixa das colunas
            EventLendingParticipantsUtil.SetColumnDisplayIndex(dataViewer, new[] { "Nome do Jogo", "Hora da Retirada", "Nome do Participante" });

            // Adiciona formatação de data/hora
            EventLendingParticipantsUtil.AddDateTimeFormatting(dataViewer, "Hora da Retirada", "dd/MM/yyyy HH:mm");

            // Adiciona botões personalizados
            EventLendingParticipantsUtil.AddCustomButtons(dataViewer, CreateReturnButton, CreateDeleteButton);
            labelCount.Text = dataViewer.Rows.Count.ToString();
        }

        public void ConfigureBoardGamesViewerDevolution() {
            dataViewer.Columns.Clear();
            dataViewer.DataSource = null;

            string[] desiredColumns = { "board_games_event_withdrawal.id as id", "COALESCE(CAST(board_games_names.name AS TEXT), '') AS board_game_name",
                        "board_games_event_withdrawal.hour_withdrawal", "board_games_event_withdrawal.hour_devolution", "participants.name" };

            var columnMappings = new Dictionary<string, string> {
                { "id", "Id" },
                { "board_game_name", "Nome do Jogo" },
                { "hour_withdrawal", "Hora da Retirada" },
                { "hour_devolution", "Hora da Devolução" },
                { "name", "Nome do Participante" }
             };

            string joinClause = "INNER JOIN board_games ON (board_games.id = board_games_event_withdrawal.id_board_game)" +
                                "INNER JOIN participants ON (participants.id = board_games_event_withdrawal.id_participant and board_games_event_withdrawal.id_event = " + id_event + ")" +
                                "LEFT JOIN board_games_names ON (board_games_names.id_board_game = board_games.id AND board_games_names.is_principal = 1)";

            ConfigureDataViewerWithoutButtons(dataViewer, "board_games_event_withdrawal", desiredColumns, columnMappings, joinClause);

            OccultColumns(dataViewer, "id");

            // Define a ordem fixa das colunas
            EventLendingParticipantsUtil.SetColumnDisplayIndex(dataViewer, new[] { "Nome do Jogo", "Hora da Retirada", "Hora da Devolução", "Nome do Participante" });

            // Adiciona formatação de data/hora
            EventLendingParticipantsUtil.AddDateTimeFormatting(dataViewer, "Hora da Retirada", "dd/MM/yyyy HH:mm");
            EventLendingParticipantsUtil.AddDateTimeFormatting(dataViewer, "Hora da Devolução", "dd/MM/yyyy HH:mm");

            // Adiciona botões personalizados
            EventLendingParticipantsUtil.AddCustomButtons(dataViewer, CreateDeleteButton);
        }

        private void checkBoxGames_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxGames.Checked) {
                ConfigureBoardGamesViewerDevolution();
            }

            else {
                ConfigureBoardGamesViewer();
            }
        }

        //Criação dos botões de devolver e deletar em cada linha de forma automática
        private void dataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataViewer.Rows[e.RowIndex];

            if (dataViewer.Columns[e.ColumnIndex].Name == "btnDelete") {
                boardGamesEventsWithdrawalController.RemoveGameWithdrawal(row);
            }

            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnReturn") {
                boardGamesEventsWithdrawalController.ReturnGameWithdrawal(row);
            }


            if (checkBoxGames.Checked) {
                ConfigureBoardGamesViewerDevolution();
            }

            else {
                ConfigureBoardGamesViewer();
            }
        }


    }
}
