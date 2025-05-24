using System.Windows.Forms;
using projeto_ludico.Controllers;
using projeto_ludico.Models;

namespace projeto_ludico.Service
{
    public class BoardGamesDelete
    {
        private readonly BoardGamesController _boardgamesController;

        public BoardGamesDelete() {
            _boardgamesController = new BoardGamesController();
        }

        public void DeleteBoardGames(DataGridViewRow row) {
            //Análisa se o id é diferente de nulo e se consegue converter para INT
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id)) {
                BoardGamesModel boardgamesModel = new BoardGamesModel();
                boardgamesModel.id = id;

                // Exibe uma mensagem de confirmação, se o usuário apertar Sim, irá deletar pelo controller
                DialogResult result = MessageBox.Show("Tem certeza de que deseja excluir este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) {
                    _boardgamesController.DeleteBoardGames(boardgamesModel);
                }
            }

            else {
                MessageBox.Show("Erro na deleção do jogo de mesa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
