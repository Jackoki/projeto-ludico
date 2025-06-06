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
using projeto_ludico.Utils;
using projeto_ludico.View.EscapeRoomsForms;

namespace projeto_ludico.View.EscapeRoomsForms
{
    public partial class EscapeRoomsEdit : Form
    {
        EscapeRoomsModel escapeRoomsModel = new EscapeRoomsModel();
        EscapeRoomsController escapeRoomsController = new EscapeRoomsController();

        //Ao renderizar esse formulário, passamos o ID do participante pela identificação do row
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

        //Atribuimos os campos de preenchimento do formulário com as informações do participante identificado pelo Id passado pelo Row
        private void loadEscapeRooms(DataGridViewRow row) {
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id)) {
                escapeRoomsModel.id = id;
            }

            escapeRoomsModel = escapeRoomsController.GetEscapeRoomsById(escapeRoomsModel.id);

            textBoxName.Text = escapeRoomsModel.name;
            txtDescricao.Text = escapeRoomsModel.description;
            comboBoxEvents.SelectedValue = escapeRoomsModel.id_event;
        }

        

        //Ao clicar no botão de editar, será chamada a função de loadNewValues(), que esse cria um novo ParticipantModel
        //Esse ParticipantModel pega o Id anterior e recebe as informações dos formulários atuais
        private void btnCreate_Click(object sender, EventArgs e) {
            escapeRoomsController.EditEscapeRooms(loadNewValues());
        }

        private EscapeRoomsModel loadNewValues() {
            EscapeRoomsModel newEscapeRoomsModel = new EscapeRoomsModel();
            newEscapeRoomsModel.id = escapeRoomsModel.id;
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
