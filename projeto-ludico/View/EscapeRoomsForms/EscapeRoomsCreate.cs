using System;
using System.Windows.Forms;
using projeto_ludico.Controllers;
using projeto_ludico.Models;
using projeto_ludico.Utils;

namespace projeto_ludico.View.EscapeRoomsForms
{
    public partial class EscapeRoomsCreate : Form
    {
        EscapeRoomsModel escapeRoomsModel = new EscapeRoomsModel();

        //Ao renderizar a função, será carregado o ComboBox da função abaixo, atribuindo o Nome e Id como Valor
        public EscapeRoomsCreate() {
            InitializeComponent();
            loadComboBox();
        }

        private void loadComboBox()
        {
            ComboBoxLoader comboBoxLoader = new ComboBoxLoader();
            comboBoxLoader.LoadComboBox(comboBoxEvents, "events", "id", "name");
            comboBoxEvents.SelectedIndex = -1;
        }

        //Se clicar no botão de criar, será aberto o formulário de criação de escape room
        private void btnCreate_Click(object sender, EventArgs e) {
            escapeRoomsModel.name = textBoxName.Text;
            escapeRoomsModel.description= txtDescricao.Text;
            escapeRoomsModel.id_event = comboBoxEvents.SelectedValue != null ? Convert.ToInt32(comboBoxEvents.SelectedValue) : 0;

            EscapeRoomsController escapeRoomsController = new EscapeRoomsController();
            escapeRoomsController.RegisterEscapeRooms(escapeRoomsModel);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            var result = MessageBox.Show("Tem certeza que deseja cancelar?", "Cancelar", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) {
                this.Close();
            }
        }
    }
}
