using projeto_ludico.Controllers;
using projeto_ludico.Models;
using System.Windows.Forms;

namespace projeto_ludico.View.ListForms
{
    internal class ListDelete
    {
        private readonly ListController _listController;

        public ListDelete()
        {
            _listController = new ListController();
        }

        public void DeleteList(DataGridViewRow row)
        {
            //Análisa se o id é diferente de nulo e se consegue converter para INT
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id))
            {
                ListModel listModel = new ListModel();
                listModel.id = id;

                // Exibe uma mensagem de confirmação, se o usuário apertar Sim, irá deletar pelo controller
                DialogResult result = MessageBox.Show(
                    "Tem certeza de que deseja excluir esta lista?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    _listController.DeleteList(listModel.id);
                }
            }
            else
            {
                MessageBox.Show("Erro na deleção da lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
