using System;
using System.Windows.Forms;
using projeto_ludico.Controllers;
using projeto_ludico.Models;
using projeto_ludico.Utils;

namespace projeto_ludico.View.EventsForms
{
    public partial class EventsCreate : Form
    {
        public event EventHandler EventRegistered;
        private EventsController _controller;

        public EventsCreate()
        {
            InitializeComponent();
            _controller = new EventsController();
            LoadLocals();
            ConfigureDatePicker();
        }

        private void LoadLocals()
        {
            ComboBoxLoader comboBoxLoader = new ComboBoxLoader();
            comboBoxLoader.LoadComboBox(comboBoxLocal, "events_local", "Id", "Name");
            comboBoxLocal.SelectedIndex = -1;
        }

        private void ConfigureDatePicker()
        {
            datePickerEvent.MinDate = DateTime.Now;
            datePickerEvent.Value = DateTime.Now;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBoxName.Text))
                {
                    MessageBox.Show("Nome do evento é obrigatório!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxLocal.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione um local para o evento!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var eventModel = new EventsModel
                {
                    name = txtBoxName.Text,
                    description = txtBoxDescription.Text,
                    date = datePickerEvent.Value,
                    id_local = Convert.ToInt32(comboBoxLocal.SelectedValue)
                };

                _controller.CreateEvent(eventModel);
                MessageBox.Show("Evento registrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnEventRegistered();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar evento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void OnEventRegistered()
        {
            EventRegistered?.Invoke(this, EventArgs.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
} 