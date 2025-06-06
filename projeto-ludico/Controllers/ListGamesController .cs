using projeto_ludico.Models;
using projeto_ludico.Repository;
using projeto_ludico.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_ludico.Controllers
{
    internal class ListGamesController
    {
        private readonly ListGamesRepository _repository;

        public ListGamesController()
        {
            _repository = new ListGamesRepository();
        }

        public void AddGame(int id_list, int id_board_game)
        {
            try
            {
                _repository.AddGameToList(id_list, id_board_game);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar jogo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RemoveGame(int id_list, int id_board_game)
        {
            try
            {
                _repository.RemoveGameFromList(id_list, id_board_game);
                MessageBox.Show("Jogo removido da lista!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover jogo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
