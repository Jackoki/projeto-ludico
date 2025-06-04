using System;
using System.Windows.Forms;
using projeto_ludico.Controllers;
using projeto_ludico.Models;
using projeto_ludico.Utils;

namespace projeto_ludico.View.EventsForms
{
    public partial class EventsEdit : Form
    {
        public event EventHandler EventUpdated;
        private EventsController _controller;
        private int _eventId;
        private EventsModel _currentEvent;

        public EventsEdit(int eventId)
        {
            InitializeComponent();
            _controller = new EventsController();
            _eventId = eventId;
            LoadLocals();
            LoadEventData();
            ConfigureDatePicker();
        }

        private void LoadLocals()
        {
            ComboBoxLoader comboBoxLoader = new ComboBoxLoader();
            comboBoxLoader.LoadComboBox(comboBoxLocal, "events_local", "Id", "Name");
        }

        private void LoadEventData()
        {
            try
            {
                _currentEvent = _controller.GetEventById(_eventId);
                if (_currentEvent != null)
                {
                    txtBoxName.Text = _currentEvent.name;
                    txtBoxDescription.Text = _currentEvent.description;
                    datePickerEvent.Value = _currentEvent.date;
                    comboBoxLocal.SelectedValue = _currentEvent.id_local;
                }
                else
                {
                    MessageBox.Show("Evento não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados do evento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void ConfigureDatePicker()
        {
            datePickerEvent.MinDate = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
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

                _currentEvent.name = txtBoxName.Text;
                _currentEvent.description = txtBoxDescription.Text;
                _currentEvent.date = datePickerEvent.Value;
                _currentEvent.id_local = Convert.ToInt32(comboBoxLocal.SelectedValue);

                _controller.UpdateEvent(_currentEvent);
                MessageBox.Show("Evento atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnEventUpdated();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar evento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void OnEventUpdated()
        {
            EventUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
} 