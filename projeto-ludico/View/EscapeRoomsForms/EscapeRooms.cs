using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_ludico.Service;
using projeto_ludico.View.EscapeRoomsForms;
using projeto_ludico.View.ListForms;

namespace projeto_ludico.View.EscapeRoomsForms
{
    public partial class EscapeRooms : BaseForm
    {
        public EscapeRooms()
        {
            InitializeComponent();
            ConfigureEscapeRoomsViewer();
        }

        //Realiza a chamada das informações do SQL, passamos as colunas que queremos e as renomeamos no da DataGrid
        private void ConfigureEscapeRoomsViewer()
        {
            string[] desiredColumns = { 
                "escape_rooms.id", "escape_rooms.name", 
                "events.name AS event_name" 
            };

            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" },
                { "event_name", "Evento" }
            };

            string joinClause = "LEFT JOIN events ON (escape_rooms.id_event = events.id)";

            ConfigureDataViewer(dataViewer, "escape_rooms", desiredColumns, columnMappings, joinClause, true);

            OccultColumns(dataViewer, "id");
        }

        //Função responsável para realizar a atualização de pesquisa quando o usuário realizar a pesquisa no formulário
        private void PerformSearch(string searchString)
        {
            // Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite
            string[] desiredColumns = {
                "escape_rooms.id", "escape_rooms.name",
                "events.name AS event_name"
            };

            string[] searchableColumns = { "escape_rooms.name" };  // Colunas usadas na busca

            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" },
                { "event_name", "Evento" }
            };

            string joinClause = "LEFT JOIN events ON (escape_rooms.id_event = events.id)";

            // A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            //Passamos o null no final pois não temos nenhum JOIN a ser retornado na tabela
            ConfigureSearchDataViewer(dataViewer, searchString, "escape_rooms", desiredColumns, columnMappings, searchableColumns, joinClause);

            // Oculta as colunas especificadas
            OccultColumns(dataViewer, "id");
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            string searchString = boxSearch.Text.Trim();
            PerformSearch(searchString);
        }

        //Criação dos botões de editar e deletar em cada linha de forma automática
        private void dataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataViewer.Rows[e.RowIndex];

            if (dataViewer.Columns[e.ColumnIndex].Name == "btnEdit") {
                EscapeRoomsEdit escapeRoomsEdit = new EscapeRoomsEdit(row);
                escapeRoomsEdit.Show();
            }

            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnDelete") {
                EscapeRoomsDelete escapeRoomsDelete = new EscapeRoomsDelete();
                escapeRoomsDelete.DeleteEscapeRooms(row);
            }

            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnManagement") {
                EscapeRoomsParticipants escapeRoomsParticipants = new EscapeRoomsParticipants(row);
                escapeRoomsParticipants.Show();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            EscapeRoomsCreate escapeRoomsCreate = new EscapeRoomsCreate();
            escapeRoomsCreate.Show();
        }
    }
}
