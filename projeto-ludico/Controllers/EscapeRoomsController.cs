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
    internal class EscapeRoomsController
    {
        //Cria um Repository para realizar o registro de dados, se ocorrer um erro, o catch irá ser acionado
        private readonly EscapeRoomsRepository _escapeRoomsRepository;

        public EscapeRoomsController()
        {
            _escapeRoomsRepository = new EscapeRoomsRepository();
        }

        public void RegisterEscapeRooms(EscapeRoomsModel escapeRoomsModel)
        {
            try
            {
                //Chamada da classe ValidationUtil para validar os tipos de dados do institutionsModel
                if (!ValidationUtils.IsValidName(escapeRoomsModel.name)) {
                    throw new ArgumentException("Nome não pode ser vazio.");
                }

                _escapeRoomsRepository.AddEscapeRooms(escapeRoomsModel);
                MessageBox.Show("Registro bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            catch (ArgumentException ex) {
                // Captura a exceção de ArgumentException (campo de texto vazio) e exibe uma mensagem
                MessageBox.Show(ex.Message, "Falha na criação do escape room", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex) {
                // Captura qualquer outra exceção que não tenha sido tratada acima
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EditEscapeRooms(EscapeRoomsModel escapeRoomsModel)
        {
            try
            {
                // Valida o nome da instituição
                if (!ValidationUtils.IsValidName(escapeRoomsModel.name))
                {
                    throw new ArgumentException("Nome não pode ser vazio.");
                }

                // Atualiza a instituição no banco de dados
                _escapeRoomsRepository.UpdateEscapeRooms(escapeRoomsModel);
                MessageBox.Show("Escape room editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                // Exibe uma mensagem de erro caso o nome seja inválido
                MessageBox.Show(ex.Message, "Falha na edição do escape room", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public void DeleteEscapeRooms(EscapeRoomsModel escapeRoomsModel)
        {
            try {
                _escapeRoomsRepository.DeleteEscapeRooms(escapeRoomsModel.id);
                MessageBox.Show("Escape room deletado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Erro na operação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex) {
                // Captura qualquer outra exceção que não tenha sido tratada acima
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public EscapeRoomsModel GetEscapeRoomsById(int id)
        {
            try
            {
                EscapeRoomsModel escapeRoomsModel = new EscapeRoomsModel();

                escapeRoomsModel = _escapeRoomsRepository.GetEscapeRoomsById(id);

                if (escapeRoomsModel == null)
                {
                    throw new KeyNotFoundException("Escape room não encontrado.");
                }

                return escapeRoomsModel;
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
