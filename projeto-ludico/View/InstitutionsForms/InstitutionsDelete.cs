using System;
using System.Windows.Forms;
using projeto_ludico.Models;
using projeto_ludico.Controllers;
using projeto_ludico.Models;

namespace projeto_ludico.Service
{
    public class InstitutionsDelete
    {
        private readonly InstitutionController _institutionController;

        public InstitutionsDelete()
        {
            _institutionController = new InstitutionController();
        }

        public void DeleteInstitution(DataGridViewRow row) {

            //Análisa se o id é diferente de nulo e se consegue converter para INT
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id)) {
                InstitutionsModel institutionsModel = new InstitutionsModel();
                institutionsModel.Id = id;

                // Exibe uma mensagem de confirmação, se o usuário apertar Sim, irá deletar pelo controller
                DialogResult result = MessageBox.Show("Tem certeza de que deseja excluir este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) {
                    _institutionController.DeleteInstitution(institutionsModel);
                }
            }

            else {
                MessageBox.Show("Erro na deleção da instituição.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
