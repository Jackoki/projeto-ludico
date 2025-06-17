using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_ludico.View.RPGForms
{
    public partial class RPG : BaseForm
    {
        public RPG()
        {
            InitializeComponent();
            ConfigureRPGViewer();
            dataViewer.CellContentClick += DataViewer_CellContentClick;
        }

         //Realiza a chamada das informações do SQL, passamos as colunas que queremos e as renomeamos no da DataGrid
        private void ConfigureRPGViewer()
        {
            string[] desiredColumns = { "name", "id" };
            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" },
            };

            //Passamos o null no final pois não temos nenhum JOIN a ser retornado na tabela
            //Passamos o true para dizer não iremos adicionar o botão "Gerenciar" na linha
            ConfigureDataViewer(dataViewer, "role_play_games", desiredColumns, columnMappings, null, true);
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
                { "name", "Nome" },
            };

            // A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            ConfigureSearchDataViewer(dataViewer, searchString, "role_play_games", desiredColumns, columnMappings, searchableColumns, null);

            // Oculta as colunas especificadas
            OccultColumns(dataViewer, "id");
        }

        //Criação dos botões de editar e deletar em cada linha de forma automática
        private void DataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataViewer.Rows[e.RowIndex];

            if (dataViewer.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                RPGEdit rpgEdit = new RPGEdit();
                rpgEdit.EditRPG(row);
                rpgEdit.Show();
            }
            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                RPGDelete rpgDelete = new RPGDelete();
                rpgDelete.DeleteRPG(row);
            }
            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnManagement")
            {
                RPGManager rpgManager = new RPGManager(row);
                rpgManager.Show();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RPGCreate rpgCreate = new RPGCreate();
            rpgCreate.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchString = boxSearch.Text.Trim();
            PerformSearch(searchString);
        }
    }
}
