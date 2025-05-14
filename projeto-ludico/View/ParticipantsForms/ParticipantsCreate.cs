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
    public partial class ParticipantsCreate : Form
    {
        ParticipantsModel participantsModel;

        public ParticipantsCreate() {
            InitializeComponent();
            participantsModel = new ParticipantsModel();
            loadComboBox();
        }

        private void loadComboBox() {
            ComboBoxLoader comboBoxLoader = new ComboBoxLoader();
            comboBoxLoader.LoadComboBox(comboBoxInstitution, "institutions", "id", "name");
            comboBoxInstitution.SelectedIndex = -1;
        }

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
