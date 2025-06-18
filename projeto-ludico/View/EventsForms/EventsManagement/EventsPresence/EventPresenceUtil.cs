using System;
using System.Collections.Generic;
using System.Windows.Forms;
using projeto_ludico.Models;

namespace projeto_ludico.View.EventsForms.EventsManagement.EventsPresence
{
    internal class EventPresenceUtil
    {
        public static void UpdateComboBoxWithParticipant(ComboBox comboBox, ParticipantsModel participantsModel)
        {
            if (participantsModel != null)
            {
                comboBox.DataSource = new List<ParticipantsModel> { participantsModel };
                comboBox.ValueMember = nameof(ParticipantsModel.Id);
                comboBox.DisplayMember = nameof(ParticipantsModel.name);
                comboBox.SelectedValue = participantsModel.Id;
            }
            else
            {
                comboBox.DataSource = null;
                comboBox.Text = string.Empty;
            }
        }

        // Valida e converte o ID do participante selecionado
        public static bool TryParseParticipantId(object selectedValue, out int participantId)
        {
            participantId = 0;
            if (selectedValue == null || !int.TryParse(selectedValue.ToString(), out participantId))
            {
                return false;
            }
            return true;
        }

        // Cria um modelo de relacionamento entre participante e evento
        public static ParticipantsEventsModel CreateParticipantsEventsModel(int eventId, int participantId, DateTime arrivedHour)
        {
            return new ParticipantsEventsModel
            {
                id_event = eventId,
                id_participant = participantId,
                arrived_hour = arrivedHour
            };
        }

        // Exibe uma mensagem de caixa de diálogo
        public static void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }
    }
}
