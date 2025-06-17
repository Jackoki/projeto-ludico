using System;
using System.Windows.Forms;
using projeto_ludico.Controllers;
using projeto_ludico.Models;
using projeto_ludico.Utils;

namespace projeto_ludico.View.EventsForms
{
    public partial class EventsCreate : Form
    {
        private EventsController _controller;
        EventsModel eventsModel = new EventsModel();

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
            datePickerEvent.Format = DateTimePickerFormat.Custom;
            datePickerEvent.CustomFormat = "dd/MM/yyyy HH:mm";
        }

         //Ao clicar no botão de criação, será montado as informações preenchidas ao evento, sendo esse passado no Controller, que por sua vez chama o Repository
        private void btnRegister_Click(object sender, EventArgs e)
        {
            eventsModel.name = txtBoxName.Text;
            eventsModel.date = datePickerEvent.Value;
            eventsModel.id_event_local = comboBoxLocal.SelectedValue != null ? Convert.ToInt32(comboBoxLocal.SelectedValue) : 0;
            eventsModel.is_active = checkBoxActive.Checked;

            EventsController eventController = new EventsController();
            eventController.CreateEvent(eventsModel);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
} 
