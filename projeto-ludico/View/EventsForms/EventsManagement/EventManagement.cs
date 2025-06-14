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

            // Adiciona as abas com formulários embutidos
            _tabControl.TabPages.Add(CreateTabWithEmbeddedForm("Registro de Participantes", new EventPresence(id)));
            _tabControl.TabPages.Add(CreateTabWithEmbeddedForm("Registro de Jogos", new EventGames(id)));
            _tabControl.TabPages.Add(CreateTabWithEmbeddedForm("Empréstimo de Jogo", new EventLending(id)));
            _tabControl.TabPages.Add(CreateTabWithEmbeddedForm("Lista de Empréstimos", new EventLendingParticipants(id)));

            Controls.Clear();
            Controls.Add(_tabControl);
        }

        private TabPage CreateTabWithEmbeddedForm(string title, Form form)
        {
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
