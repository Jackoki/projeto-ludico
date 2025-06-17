using projeto_ludico.Service;
using projeto_ludico.View.Places;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_ludico.View.PlacesForms
{
    public partial class Places : BaseForm
    {
        public Places()
        {
            InitializeComponent();
            ConfigurePlacesViewer();
            dataViewer.CellContentClick += DataViewer_CellContentClick;
        }

        private void Places_Load(object sender, EventArgs e)
        {

        }

        //Realiza a chamada das informações do SQL, passamos as colunas que queremos e as renomeamos no da DataGrid
        private void ConfigurePlacesViewer()
        {
            string[] desiredColumns = { "name", "id" };
            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" }
            };

            //Passamos o false para dizer que não iremos adicionar o botão "Gerenciar" na linha
            ConfigureDataViewer(dataViewer, "events_local", desiredColumns, columnMappings, null, false);
            OccultColumns(dataViewer, "id");
        }

        //Função responsável para realizar a atualização de pesquisa quando o usuário realizar a pesquisa no formulário
        private void PerformSearch(string searchString)
        {
            // Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite
            string[] desiredColumns = { "name", "id" };
            string[] searchableColumns = { "name" }; // Colunas usadas na busca

            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" }
            };

            // A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            //Passamos o null no final pois não temos nenhum JOIN a ser retornado na tabela
            ConfigureSearchDataViewer(dataViewer, searchString, "events_local", desiredColumns, columnMappings, searchableColumns, null);
            OccultColumns(dataViewer, "id"); // Oculta as colunas especificadas
        }

        //Criação dos botões de editar e deletar em cada linha de forma automática
        private void DataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataViewer.Rows[e.RowIndex];

            if (dataViewer.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                PlacesEdit placesEdit = new PlacesEdit();
                placesEdit.EditPlace(row);
                placesEdit.Show();
            }
            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                PlacesDelete placesDelete = new PlacesDelete();
                placesDelete.DeletePlace(row);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            PlacesCreate placesCreate = new PlacesCreate();
            placesCreate.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchString = boxSearch.Text.Trim();
            PerformSearch(searchString);
        }

        private void boxSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
