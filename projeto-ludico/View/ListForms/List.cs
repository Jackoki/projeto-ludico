using projeto_ludico.View.ListForms;
using projeto_ludico.View.PlacesForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_ludico.View.ListForms
{
    public partial class List : BaseForm
    {
        public List()
        {
            InitializeComponent();
            ConfigureListViewer();
            dataViewer.CellContentClick += DataViewer_CellContentClick;
        }
        
        //Realiza a chamada das informações do SQL, passamos as colunas que queremos e as renomeamos no da DataGrid
        private void ConfigureListViewer()
        {
            string[] desiredColumns = { "name", "id"};
            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome da Lista" },
            };

            //Passamos o false para dizer que não iremos adicionar o botão "Gerenciar" na linha
            ConfigureDataViewer(dataViewer, "lists", desiredColumns, columnMappings, null, true);
            OccultColumns(dataViewer, "id");
        }

         //Função responsável para realizar a atualização de pesquisa quando o usuário realizar a pesquisa no formulário
        private void PerformSearch(string searchString)
        {
            // Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite
            string[] desiredColumns = { "name", "id"};
            string[] searchableColumns = { "name" }; // Colunas usadas na busca

            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome da Lista" },
            };

            // A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            //Passamos o null no final pois não temos nenhum JOIN a ser retornado na tabela
            ConfigureSearchDataViewer(dataViewer, searchString, "lists", desiredColumns, columnMappings, searchableColumns, null);
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
                ListEdit editForm = new ListEdit();
                editForm.EditList(row);
                editForm.Show();
            }
            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                ListDelete deleteForm = new ListDelete();
                deleteForm.DeleteList(row);
            }
            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnManagement")
            {
                ListManager managerForm = new ListManager(row);
                managerForm.Show();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ListCreate listCreate = new ListCreate();
            listCreate.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text.Trim();
            PerformSearch(searchString);
        }
    }
}
