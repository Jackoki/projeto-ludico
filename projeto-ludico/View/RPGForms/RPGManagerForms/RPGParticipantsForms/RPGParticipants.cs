using projeto_ludico.Controllers;
using projeto_ludico.Models;
using projeto_ludico.Utils;
using projeto_ludico.View.EventsForms.EventsManagement.EventsPresence;
using projeto_ludico.View.ListForms.ListManagerForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Windows.Forms;

namespace projeto_ludico.View.EscapeRoomsForms
{
    public partial class RPGParticipants : BaseForm
    {
        public int id_role_play_game_campaign;
        ButtonsDataGridView buttonsDataGridView = new ButtonsDataGridView();
        RPGCampaignController rpgCampaignController = new RPGCampaignController();
        ParticipantEventController participantEventController = new ParticipantEventController();

        private Dictionary<string, string> GetColumnMappings() {
            return new Dictionary<string, string> { { "id", "Id" }, { "name", "Nome" }};
        }

        public RPGParticipants(DataGridViewRow row) {
            InitializeComponent();
            ManagerList(row);
            ConfigureParticipantsViewer();
        }

        internal void ManagerList(DataGridViewRow row) {
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id)) {
                id_role_play_game_campaign = id;
            }
        }

        private void ConfigureParticipantsViewer() {
            string[] desiredColumns = { "participants_role_play_games_campaign.id", "participants.name" };

            string joinClause = "INNER JOIN participants ON (participants_role_play_games_campaign.id_participant = participants.id " +
                                "AND participants_role_play_games_campaign.id_role_play_game_campaign = " + id_role_play_game_campaign.ToString() + ")";


            var columnMappings = GetColumnMappings();

            ConfigureDataViewerWithoutButtons(dataViewerList, "participants_role_play_games_campaign", desiredColumns, columnMappings, joinClause);
            OccultColumns(dataViewerList, "id");

            if (!dataViewerList.Columns.Contains("btnDelete")) {
                var deleteButton = CreateDeleteButton();
                dataViewerList.Columns.Add(deleteButton);
            }
        }



        private void dataViewerList_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0)
                return;

            if (dataViewerList.Columns[e.ColumnIndex].Name == "btnDelete") {
                var selectedRow = dataViewerList.Rows[e.RowIndex];

                if (selectedRow.Cells["ID"].Value != null && int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out int id)) {
                    rpgCampaignController.RemoveParticipant(id);
                    ConfigureParticipantsViewer();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            string searchString = txtSearch.Text.Trim();
            ParticipantsModel participantsModel = participantEventController.PerformSearch(searchString);
            UpdateComboBoxWithParticipant(comboBoxParticipant, participantsModel);
        }

        public static void UpdateComboBoxWithParticipant(ComboBox comboBox, ParticipantsModel participantsModel) {
            if (participantsModel != null) {
                comboBox.DataSource = new List<ParticipantsModel> { participantsModel };
                comboBox.ValueMember = nameof(ParticipantsModel.Id);
                comboBox.DisplayMember = nameof(ParticipantsModel.name);
                comboBox.SelectedValue = participantsModel.Id;
            }

            else {
                comboBox.DataSource = null;
                comboBox.Text = string.Empty;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            if (comboBoxParticipant.SelectedValue == null || !int.TryParse(comboBoxParticipant.SelectedValue.ToString(), out int id_participant)) {
                MessageBox.Show("Selecione um participante válido antes de registrar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            rpgCampaignController.AddParticipant(id_role_play_game_campaign, id_participant);

            ConfigureParticipantsViewer();
        }


    }
}
