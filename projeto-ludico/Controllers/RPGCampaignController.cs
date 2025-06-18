using projeto_ludico.Models;
using projeto_ludico.Repository;
using projeto_ludico.Utils;
using System;
using System.Windows.Forms;

namespace projeto_ludico.Controllers
{
    internal class RPGCampaignController
    {
        //Cria um Repository para realizar o registro de dados, se ocorrer um erro, o catch irá ser acionado
        private readonly RPGCampaignRepository _rpgCampaignRepository;

        public RPGCampaignController() {
            _rpgCampaignRepository = new RPGCampaignRepository();
        }

        public void RegisterCampaignRPG(RPGCampaignModel rpgCampaignModel) {
            try {
                //Chamada da classe ValidationUtil para validar os tipos de dados do rpgCampaignsModel
                if (!ValidationUtils.IsValidName(rpgCampaignModel.name))
                    throw new ArgumentException("Nome não pode ser vazio.");

                _rpgCampaignRepository.AddRPGCampaign(rpgCampaignModel);
                MessageBox.Show("Campanha registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (ArgumentException ex) {
                MessageBox.Show(ex.Message, "Falha ao registrar RPG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Erro no banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex) {
                // Captura qualquer outra exceção que não tenha sido tratada acima
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteCampaignRPG(int id) {
            try {
                _rpgCampaignRepository.DeleteRPGCampaign(id);
                MessageBox.Show("Campanha deletada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Erro no banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex) {
                // Captura qualquer outra exceção que não tenha sido tratada acima
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddParticipant(int id_role_play_game_campaign, int id_participant) {
            try {
                _rpgCampaignRepository.AddParticipant(id_role_play_game_campaign, id_participant);
                MessageBox.Show("Participante adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Erro no banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex) {
                // Captura qualquer outra exceção que não tenha sido tratada acima
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RemoveParticipant(int id) {
            try {
                _rpgCampaignRepository.RemoveParticipant(id);
                MessageBox.Show("Participante deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message, "Erro no banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex) {
                // Captura qualquer outra exceção que não tenha sido tratada acima
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
