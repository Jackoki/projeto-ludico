using projeto_ludico.Models;
using System.Windows.Forms;

namespace projeto_ludico.Service
{
    internal class PlacesDelete
    {
        private readonly PlacesController _placesController;

        public PlacesDelete()
        {
            _placesController = new PlacesController();
        }

        public void DeletePlace(DataGridViewRow row)
        {
            //Análisa se o id é diferente de nulo e se consegue converter para INT
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id))
            {
                PlacesModel placesModel = new PlacesModel();
                placesModel.id = id;

                // Exibe uma mensagem de confirmação, se o usuário apertar Sim, irá deletar pelo controller
                DialogResult result = MessageBox.Show("Tem certeza de que deseja excluir este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _placesController.DeletePlace(placesModel);
                }
            }
            else
            {
                MessageBox.Show("Erro na deleção do local.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
