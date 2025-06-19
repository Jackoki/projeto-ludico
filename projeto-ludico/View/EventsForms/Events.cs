using System;
using System.Collections.Generic;
using System.Windows.Forms;
using projeto_ludico.View.EventsForms.EventsManagement;
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

        //Realiza a chamada das informações do SQL, passamos as colunas que queremos e as renomeamos no da DataGrid
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

            OccultColumns(dataViewer, "id", "events_local_id");// Oculta as colunas especificadas

            AddDateTimeFormatting(dataViewer, "Data", "dd/MM/yyyy HH:mm");
        }

        //Função responsável para realizar a atualização de pesquisa quando o usuário realizar a pesquisa no formulário
        private void PerformSearch(string searchString)
        {
            // Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite
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

            AddDateTimeFormatting(dataViewer, "Data", "dd/MM/yyyy HH:mm");
        }

        public static void AddDateTimeFormatting(DataGridView dataViewer, string columnName, string dateFormat)
        {
            dataViewer.CellFormatting += (s, e) => {
                if (dataViewer.Columns[e.ColumnIndex].Name == columnName && e.Value != null)
                {
                    if (DateTime.TryParse(e.Value.ToString(), out var dateValue))
                    {
                        e.Value = dateValue.ToString(dateFormat);
                        e.FormattingApplied = true;
                    }
                }
            };
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

        //Criação dos botões de editar e deletar em cada linha de forma automática
        private void DataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) 
                return;

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
                EventManagement eventManagement = new EventManagement();
                eventManagement.loadManagement(row);
                eventManagement.Show();
            }
        }


    }
} 
