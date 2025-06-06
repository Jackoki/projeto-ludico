using projeto_ludico.Controllers;
using projeto_ludico.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_ludico.View.ListForms
{
    public partial class ListManager : BaseForm
    {
        ListController listController = new ListController();
        ListGamesController listGamesController = new ListGamesController();
        private int id_list;

        public ListManager()
        {
            InitializeComponent();
            ConfigureBoardGamesViewer();
        }

        private void ConfigureBoardGamesViewer()
        {
            // Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite
            string[] desiredColumns = {"board_games.id", "board_games_names.name"};

            string[] searchableColumns = { "board_games_names.name", "board_games.id" };  // Colunas usadas na busca

            var columnMappings = new Dictionary<string, string> {{ "id", "Id" }, { "name", "Nome" }};

            string joinClause = "LEFT JOIN board_games_names ON (board_games_names.id_board_game = board_games.id AND board_games_names.is_principal = 1)";

            ConfigureDataViewerWithoutButtons(dataViewerGames, "board_games", desiredColumns, columnMappings, joinClause);

            // Oculta as colunas especificadas
            OccultColumns(dataViewerGames, "id");

            var btnAddButton = new ButtonsDataGridView().GetAddButton();
            dataViewerGames.Columns.Add(btnAddButton);
        }

        //Função responsável para realizar a atualização de pesquisa quando o usuário realizar a pesquisa no formulário
        private void PerformSearch(string searchString)
        {
            // Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite
            string[] desiredColumns = {"board_games.id", "board_games_names.name"};

            string[] searchableColumns = { "board_games_names.name", "board_games_bar_codes.bar_code" };  // Colunas usadas na busca

            var columnMappings = new Dictionary<string, string>{{ "id", "Id" }, { "name", "Nome" }};

            string joinClause = "LEFT JOIN board_games_names ON (board_games_names.id_board_game = board_games.id AND board_games_names.is_principal = 1) " +
                                "LEFT JOIN board_games_bar_codes ON (board_games_bar_codes.id_board_game = board_games.id)";

            // A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            //Passamos o null no final pois não temos nenhum JOIN a ser retornado na tabela
            ConfigureSearchDataViewer(dataViewerGames, searchString, "board_games", desiredColumns, columnMappings, searchableColumns, joinClause);

            // Oculta as colunas especificadas
            OccultColumns(dataViewerGames, "id");
        }


        private void ConfigureGameListViewer(int listId) {
            // Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite
            string[] desiredColumns = {"board_games_list.id", "board_games_names.name"};

            var columnMappings = new Dictionary<string, string> {{ "id", "Id" }, { "name", "Nome" }};

            string joinClause = "LEFT JOIN board_games ON (board_games_list.id_board_game = board_games.id)" +
                                "LEFT JOIN board_games_names ON (board_games_names.id_board_game = board_games.id AND board_games_names.is_principal = 1) ";

            ConfigureDataViewerWithoutButtons(dataViewer, "board_games_list", desiredColumns, columnMappings, joinClause);

            // Oculta as colunas especificadas
            OccultColumns(dataViewer, "id");

            // Verifica se a coluna do botão já foi adicionada
            if (!dataViewer.Columns.Contains("btnRemove"))
            {
                var btnRemoveButton = new ButtonsDataGridView().GetDeleteButton();
                dataViewer.Columns.Add(btnRemoveButton);
            }
        }

        private void LoadDataForGameList(int listId)
        {
            string[] desiredColumns = { "board_games.id", "board_games_names.name" };
            string joinClause = "LEFT JOIN board_games_names ON (board_games_names.id_board_game = board_games.id AND board_games_names.is_principal = 1)";

            // Atualiza os dados exibidos, sem reconfigurar as colunas
            ConfigureDataViewerWithoutButtons(dataViewer, "board_games_list", desiredColumns, new Dictionary<string, string> {{ "id", "Id" }, { "name", "Nome" }}, joinClause);

            OccultColumns(dataViewer, "id");
        }



        internal void ManageList(DataGridViewRow row)
        {
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id))
            {
                id_list = id;
                ConfigureGameListViewer(id_list);
            }
        }

        private void dataViewerGames_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Confere se clicou na coluna do botão "Remover"
            if (dataViewerGames.Columns[e.ColumnIndex].Name == "btnAdd" && e.RowIndex >= 0)
            {
                // Obtem o id do jogo daquela linha
                int idGame = Convert.ToInt32(dataViewerGames.Rows[e.RowIndex].Cells["id"].Value);

                // Chama o método para adicionar o jogo da lista
                listGamesController.AddGame(id_list, idGame);
            }

            LoadDataForGameList(id_list);
        }

        private void DataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Confere se clicou na coluna do botão "Remover"
            if (dataViewer.Columns[e.ColumnIndex].Name == "btnRemove" && e.RowIndex >= 0)
            {
                // Obtem o id do jogo daquela linha
                int idGame = Convert.ToInt32(dataViewer.Rows[e.RowIndex].Cells["id"].Value);

                listGamesController.RemoveGame(id_list, idGame);
            }

            LoadDataForGameList(id_list);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch(txtSearch.Text.Trim());
        }
    }
}
