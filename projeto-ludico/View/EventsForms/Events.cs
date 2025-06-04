using System;
using System.Data;
using System.Windows.Forms;
using projeto_ludico.Controllers;
using projeto_ludico.Utils;

namespace projeto_ludico.View.EventsForms
{
    public partial class Events : Form
    {
        private EventsController _controller;
        private DataTableStructure _dataTableStructure;
        private ButtonsDataGridView _buttonsDataGridView;

        public Events()
        {
            InitializeComponent();
            _controller = new EventsController();
            ConfigureDataGridView();
            LoadEvents();
        }

        private void ConfigureDataGridView()
        {
            _dataTableStructure = new DataTableStructure();
            _buttonsDataGridView = new ButtonsDataGridView();

            // Configurar colunas
            _dataTableStructure.ConfigureColumns(dataGridViewEvents, new[]
            {
                new DataColumn("Id", typeof(int)),
                new DataColumn("Nome", typeof(string)),
                new DataColumn("Descrição", typeof(string)),
                new DataColumn("Data", typeof(DateTime)),
                new DataColumn("Local", typeof(string)),
                new DataColumn("Status", typeof(string))
            });

            // Adicionar botões de ação
            _buttonsDataGridView.AddButton(dataGridViewEvents, "Gerenciar", "btnManage");
            _buttonsDataGridView.AddButton(dataGridViewEvents, "Editar", "btnEdit");
            _buttonsDataGridView.AddButton(dataGridViewEvents, "Excluir", "btnDelete");
        }

        private void LoadEvents()
        {
            try
            {
                var events = _controller.GetAllEvents();
                dataGridViewEvents.DataSource = events;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar eventos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var createForm = new EventsCreate();
            createForm.EventRegistered += (s, args) =>
            {
                LoadEvents();
                createForm.Close();
            };
            createForm.Show();
        }

        private void dataGridViewEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var id = Convert.ToInt32(dataGridViewEvents.Rows[e.RowIndex].Cells["Id"].Value);

            if (e.ColumnIndex == dataGridViewEvents.Columns["btnManage"].Index)
            {
                // Implementar gerenciamento do evento
                MessageBox.Show("Funcionalidade de gerenciamento em desenvolvimento", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (e.ColumnIndex == dataGridViewEvents.Columns["btnEdit"].Index)
            {
                var editForm = new EventsEdit(id);
                editForm.EventUpdated += (s, args) =>
                {
                    LoadEvents();
                    editForm.Close();
                };
                editForm.Show();
            }
            else if (e.ColumnIndex == dataGridViewEvents.Columns["btnDelete"].Index)
            {
                if (MessageBox.Show("Deseja realmente excluir este evento?", "Confirmação",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _controller.DeleteEvent(id);
                        LoadEvents();
                        MessageBox.Show("Evento excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao excluir evento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var searchResults = _controller.SearchEvents(txtSearch.Text);
                dataGridViewEvents.DataSource = searchResults;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar eventos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 