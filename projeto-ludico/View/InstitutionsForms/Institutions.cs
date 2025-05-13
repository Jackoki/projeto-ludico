using System;
using System.Collections.Generic;
using System.Windows.Forms;
using projeto_ludico.Service;
using projeto_ludico.View.Institutions;

namespace projeto_ludico.View.InstitutionsForms
{
    public partial class Institutions : BaseForm
    {
        public Institutions()
        {
            InitializeComponent();
            ConfigureInstitutionsViewer();
            dataViewer.CellContentClick += DataViewer_CellContentClick;
        }

        private void ConfigureInstitutionsViewer()
        {
            //Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite e um dicionário dos nomes a serem mostradas na coluna da tabela 
            string[] desiredColumns = { "name", "id" };
            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" }
            };

            //A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            //Passamos o null no final pois não temos nenhum JOIN a ser retornado na tabela
            ConfigureDataViewer(dataViewer, "institutions", desiredColumns, columnMappings, null);

            // Oculta as colunas especificadas
            OccultColumns(dataViewer, "id");
        }

        private void PerformSearch(string searchString)
        {
            // Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite
            string[] desiredColumns = { "name", "id" }; // Colunas retornadas
            string[] searchableColumns = { "name" };    // Colunas usadas na busca

            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" }
            };

            // A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            //Passamos o null no final pois não temos nenhum JOIN a ser retornado na tabela
            ConfigureSearchDataViewer(dataViewer, searchString, "institutions", desiredColumns, columnMappings, searchableColumns, null);

            // Oculta as colunas especificadas
            OccultColumns(dataViewer, "id");
        }


        //Quando o usuário clicar no botão de pesquisa, será chamada a função de busca
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchString = boxSearch.Text.Trim();
            PerformSearch(searchString);
        }

        //Como os botões são acionados posteriormente da renderização da tabela, é necessário criar uma função que cria um evento ao clica-la
        //Se o botão selecionado for o btnEdit, será aberto a tela de edição, se for o btnDelete, será a tela de deleção
        private void DataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataViewer.Rows[e.RowIndex];

            if (dataViewer.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                InstitutionsEdit institutionsEdit = new InstitutionsEdit();
                institutionsEdit.EditInstitution(row);
                institutionsEdit.Show();
            }

            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                InstitutionsDelete institutionsDelete = new InstitutionsDelete();
                institutionsDelete.DeleteInstitution(row);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            InstitutionsCreate institutionsCreate = new InstitutionsCreate();
            institutionsCreate.Show();
        }
    }
}
