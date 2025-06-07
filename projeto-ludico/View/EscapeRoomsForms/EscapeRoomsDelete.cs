using System.Windows.Forms;
using projeto_ludico.Controllers;
using projeto_ludico.Models;

namespace projeto_ludico.Service
{
    public class EscapeRoomsDelete
    {
        private readonly EscapeRoomsController _escapeRoomsController;

        public EscapeRoomsDelete() {
            _escapeRoomsController = new EscapeRoomsController();
        }

        public void DeleteEscapeRooms(DataGridViewRow row) {
            //Análisa se o id é diferente de nulo e se consegue converter para INT
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id)) {
                EscapeRoomsModel escapeRoomsModel = new EscapeRoomsModel();
                escapeRoomsModel.Id = id;

                // Exibe uma mensagem de confirmação, se o usuário apertar Sim, irá deletar pelo controller
                DialogResult result = MessageBox.Show("Tem certeza de que deseja excluir este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) {
                    _escapeRoomsController.DeleteEscapeRooms(escapeRoomsModel);
                }
            }

            else {
                MessageBox.Show("Erro na deleção da Escape Room.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
