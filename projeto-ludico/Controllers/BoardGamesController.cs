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
    internal class BoardGamesController
    {
        //Cria um Repository para realizar o registro de dados, se ocorrer um erro, o catch irá ser acionado
        private readonly BoardGamesRepository _boardgamesRepository;

        public BoardGamesController()
        {
            _boardgamesRepository = new BoardGamesRepository();
        }

        public void RegisterBoardGames(BoardGamesModel boardgamesModel)
        {
            try
            {
                //Chamada da classe ValidationUtil para validar os tipos de dados do institutionsModel
                //if (!ValidationUtils.IsValidName(boardgamesModel.name)) {
                    //throw new ArgumentException("Nome não pode ser vazio.");
                //}

                _boardgamesRepository.AddBoardGames(boardgamesModel);
                MessageBox.Show("Registro bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            catch (ArgumentException ex) {
                // Captura a exceção de ArgumentException (campo de texto vazio) e exibe uma mensagem
                MessageBox.Show(ex.Message, "Falha na criação do participante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex) {
                // Captura qualquer outra exceção que não tenha sido tratada acima
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EditBoardGames(BoardGamesModel boardgamesModel)
        {
            try
            {
                // Valida o nome da instituição
                //if (!ValidationUtils.IsValidName(boardgamesModel.name))
                //{
                  //  throw new ArgumentException("Nome não pode ser vazio.");
                //}

                // Atualiza a instituição no banco de dados
                _boardgamesRepository.UpdateBoardGames(boardgamesModel);
                MessageBox.Show("Participante editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                // Exibe uma mensagem de erro caso o nome seja inválido
                MessageBox.Show(ex.Message, "Falha na edição do participante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                // Exibe um erro relacionado ao banco de dados
                MessageBox.Show(ex.Message, "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Exibe um erro inesperado
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteBoardGames(BoardGamesModel boardgamesModel)
        {
            try {
                _boardgamesRepository.DeleteBoardGames(boardgamesModel.id);
                MessageBox.Show("Participante deletado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex) {
                // Captura qualquer outra exceção que não tenha sido tratada acima
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public BoardGamesModel GetBoardGamesById(int id)
        {
            try
            {
                BoardGamesModel boardgamesModel = new BoardGamesModel();

                boardgamesModel = _boardgamesRepository.GetBoardGamesById(id);

                if (boardgamesModel == null)
                {
                    throw new KeyNotFoundException("Participante não encontrado.");
                }

                return boardgamesModel;
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
    }
}
