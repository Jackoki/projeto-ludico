using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using projeto_ludico.Models;
using ComboBox = System.Windows.Forms.ComboBox;

namespace projeto_ludico.View.EventsForms.EventsManagement.EventsLending
{
    public class EventLendingUtil {
        public static void UpdateComboBoxWithBoardGame(Dictionary<int, string> boardGames, ComboBox comboBoxGame) {
            if (boardGames != null && boardGames.Any()) {
                comboBoxGame.DataSource = new BindingSource(boardGames, null);
                comboBoxGame.ValueMember = "Key";
                comboBoxGame.DisplayMember = "Value";
            }

            else {
                comboBoxGame.DataSource = null;
                comboBoxGame.Text = string.Empty;
            }
        }


        public static void UpdateComboBoxWithParticipant(ParticipantsModel participantsModel, ComboBox comboBoxGame) {
            if (participantsModel != null) {
                comboBoxGame.DataSource = new List<ParticipantsModel> { participantsModel };
                comboBoxGame.ValueMember = nameof(ParticipantsModel.Id);
                comboBoxGame.DisplayMember = nameof(ParticipantsModel.name);
                comboBoxGame.SelectedValue = participantsModel.Id;
            }
            else {
                comboBoxGame.DataSource = null;
                comboBoxGame.Text = string.Empty;
            }
        }
    }
}
