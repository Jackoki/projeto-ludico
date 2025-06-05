using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using projeto_ludico.Controllers;
using projeto_ludico.Service;
using projeto_ludico.Utils;
using projeto_ludico.View.BoardGamesForms;
using projeto_ludico.View.Institutions;
using projeto_ludico.View.InstitutionsForms;
using projeto_ludico.View.ListForms;

namespace projeto_ludico.View.EventsForms
{
    public partial class Events : BaseForm
    {
        public Events()
        {
            InitializeComponent();
            ConfigureEventsViewer();
        }

        private void ConfigureEventsViewer()
        {
            string[] desiredColumns = {
                "events.id", "events.name", "events.date",
                "events_local.name AS events_local", "events_local.id AS events_local_id"
            };

            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" },
                { "date", "Data" },
                { "events_local", "Local do Evento" }
            };

            string[] searchableColumns = { "events.name" }; 

            string joinClause = "LEFT JOIN events_local ON (events_local.id = events.id_event_local)";

            //A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            //Passamos o true para dizer que iremos adicionar o botão "Gerenciar" na linha
            ConfigureDataViewer(dataViewer, "events", desiredColumns, columnMappings, joinClause, true);

            OccultColumns(dataViewer, "id", "events_local_id");
        }


        private void PerformSearch(string searchString)
        {
            string[] desiredColumns = {
                "events.id", "events.name", "events.date",
                "events_local.name AS events_local", "events_local.id AS events_local_id"
            };

            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" },
                { "date", "Data" },
                { "events_local", "Local do Evento" }
            };

            string[] searchableColumns = { "events.name" };  // Colunas usadas na busca

            string joinClause = "LEFT JOIN events_local ON (events_local.id = events.id_event_local)";

            //A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            //Passamos o true para dizer que iremos adicionar o botão "Gerenciar" na linha
            OccultColumns(dataViewer, "id", "events_local_id");

            // A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            //Passamos o null no final pois não temos nenhum JOIN a ser retornado na tabela
            ConfigureSearchDataViewer(dataViewer, searchString, "events", desiredColumns, columnMappings, searchableColumns, joinClause);

            // Oculta as colunas especificadas
            OccultColumns(dataViewer, "id");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchString = boxSearch.Text.Trim();
            PerformSearch(searchString);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            EventsCreate eventsCreate = new EventsCreate();
            eventsCreate.Show();
        }

        private void DataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataViewer.Rows[e.RowIndex];

            if (dataViewer.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                EventsEdit eventsEdit = new EventsEdit(row);
                eventsEdit.Show();
            }

            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                EventDelete eventDelete = new EventDelete();
                eventDelete.DeleteEvent(row);
            }

            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnManagement")
            {
                //EventDelete eventDelete = new EventDelete();
                //eventDelete.DeleteEvent(row);
            }
        }


    }
} 