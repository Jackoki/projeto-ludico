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
    internal class RPGCampaignController
    {
        private readonly RPGCampaignRepository _rpgCampaignRepository;

        public RPGCampaignController() {
            _rpgCampaignRepository = new RPGCampaignRepository();
        }

        public void RegisterCampaignRPG(RPGCampaignModel rpgCampaignModel) {
            try {
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
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
