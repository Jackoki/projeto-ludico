using System;
using System.Collections.Generic;
using projeto_ludico.Models;
using projeto_ludico.Utils;
using System.Windows.Forms;
using projeto_ludico.Repository;

namespace projeto_ludico.Controllers
{   
    internal class ParticipantEventController
    {
        //Cria um Repository para realizar o registro de dados, se ocorrer um erro, o catch irá ser acionado
        private readonly ParticipantEventRepository _participantEventRepository;

        public ParticipantEventController()
        {
            _participantEventRepository = new ParticipantEventRepository();
        }

        public void AddParticipant(ParticipantsEventsModel participantsEventsModel)
        {
            try { 
                _participantEventRepository.AddParticipant(participantsEventsModel);
                MessageBox.Show("Registro bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar participante: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void DeleteParticipant(DataGridViewRow row)
        {
            try {
                DialogResult result = MessageBox.Show("Tem certeza que deseja deletar este participante do evento?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) {
                    int id = Convert.ToInt32(row.Cells["id"].Value);
                    _participantEventRepository.DeleteParticipant(id);
                    MessageBox.Show("Participante deletado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        public ParticipantsModel PerformSearch(string searchText)
        {
            try
            {
                if (!ValidationUtils.IsValidName(searchText)) {
                    throw new KeyNotFoundException("Texto não pode ser vazio.");
                }

                ParticipantsModel particpantsModel = new ParticipantsModel();
                particpantsModel = _participantEventRepository.PerformSearch(searchText);

                if (particpantsModel == null) {
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
