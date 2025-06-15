using System;
using System.Windows.Forms;
using projeto_ludico.Models;

namespace projeto_ludico.View.EventsForms.EventsManagement
{
    public partial class EventManagement : Form
    {
        private TabControl _tabControl;

        public EventManagement()
        {
            InitializeComponent();
        }

        public void loadManagement(DataGridViewRow row)
        {
            if (row?.Cells["id"]?.Value == null || !int.TryParse(row.Cells["id"].Value.ToString(), out int id))
            {
                MessageBox.Show("Erro ao consultar evento. Não foi possível carregar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _tabControl = new TabControl
            {
                Dock = DockStyle.Fill
            };

            // Instancia os formulários
            var eventPresenceForm = new EventPresence(id);
            var eventGamesForm = new EventGames(id);
            var eventLendingForm = new EventLending(id);
            var eventLendingParticipantsForm = new EventLendingParticipants(id);

            // Vincula o evento do EventLending ao método do EventLendingParticipants
            eventLendingForm.OnGameRegistered += eventLendingParticipantsForm.ConfigureBoardGamesViewer;

            // Adiciona as abas com os formulários embutidos
            _tabControl.TabPages.Add(CreateTabWithEmbeddedForm("Registro de Participantes", eventPresenceForm));
            _tabControl.TabPages.Add(CreateTabWithEmbeddedForm("Registro de Jogos", eventGamesForm));
            _tabControl.TabPages.Add(CreateTabWithEmbeddedForm("Empréstimo de Jogo", eventLendingForm));
            _tabControl.TabPages.Add(CreateTabWithEmbeddedForm("Lista de Empréstimos", eventLendingParticipantsForm));

            Controls.Clear();
            Controls.Add(_tabControl);
        }


        private TabPage CreateTabWithEmbeddedForm(string title, Form form) {
            var tabPage = new TabPage(title);

            // Configura o formulário para ser usado como controle dentro da aba
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Adiciona o formulário à aba
            tabPage.Controls.Add(form);
            form.Show();

            return tabPage;
        }
    }
}
