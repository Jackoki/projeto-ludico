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
    internal class BoardGamesEventsController
    {
        //Cria um Repository para realizar o registro de dados, se ocorrer um erro, o catch irá ser acionado
        private readonly BoardGamesEventsRepository _boardgameseventsRepository;

        public BoardGamesEventsController()
        {
            _boardgameseventsRepository = new BoardGamesEventsRepository();
        }

        public void AddBoardGameEvent(BoardGamesEventsModel boardGamesEventsModel) {
            try {
                if (boardGamesEventsModel.id_board_game == 0) {
                    throw new KeyNotFoundException("Não foi adicionado o jogo.");
                }

                _boardgameseventsRepository.AddBoardGamesEvent(boardGamesEventsModel);
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


        public void DeleteBoardGameEvent(DataGridViewRow row) {
            try {
                DialogResult result = MessageBox.Show("Tem certeza que deseja deletar este jogo do evento?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)  {
                    int id = Convert.ToInt32(row.Cells["id"].Value);
                    _boardgameseventsRepository.DeleteBoardGamesEvent(id);
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


        public BoardGamesEventsModel PerformSearch(string searchText) {
            try {
                //Chamada da classe ValidationUtil para validar os tipos de dados do searchText
                if (!ValidationUtils.IsValidName(searchText)) {
                    throw new KeyNotFoundException("Texto não pode ser vazio.");
                }

                BoardGamesEventsModel boardGamesEventsModel = new BoardGamesEventsModel();
                boardGamesEventsModel = _boardgameseventsRepository.PerformSearch(searchText);

                if (boardGamesEventsModel == null) {
                    throw new KeyNotFoundException("Jogo não encontrado.");
                }

                return boardGamesEventsModel;
            }

            catch (KeyNotFoundException ex) {
                // Se não encontrar o participante
                MessageBox.Show(ex.Message, "Falha na consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            catch (InvalidOperationException ex) {
                // Erro ao realizar a operação, como problemas com o banco de dados
                MessageBox.Show(ex.Message, "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            catch (Exception ex) {
                // Qualquer outro erro inesperado
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public BoardGamesEventsModel GetParticipantsByEventId(string searchText){
            try
            {
                //Chamada da classe ValidationUtil para validar os tipos de dados do searchText
                if (!ValidationUtils.IsValidName(searchText))
                {
                    throw new KeyNotFoundException("Texto não pode ser vazio.");
                }

                BoardGamesEventsModel boardGamesEventsModel = new BoardGamesEventsModel();
                boardGamesEventsModel = _boardgameseventsRepository.PerformSearch(searchText);

                if (boardGamesEventsModel == null)
                {
                    throw new KeyNotFoundException("Jogo não encontrado.");
                }

                return boardGamesEventsModel;
            }

            catch (KeyNotFoundException ex)
            {
                // Se não encontrar o participante
                MessageBox.Show(ex.Message, "Falha na consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            catch (InvalidOperationException ex)
            {
                // Erro ao realizar a operação, como problemas com o banco de dados
                MessageBox.Show(ex.Message, "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            catch (Exception ex)
            {
                // Qualquer outro erro inesperado
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void ComboBoxParticipants(ComboBox comboBox, int eventId) {
            try {
                var participants = _boardgameseventsRepository.GetParticipantsByEventId(eventId);

                comboBox.DataSource = participants;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Id";
            }

            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Erro ao carregar participantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex) {
                // Qualquer outro erro inesperado
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ComboBoxLists(ComboBox comboBox) {
            try {
                var lists = _boardgameseventsRepository.GetListsByEventId();

                comboBox.DataSource = lists;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Id";
            }

            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Erro ao carregar participantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex) {
                // Qualquer outro erro inesperado
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddGamesByList(int id_list, int id_event) {
            try {
                if (id_list == 0) {
                    throw new KeyNotFoundException("Não foi selecionada a lista.");
                }

                _boardgameseventsRepository.AddBoardGamesEventByList(id_list, id_event);
                MessageBox.Show("Registro bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (KeyNotFoundException ex) {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex) {
                // Qualquer outro erro inesperado
                MessageBox.Show($"Erro ao adicionar jogos na lista: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
