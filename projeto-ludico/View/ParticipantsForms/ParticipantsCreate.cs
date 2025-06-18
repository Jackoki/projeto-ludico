using System;
using System.Windows.Forms;
using projeto_ludico.Controllers;
using projeto_ludico.Models;
using projeto_ludico.Utils;
using projeto_ludico.View.InstitutionsForms;

namespace projeto_ludico.View.ParticipantsForms
{
    public partial class ParticipantsCreate : Form
    {
        ParticipantsModel participantsModel = new ParticipantsModel();

        //Ao renderizar a função, será carregado o ComboBox da função abaixo, atribuindo o Nome e Id como Valor
        public ParticipantsCreate() {
            InitializeComponent();
            loadComboBox();
        }

        private void loadComboBox() {
            ComboBoxLoader comboBoxLoader = new ComboBoxLoader();
            comboBoxLoader.LoadComboBox(comboBoxInstitution, "institutions", "id", "name");
            comboBoxInstitution.SelectedIndex = -1;
        }

        //Se clicar no botão de criar instituição, será aberto o formulário de criação de instituição
        //Se ele registrar uma instituição nova, será mandado um EventHendler, que é uma notificação para realizar o carregamento do ComboBox
        private void btnInstitution_Click(object sender, EventArgs e)
        {
            InstitutionsCreate institutionsCreate = new InstitutionsCreate();
            institutionsCreate.Show();

            institutionsCreate.InstitutionRegistered += (o, args) =>
            {
                loadComboBox();
                institutionsCreate.Close();
            };

        }

        //Ao clicar no botão de criação, será montado as informações preenchidas ao participante, sendo esse passado no Controller, que por sua vez chama o Repository
        private void btnCreate_Click(object sender, EventArgs e) {
            participantsModel.name = textBoxName.Text;
            participantsModel.email = textBoxEmail.Text;
            participantsModel.cpf = textBoxCpf.Text;
            participantsModel.code = textBoxCode.Text;
            participantsModel.id_institution = comboBoxInstitution.SelectedValue != null ? Convert.ToInt32(comboBoxInstitution.SelectedValue) : 0;

            ParticipantController participantController = new ParticipantController();
            participantController.RegisterParticipant(participantsModel);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            var result = MessageBox.Show("Tem certeza que deseja cancelar?", "Cancelar", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) {
                this.Close();
            }
        }
    }
}
