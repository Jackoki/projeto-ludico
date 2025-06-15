using projeto_ludico.Controllers;
using projeto_ludico.Utils;
using projeto_ludico.View.ListForms.ListManagerForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_ludico.View.EscapeRoomsForms
{
    public partial class EscapeRoomsParticipants : BaseForm
    {
        public DataGridViewRow row;
        public int id_escape_room;
        LoadEscapeRoomDataViewers loadEscapeRoomDataViewers = new LoadEscapeRoomDataViewers();
        ButtonsDataGridView buttonsDataGridView = new ButtonsDataGridView();
        ParticipantsEscapeRoomController participantsEscapeRoomController = new ParticipantsEscapeRoomController();

        private Dictionary<string, string> GetColumnMappings() {
            return new Dictionary<string, string> { { "id", "Id" }, { "name", "Nome" }};
        }

        public EscapeRoomsParticipants(DataGridViewRow rowInitial) {
            InitializeComponent();

            row = rowInitial;
            ManagerList();
            ConfigureParticipantsViewer();
            LoadDataViewerList();
        }

        private void ConfigureParticipantsViewer() {
            string[] desiredColumns = { "participants.id", "participants.name" }; // Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite

            string joinClause = "INNER JOIN participants_events ON (participants_events.id_participant = participants.id)" +
                                "INNER JOIN events ON (events.id = participants_events.id_event) " +
                                "INNER JOIN escape_rooms ON (escape_rooms.id_event = events.id AND escape_rooms.id = " + id_escape_room.ToString() + ")";


            var columnMappings = GetColumnMappings();

            ConfigureDataViewerWithoutButtons(dataViewerParticipants, "participants", desiredColumns, columnMappings, joinClause);
            OccultColumns(dataViewerParticipants, "id");

            var btnAdd = buttonsDataGridView.GetAddButton();
            dataViewerParticipants.Columns.Add(btnAdd);
        }

        //Função responsável para realizar a atualização de pesquisa quando o usuário realizar a pesquisa no formulário
        private void PerformSearch(string searchString) {
            string[] desiredColumns = { "participants.id", "participants.name" }; // Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite
            string[] searchableColumns = { "participants.name"};

            string joinClause = "INNER JOIN participants_events ON (participants_events.id_participant = participants.id)" +
                                "INNER JOIN events ON (events.id = participants_events.id_event) " +
                                "INNER JOIN escape_rooms ON (escape_rooms.id_event = events.id AND escape_rooms.id = " + id_escape_room.ToString() + ")";

            var columnMappings = GetColumnMappings();

            // A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            ConfigureSearchDataViewer(dataViewerParticipants, searchString, "participants", desiredColumns, columnMappings, searchableColumns, joinClause);
            OccultColumns(dataViewerParticipants, "id"); // Oculta as colunas especificadas
        }

        internal void LoadDataViewerList() {
            loadEscapeRoomDataViewers.loadViewList(dataViewerList, id_escape_room);
        }

        internal void ManagerList() {
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id)) {
                id_escape_room = id;
            }
        }

        private void dataViewerGames_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0)
                return;

            if (dataViewerParticipants.Columns[e.ColumnIndex].Name == "btnAdd") {
                var selectedRow = dataViewerParticipants.Rows[e.RowIndex];

                if (selectedRow.Cells["id"].Value != null && int.TryParse(selectedRow.Cells["id"].Value.ToString(), out int id_board_game)) {
                    participantsEscapeRoomController.AddParticipant(id_escape_room, id_board_game);
                    LoadDataViewerList();
                }
            }
        }

        private void dataViewerList_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0)
                return;

            if (dataViewerList.Columns[e.ColumnIndex].Name == "btnRemove") {
                var selectedRow = dataViewerList.Rows[e.RowIndex];

                if (selectedRow.Cells["ID"].Value != null && int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out int id)) {
                    participantsEscapeRoomController.RemoveParticipant(id_escape_room, id);
                    LoadDataViewerList();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            PerformSearch(txtSearch.Text.Trim());
        }

    }
}
