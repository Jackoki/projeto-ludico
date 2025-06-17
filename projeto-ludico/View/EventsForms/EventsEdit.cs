using System;
using System.Windows.Forms;
using projeto_ludico.Controllers;
using projeto_ludico.Models;
using projeto_ludico.Utils;

namespace projeto_ludico.View.EventsForms
{
    public partial class EventsEdit : Form
    {
        EventsModel eventsModel = new EventsModel();
        EventsController eventsController = new EventsController();

        //Ao renderizar esse formulário, passamos o ID do evento pela identificação do row
        public EventsEdit(DataGridViewRow row)
        {
            InitializeComponent();
            LoadLocals();
            loadBoardGames(row);
        }

        //Atribuimos os campos de preenchimento do formulário com as informações do evento identificado pelo Id passado pelo Row
        private void loadBoardGames(DataGridViewRow row)
        {
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id))
            {
                eventsModel.id = id;
            }

            eventsModel = eventsController.GetEventsById(eventsModel.id);

            txtBoxName.Text = eventsModel.name;
            datePickerEvent.Value = eventsModel.date;
            checkBoxActive.Checked = eventsModel.is_active;
            comboBoxLocal.SelectedValue = eventsModel.id_event_local;
        }

        private void LoadLocals()
        {
            datePickerEvent.Format = DateTimePickerFormat.Custom;
            datePickerEvent.CustomFormat = "dd/MM/yyyy HH:mm";

            ComboBoxLoader comboBoxLoader = new ComboBoxLoader();
            comboBoxLoader.LoadComboBox(comboBoxLocal, "events_local", "Id", "Name");
            comboBoxLocal.SelectedIndex = -1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Ao clicar no botão de editar, será chamada a função de loadNewValues(), que esse cria um novo EventsModel
        //Esse EventsModel pega o Id anterior e recebe as informações dos formulários atuais
        private void btnEdit_Click(object sender, EventArgs e)
        {
            eventsModel.id = eventsModel.id;
            eventsModel.name = txtBoxName.Text;
            eventsModel.date = datePickerEvent.Value;
            eventsModel.id_event_local = comboBoxLocal.SelectedValue != null ? Convert.ToInt32(comboBoxLocal.SelectedValue) : 0;
            eventsModel.is_active = checkBoxActive.Checked;

            EventsController eventController = new EventsController();
            eventController.UpdateEvent(eventsModel);
        }
    }
} 
