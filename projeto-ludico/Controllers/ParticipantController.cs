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

        /*
        public void EditInstitution(InstitutionsModel institutionsModel)
        {
            try
            {
                // Valida o nome da instituição
                if (!ValidationUtils.IsValidName(institutionsModel.Name))
                {
                    throw new ArgumentException("Nome não pode ser vazio.");
                }

                // Atualiza a instituição no banco de dados
                _institutionRepository.UpdateInstitution(institutionsModel);
                MessageBox.Show("Instituição editada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                // Exibe uma mensagem de erro caso o nome seja inválido
                MessageBox.Show(ex.Message, "Falha na edição da instituição", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        */
        public void DeleteParticipant(ParticipantsModel participantsModel)
        {
            try {
                _participantRepository.DeleteParticipant(participantsModel.id);
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
    }
}
