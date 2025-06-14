using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_ludico.Controllers;
using projeto_ludico.Models;
using projeto_ludico.View.EventsForms.EventsManagement.EventsLending;
using projeto_ludico.View.EventsForms.EventsManagement.EventsPresence;

namespace projeto_ludico.View.EventsForms.EventsManagement
{
    public partial class EventLending : Form
    {
        public int id_event;

        public EventLending(int id_event) {
            this.id_event = id_event;
            InitializeComponent();
        }

        private void btnSearchGame_Click(object sender, EventArgs e) {
            string searchString = textBoxSearchGame.Text.Trim();
            BoardGamesModel boardGamesModel = boardGamesEventsWithdrawalController.PerformSearchBoardGame(searchString);
            EventLendingUtil.UpdateComboBoxWithBoardGame(boardGamesModel);
        }

        private void btnSearchParticipant_Click(object sender, EventArgs e) {
            string searchString = textBoxSearchParticipant.Text.Trim();
            ParticipantsModel participantsModel = boardGamesEventsWithdrawalController.PerformSearchParticipant(searchString);
            EventLendingUtil.UpdateComboBoxWithParticipant(participantsModel);
        }

    }
}
