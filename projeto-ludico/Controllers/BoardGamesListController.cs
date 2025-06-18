using projeto_ludico.Repository;
using System;
using System.Windows.Forms;

namespace projeto_ludico.Controllers
{
    internal class BoardGamesListController
    {
        //Cria um Repository para realizar o registro de dados, se ocorrer um erro, o catch irá ser acionado
        private readonly BoardGamesListRepository _repository;

        public BoardGamesListController()
        {
            _repository = new BoardGamesListRepository();
        }

        public void AddGame(int id_list, int id_board_game) {
            try {
                _repository.AddGameToList(id_list, id_board_game);
                MessageBox.Show("Jogo adicionado na lista!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex) {
                // Exibe um erro inesperado
                MessageBox.Show("Erro ao adicionar jogo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RemoveGame(int id_list, int id) {
            try {
                _repository.RemoveGameFromList(id_list, id);
                MessageBox.Show("Jogo removido da lista!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex) {
                // Exibe um erro inesperado
                MessageBox.Show("Erro ao remover jogo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
