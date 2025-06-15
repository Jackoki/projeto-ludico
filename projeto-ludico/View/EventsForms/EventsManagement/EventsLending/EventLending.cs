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
        public event Action OnGameRegistered;
        BoardGamesEventsWithdrawalController boardGamesEventsWithdrawalController = new BoardGamesEventsWithdrawalController();

        public EventLending(int id_event) {
            this.id_event = id_event;
            InitializeComponent();
        }

        private void btnSearchGame_Click(object sender, EventArgs e) {
            string searchString = textBoxSearchGame.Text.Trim();
            var boardGames = boardGamesEventsWithdrawalController.PerformSearchBoardGame(searchString);
            EventLendingUtil.UpdateComboBoxWithBoardGame(boardGames, comboBoxGame);
        }

        private void btnSearchParticipant_Click(object sender, EventArgs e) {
            string searchString = textBoxSearchParticipant.Text.Trim();
            ParticipantsModel participantsModel = boardGamesEventsWithdrawalController.PerformSearchParticipant(searchString);
            EventLendingUtil.UpdateComboBoxWithParticipant(participantsModel, comboBoxParticipant);
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            int id_board_game = comboBoxGame.SelectedValue != null ? (int)comboBoxGame.SelectedValue : 0;
            int id_participant = comboBoxParticipant.SelectedValue != null ? (int)comboBoxParticipant.SelectedValue : 0;

            boardGamesEventsWithdrawalController.AddGame(id_event, id_board_game, id_participant);

            //Função que realiza a chamada de Action, que vai atualizar a aba de jogos em empréstimo
            OnGameRegistered?.Invoke();
        }
    }
}
