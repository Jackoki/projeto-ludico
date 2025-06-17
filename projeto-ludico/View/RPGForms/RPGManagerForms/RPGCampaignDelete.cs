using projeto_ludico.Controllers;
using projeto_ludico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_ludico.View.RPGForms
{
    internal class RPGCampaignDelete
    {
        private readonly RPGCampaignController _rpgCampaignController;

        public RPGCampaignDelete()
        {
            _rpgCampaignController = new RPGCampaignController();
        }

        public void DeleteCampaignRPG(DataGridViewRow row)
        {
             //Análisa se o id é diferente de nulo e se consegue converter para INT
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id)) {
                // Exibe uma mensagem de confirmação, se o usuário apertar Sim, irá deletar pelo controller
                DialogResult result = MessageBox.Show("Tem certeza de que deseja excluir esta campanha?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) {
                    _rpgCampaignController.DeleteCampaignRPG(id);
                }
            }
            else  {
                MessageBox.Show("Erro na deleção da campanha.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
