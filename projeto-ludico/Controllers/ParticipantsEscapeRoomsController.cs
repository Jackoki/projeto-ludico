using projeto_ludico.Models;
using projeto_ludico.Repository;
using System;
using System.Data.Entity.Infrastructure;
using System.Windows.Forms;

namespace projeto_ludico.Controllers
{
    internal class ParticipantsEscapeRoomController
    {
        //Cria um Repository para realizar o registro de dados, se ocorrer um erro, o catch irá ser acionado
        private readonly ParticipantsEscapeRoomRepository _repository;

        public ParticipantsEscapeRoomController()
        {
            _repository = new ParticipantsEscapeRoomRepository();
        }

        public void AddParticipant(int id_escape_room, int id_participant) {
            try {
                _repository.AddParticipant(id_escape_room, id_participant);
                MessageBox.Show("Participante adicionado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (DbUpdateException dbEx)
            {
                var innerException = dbEx.InnerException?.InnerException;
                if (innerException != null)
                {
                    MessageBox.Show(innerException.Message, "Erro detalhado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Captura qualquer outra exceção que não tenha sido tratada acima
                    MessageBox.Show(dbEx.Message, "Erro ao salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex) {
                MessageBox.Show("Erro ao adicionar participante: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RemoveParticipant(int id_escape_room, int id_participant) {
            try {
                _repository.RemoveParticipant(id_escape_room, id_participant);
                MessageBox.Show("Participante removido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex) {
                MessageBox.Show("Erro ao remover participante: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
