using System.Data;
using System.Linq;
using System.Windows.Forms;
using projeto_ludico.Repository;
using projeto_ludico.Utils;

namespace projeto_ludico.View.ListForms.ListManagerForms
{
    public class LoadEscapeRoomDataViewers
    {
        private ParticipantsEscapeRoomRepository participantsEscapeRoomRepository = new ParticipantsEscapeRoomRepository();
        private ButtonsDataGridView buttonsDataGridView = new ButtonsDataGridView();

        public void loadViewList(DataGridView dataViewerList, int id_escape_room)
        {
            var participantsList = participantsEscapeRoomRepository.GetParticipantsById(id_escape_room);

            var dataSource = participantsList.Select(p => new
            {
                ID = p.id,
                Nome = p.name
            }).ToList();

            dataViewerList.DataSource = dataSource;

            dataViewerList.Columns["Nome"].HeaderText = "Nome do Participante";
            dataViewerList.Columns["Nome"].SortMode = DataGridViewColumnSortMode.Automatic;
            dataViewerList.Columns["ID"].Visible = false;

            if (!dataViewerList.Columns.Contains("btnRemove"))
            {
                var btnRemove = buttonsDataGridView.GetRemoveButton();
                dataViewerList.Columns.Add(btnRemove);
            }
        }




    }
}
