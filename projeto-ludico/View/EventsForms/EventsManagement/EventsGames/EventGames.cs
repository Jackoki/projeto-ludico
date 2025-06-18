using System;
using System.Collections.Generic;
using System.Windows.Forms;
using projeto_ludico.Controllers;
using projeto_ludico.Models;
using projeto_ludico.View.EventsForms.EventsManagement.EventsGames;

namespace projeto_ludico.View.EventsForms.EventsManagement
{
    public partial class EventGames : BaseForm
    {
        BoardGamesEventsController boardGamesEventsController = new BoardGamesEventsController();
        public int id_event;


        public EventGames(int id)
        {
            this.id_event = id;
            InitializeComponent();
            LoadEventGames();
        }

        private void LoadEventGames()
        {
            string tableName = "board_games_events";
            string[] columns = { "board_games_events.id", "COALESCE(board_games_names.name, '') AS name" };

            Dictionary<string, string> columnMappings = new Dictionary<string, string> {
                { "name", "Nome do Jogo" }
            };

            string joinClause = "INNER JOIN board_games ON (board_games.id = board_games_events.id_board_game and board_games_events.id_event = " + id_event + ")" +
                                "LEFT JOIN board_games_names ON (board_games_names.id_board_game = board_games.id AND board_games_names.is_principal = 1)";

            ConfigureDataViewerWithoutButtons(dataViewer, tableName, columns, columnMappings, joinClause);
            EventGamesUtil.AdjustColumnNameGame(dataViewer);

            OccultColumns(dataViewer, "id");

            // Verifica se o botão delete já foi adicionado
            if (!dataViewer.Columns.Contains("btnDelete"))
            {
                var deleteButton = CreateDeleteButton();
                dataViewer.Columns.Add(deleteButton);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e) {
            string searchString = textBoxGame.Text.Trim();
            BoardGamesEventsModel boardGamesEventsModel = boardGamesEventsController.PerformSearch(searchString);
            UpdateComboBoxGames(boardGamesEventsModel);
        }

        private void UpdateComboBoxGames(BoardGamesEventsModel boardGamesEventsModel) {
            EventGamesUtil.UpdateComboBoxGames(comboBoxBoardGame, boardGamesEventsModel);
        }
        private void UpdateComboBoxLists(object sender, EventArgs e) {
            boardGamesEventsController.ComboBoxLists(comboBoxLists);
        }
        private void UpdateComboBoxParticipants(object sender, EventArgs e) {
            boardGamesEventsController.ComboBoxParticipants(comboBoxParticipant, id_event);
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            BoardGamesEventsModel boardGamesEventsModel = new BoardGamesEventsModel
            {
                details = txtDescricao.Text,
                is_available = true,
                id_participant = comboBoxParticipant.SelectedValue != null ? (int)comboBoxParticipant.SelectedValue : 0,
                id_board_game = comboBoxBoardGame.SelectedValue != null ? (int)comboBoxBoardGame.SelectedValue : 0,
                id_event = id_event
            };

            boardGamesEventsController.AddBoardGameEvent(boardGamesEventsModel);
            LoadEventGames();
        }

        private void dataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataViewer.Rows[e.RowIndex];
            if (dataViewer.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                boardGamesEventsController.DeleteBoardGameEvent(row);
                LoadEventGames();
            }
        }

        private void btnList_Click(object sender, EventArgs e) {
            int id_list = comboBoxLists.SelectedValue != null ? (int)comboBoxLists.SelectedValue : 0;

            boardGamesEventsController.AddGamesByList(id_list, id_event);
            LoadEventGames();
        }
    }
}
