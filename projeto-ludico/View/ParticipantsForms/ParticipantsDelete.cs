using System.Windows.Forms;
using projeto_ludico.Controllers;
using projeto_ludico.Models;

namespace projeto_ludico.Service
{
    public class ParticipantsDelete
    {
        private readonly ParticipantController _participantController;

        public ParticipantsDelete() {
            _participantController = new ParticipantController();
        }

        public void DeleteParticipant(DataGridViewRow row) {
            //Análisa se o id é diferente de nulo e se consegue converter para INT
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id)) {
                ParticipantsModel participantsModel = new ParticipantsModel();
                participantsModel.Id = id;

                // Exibe uma mensagem de confirmação, se o usuário apertar Sim, irá deletar pelo controller
                DialogResult result = MessageBox.Show("Tem certeza de que deseja excluir este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) {
                    _participantController.DeleteParticipant(participantsModel);
                }
            }

            else {
                MessageBox.Show("Erro na deleção do participante.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
