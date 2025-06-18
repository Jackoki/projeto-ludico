using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projeto_ludico.Models;
using projeto_ludico.Utils;
using System.Windows.Forms;
using projeto_ludico.Repository;

namespace projeto_ludico.Controllers
{   
    internal class BoardGamesEventsWithdrawalController
    {
        //Cria um Repository para realizar o registro de dados, se ocorrer um erro, o catch irá ser acionado
        private readonly BoardGamesEventsWithdrawalRepository _boardGamesEventsWithdrawalRepository;

        public BoardGamesEventsWithdrawalController()
        {
            _boardGamesEventsWithdrawalRepository = new BoardGamesEventsWithdrawalRepository();
        }

        public void AddGame(int id_event, int id_board_game, int id_participant) {
            try {
                //Verifica se um jogo ou participante foi encontrado
                if (id_board_game == 0 || id_participant == 0) {
                    throw new KeyNotFoundException("Não foi selecionado o jogo ou o participante.");
                }

                _boardGamesEventsWithdrawalRepository.AddGame(id_event, id_board_game, id_participant);
                MessageBox.Show("Registro bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (KeyNotFoundException ex) {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex) {
                // Captura qualquer outra exceção que não tenha sido tratada acima
                MessageBox.Show($"Erro ao adicionar jogo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void RemoveGameWithdrawal(DataGridViewRow row) {
            try {
                DialogResult result = MessageBox.Show("Tem certeza que deseja deletar este jogo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) {
                    int id = Convert.ToInt32(row.Cells["id"].Value);
                    _boardGamesEventsWithdrawalRepository.RemoveGameWithdrawal(id);
                    MessageBox.Show("Jogo deletado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex) {
                // Captura qualquer outra exceção que não tenha sido tratada acima
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReturnGameWithdrawal(DataGridViewRow row) {
            try {
                DialogResult result = MessageBox.Show("Tem certeza que deseja devolver este jogo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) {
                    int id = Convert.ToInt32(row.Cells["id"].Value);
                    _boardGamesEventsWithdrawalRepository.ReturnGameWithdrawal(id);
                    MessageBox.Show("Jogo devolvido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                // Captura qualquer outra exceção que não tenha sido tratada acima
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public Dictionary<int, string> PerformSearchBoardGame(string searchText) {
            try {
                //Chamada da classe ValidationUtil para validar os tipos de dados do searcgText
                if (!ValidationUtils.IsValidName(searchText)) {
                    throw new KeyNotFoundException("Texto do jogo não pode ser vazio.");
                }

                var searchResults = _boardGamesEventsWithdrawalRepository.PerformSearchBoardGame(searchText);

                if (searchResults == null || searchResults.Count == 0) {
                    throw new KeyNotFoundException("Nenhum jogo encontrado.");
                }

                return searchResults;
            }
            catch (KeyNotFoundException ex) {
                MessageBox.Show(ex.Message, "Falha na consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new Dictionary<int, string>();
            }

            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Dictionary<int, string>();
            }

            catch (Exception ex) {
                // Captura qualquer outra exceção que não tenha sido tratada acima
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Dictionary<int, string>();
            }
        }

        public ParticipantsModel PerformSearchParticipant(string searchText) {
            try {
                if (string.IsNullOrEmpty(searchText)) {
                    throw new KeyNotFoundException("Texto do participante não pode ser vazio.");
                }

                ParticipantsModel participantsModel = _boardGamesEventsWithdrawalRepository.PerformSearchParticipant(searchText);

                if (participantsModel == null) {
                    throw new KeyNotFoundException("Nenhum participante encontrado.");
                }

                return participantsModel;
            }
            
            catch (KeyNotFoundException ex) {
                MessageBox.Show(ex.Message, "Falha na consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            catch (Exception ex) {
                // Captura qualquer outra exceção que não tenha sido tratada acima
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


    }
}
