using projeto_ludico.Controllers;
using projeto_ludico.Models;
using projeto_ludico.Repository;
using projeto_ludico.Utils;
using projeto_ludico.View.ListForms.ListManagerForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Windows.Forms;

namespace projeto_ludico.View.ListForms
{
    public partial class ListManager : BaseForm
    {
        public DataGridViewRow row;
        public int id_list;
        LoadDataViewers loadDataViewers = new LoadDataViewers();
        ButtonsDataGridView buttonsDataGridView = new ButtonsDataGridView();
        BoardGamesListController listGamesController = new BoardGamesListController();

        private Dictionary<string, string> GetColumnMappings() {
            return new Dictionary<string, string> { { "id", "Id" }, { "name", "Nome" }};
        }

        private string GetJoinClause() {
            return "LEFT JOIN board_games_names ON (board_games_names.id_board_game = board_games.id AND board_games_names.is_principal = 1) " +
                   "LEFT JOIN board_games_bar_codes ON (board_games_bar_codes.id_board_game = board_games.id)";
        }

        public ListManager(DataGridViewRow rowInitial) {
            InitializeComponent();

            row = rowInitial;
            ManagerList();
            ConfigureBoardGamesViewer();
            LoadDataViewerList();
        }

        private void ConfigureBoardGamesViewer() {
            string[] desiredColumns = { "board_games.id AS id", "COALESCE(board_games_names.name, '') AS name" }; // Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite
            string[] searchableColumns = { "board_games_names.name", "board_games.id" };  // Colunas usadas na busca

            var columnMappings = GetColumnMappings();
            string joinClause = GetJoinClause();

            ConfigureDataViewerWithoutButtons(dataViewerGames, "board_games", desiredColumns, columnMappings, joinClause);
            OccultColumns(dataViewerGames, "id"); // Oculta as colunas especificadas

            var btnAdd = buttonsDataGridView.GetAddButton();
            dataViewerGames.Columns.Add(btnAdd);
        }

        //Função responsável para realizar a atualização de pesquisa quando o usuário realizar a pesquisa no formulário
        private void PerformSearch(string searchString) {
            string[] desiredColumns = {"board_games.id AS id", "COALESCE(board_games_names.name, '') AS name" }; // Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite
            string[] searchableColumns = { "board_games_names.name", "board_games_bar_codes.bar_code" };  // Colunas usadas na busca

            var columnMappings = GetColumnMappings();
            string joinClause = GetJoinClause();

            // A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            ConfigureSearchDataViewer(dataViewerGames, searchString, "board_games", desiredColumns, columnMappings, searchableColumns, joinClause);
            OccultColumns(dataViewerGames, "id"); // Oculta as colunas especificadas
        }
        internal void LoadDataViewerList()
        {
            loadDataViewers.loadViewList(dataViewerList, id_list);
        }

        internal void ManagerList() {
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id)) {
                id_list = id;
            }
        }

        private void dataViewerGames_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0)
                return;

            if (dataViewerGames.Columns[e.ColumnIndex].Name == "btnAdd") {
                var selectedRow = dataViewerGames.Rows[e.RowIndex];

                if (selectedRow.Cells["id"].Value != null && int.TryParse(selectedRow.Cells["id"].Value.ToString(), out int id_board_game)) {
                    listGamesController.AddGame(id_list, id_board_game);
                    LoadDataViewerList();
                }
            }
        }

        private void dataViewerList_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0)
                return;

            if (dataViewerList.Columns[e.ColumnIndex].Name == "btnRemove") {
                var selectedRow = dataViewerList.Rows[e.RowIndex];

                if (selectedRow.Cells["ID"].Value != null && int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out int id)) {
                    listGamesController.RemoveGame(id_list, id);
                    LoadDataViewerList();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            PerformSearch(txtSearch.Text.Trim());
        }


    }
}
