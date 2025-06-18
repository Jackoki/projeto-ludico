using System;
using System.Windows.Forms;
using projeto_ludico.Controllers;
using projeto_ludico.Models;
using projeto_ludico.Utils;

namespace projeto_ludico.View.EscapeRoomsForms
{
    public partial class EscapeRoomsEdit : Form
    {
        EscapeRoomsModel escapeRoomsModel = new EscapeRoomsModel();
        EscapeRoomsController escapeRoomsController = new EscapeRoomsController();

        //Ao renderizar esse formulário, passamos o ID do escape room pela identificação do row
        public EscapeRoomsEdit(DataGridViewRow row) {
            InitializeComponent();
            loadComboBox();
            loadEscapeRooms(row);
        }

        private void loadComboBox()
        {
            ComboBoxLoader comboBoxLoader = new ComboBoxLoader();
            comboBoxLoader.LoadComboBox(comboBoxEvents, "events", "id", "name");
        }

        //Atribuimos os campos de preenchimento do formulário com as informações do escape room identificado pelo Id passado pelo Row
        private void loadEscapeRooms(DataGridViewRow row) {
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id)) {
                escapeRoomsModel.Id = id;
            }

            escapeRoomsModel = escapeRoomsController.GetEscapeRoomsById(escapeRoomsModel.Id);

            textBoxName.Text = escapeRoomsModel.name;
            txtDescricao.Text = escapeRoomsModel.description;
            comboBoxEvents.SelectedValue = escapeRoomsModel.id_event;
        }

        

        //Ao clicar no botão de editar, será chamada a função de loadNewValues(), que esse cria um novo EscapeRoomsModel
        //Esse EscapeRoomsModel pega o Id anterior e recebe as informações dos formulários atuais
        private void btnCreate_Click(object sender, EventArgs e) {
            escapeRoomsController.EditEscapeRooms(loadNewValues());
        }

        private EscapeRoomsModel loadNewValues() {
            EscapeRoomsModel newEscapeRoomsModel = new EscapeRoomsModel();
            newEscapeRoomsModel.Id = escapeRoomsModel.Id;
            newEscapeRoomsModel.name = textBoxName.Text;
            newEscapeRoomsModel.description = txtDescricao.Text;
            newEscapeRoomsModel.id_event = comboBoxEvents.SelectedValue != null ? Convert.ToInt32(comboBoxEvents.SelectedValue) : 0;


            return newEscapeRoomsModel;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            var result = MessageBox.Show("Tem certeza que deseja cancelar?", "Cancelar", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) {
                this.Close();
            }
        }
    }
}
