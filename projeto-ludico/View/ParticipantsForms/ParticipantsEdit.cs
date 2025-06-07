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
using projeto_ludico.View.InstitutionsForms;

namespace projeto_ludico.View.ParticipantsForms
{
    public partial class ParticipantsEdit : Form
    {
        ParticipantsModel participantsModel = new ParticipantsModel();
        ParticipantController participantController = new ParticipantController();

        //Ao renderizar esse formulário, passamos o ID do participante pela identificação do row
        public ParticipantsEdit(DataGridViewRow row) {
            InitializeComponent();
            loadComboBox();
            loadParticipant(row);
        }

        //Atribuimos os campos de preenchimento do formulário com as informações do participante identificado pelo Id passado pelo Row
        private void loadParticipant(DataGridViewRow row) {
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id)) {
                participantsModel.Id = id;
            }

            participantsModel = participantController.GetParticipantById(participantsModel.Id);

            textBoxName.Text = participantsModel.name;
            textBoxEmail.Text = participantsModel.email;
            textBoxCpf.Text = participantsModel.cpf;
            textBoxCode.Text = participantsModel.code;
            comboBoxInstitution.SelectedValue = participantsModel.id_institution;
        }

        private void loadComboBox() {
            ComboBoxLoader comboBoxLoader = new ComboBoxLoader();
            comboBoxLoader.LoadComboBox(comboBoxInstitution, "institutions", "id", "name");
        }

        //Ao clicar no botão de editar, será chamada a função de loadNewValues(), que esse cria um novo ParticipantModel
        //Esse ParticipantModel pega o Id anterior e recebe as informações dos formulários atuais
        private void btnCreate_Click(object sender, EventArgs e) {
            participantController.EditParticipant(loadNewValues());
        }

        private ParticipantsModel loadNewValues() {
            ParticipantsModel newParticipantsModel = new ParticipantsModel();
            newParticipantsModel.Id = participantsModel.Id;
            newParticipantsModel.name = textBoxName.Text;
            newParticipantsModel.email = textBoxEmail.Text;
            newParticipantsModel.cpf = textBoxCpf.Text;
            newParticipantsModel.code = textBoxCode.Text;
            newParticipantsModel.id_institution = comboBoxInstitution.SelectedValue != null ? Convert.ToInt32(comboBoxInstitution.SelectedValue) : 0;

            return newParticipantsModel;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            var result = MessageBox.Show("Tem certeza que deseja cancelar?", "Cancelar", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) {
                this.Close();
            }
        }
    }
}
