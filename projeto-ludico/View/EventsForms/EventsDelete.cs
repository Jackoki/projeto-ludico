using projeto_ludico.Controllers;
using projeto_ludico.Models;
using System.Windows.Forms;

namespace projeto_ludico.View.ListForms
{
    internal class EventDelete
    {
        private readonly EventsController _eventsController;

        public EventDelete()
        {
            _eventsController = new EventsController();
        }

        public void DeleteEvent(DataGridViewRow row)
        {
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id))
            {
                EventsModel eventsModel = new EventsModel();
                eventsModel.id = id;

                DialogResult result = MessageBox.Show(
                    "Tem certeza de que deseja excluir este evento?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    _eventsController.DeleteEvent(eventsModel.id);
                }
            }
            else
            {
                MessageBox.Show("Erro na deleção da lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
