using System;
using System.Collections.Generic;
using System.Windows.Forms;
using projeto_ludico.Controllers;
using projeto_ludico.Models;
using projeto_ludico.View.EventsForms.EventsManagement.EventsPresence;
using projeto_ludico.View.ParticipantsForms;

namespace projeto_ludico.View.EventsForms.EventsManagement
{
    public partial class EventPresence : BaseForm
    {
        ParticipantEventController participantEventController = new ParticipantEventController();
        ParticipantsCreate participantsCreate = new ParticipantsCreate();
        public int id_event;

        public EventPresence(int id_event)
        {
            this.id_event = id_event;
            InitializeComponent();
            LoadEventParticipants();
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text.Trim();
            ParticipantsModel participantsModel = participantEventController.PerformSearch(searchString);
            UpdateComboBoxWithParticipant(participantsModel);
        }

        private void UpdateComboBoxWithParticipant(ParticipantsModel participantsModel)
        {
            EventPresenceUtil.UpdateComboBoxWithParticipant(comboBoxParticipant, participantsModel);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedParticipant(out int participantId))
                return;

            var model = EventPresenceUtil.CreateParticipantsEventsModel(id_event, participantId, DateTime.Now);
            participantEventController.AddParticipant(model);
            LoadEventParticipants();
        }

        private bool TryGetSelectedParticipant(out int participantId)
        {
            if (!EventPresenceUtil.TryParseParticipantId(comboBoxParticipant.SelectedValue, out participantId))
            {
                EventPresenceUtil.ShowMessage("Selecione um participante válido antes de registrar.", "Erro", MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LoadEventParticipants() {
            string tableName = "participants_events";
            string[] columns = { "participants_events.id", "participants.name", "participants_events.arrived_hour" };

            Dictionary<string, string> columnMappings = new Dictionary<string, string> {
                { "name", "Nome do Participante" },
                { "arrived_hour", "Hora de Chegada" },
            };

            string joinClause = "INNER JOIN participants ON (participants_events.id_participant = participants.id and participants_events.id_event = " + id_event + ")";

            ConfigureDataViewerWithoutButtons(dataViewer, tableName, columns, columnMappings, joinClause);
            OccultColumns(dataViewer, "id");

            // Verifica se o botão delete já foi adicionado
            if (!dataViewer.Columns.Contains("btnDelete")) {
                var deleteButton = CreateDeleteButton();
                dataViewer.Columns.Add(deleteButton);
            }

            dataViewer.CellFormatting += (s, e) => {
                if (dataViewer.Columns[e.ColumnIndex].Name == "Hora de Chegada" && e.Value != null) {
                    if (DateTime.TryParse(e.Value.ToString(), out var dateValue)) {
                        e.Value = dateValue.ToString("dd/MM/yyyy HH:mm");
                        e.FormattingApplied = true;
                    }
                }
            };
        }

        private void dataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataViewer.Rows[e.RowIndex];
            if (dataViewer.Columns[e.ColumnIndex].Name == "btnDelete") {
                participantEventController.DeleteParticipant(row);
                LoadEventParticipants();
            }
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            participantsCreate.Show();
        }
    }
}
