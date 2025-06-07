using System;
using System.Collections.Generic;
using projeto_ludico.Models;
using projeto_ludico.Utils;
using System.Windows.Forms;
using projeto_ludico.Repository;

namespace projeto_ludico.Controllers
{   
    internal class ParticipantController
    {
        //Cria um Repository para realizar o registro de dados, se ocorrer um erro, o catch irá ser acionado
        private readonly ParticipantRepository _participantRepository;

        public ParticipantController()
        {
            _participantRepository = new ParticipantRepository();
        }

        public void RegisterParticipant(ParticipantsModel participantsModel)
        {
            try
            {
                //Chamada da classe ValidationUtil para validar os tipos de dados do institutionsModel
                if (!ValidationUtils.IsValidName(participantsModel.name)) {
                    throw new ArgumentException("Nome não pode ser vazio.");
                }

                _participantRepository.AddParticipant(participantsModel);
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

        public void EditParticipant(ParticipantsModel participantsModel)
        {
            try
            {
                // Valida o nome da instituição
                if (!ValidationUtils.IsValidName(participantsModel.name))
                {
                    throw new ArgumentException("Nome não pode ser vazio.");
                }

                // Atualiza a instituição no banco de dados
                _participantRepository.UpdateParticipant(participantsModel);
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

        public void DeleteParticipant(ParticipantsModel participantsModel)
        {
            try {
                _participantRepository.DeleteParticipant(participantsModel.Id);
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

        public ParticipantsModel GetParticipantById(int id)
        {
            try
            {
                ParticipantsModel particpantsModel = new ParticipantsModel();

                particpantsModel = _participantRepository.GetParticipantById(id);

                if (particpantsModel == null)
                {
                    throw new KeyNotFoundException("Participante não encontrado.");
                }

                return particpantsModel;
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
