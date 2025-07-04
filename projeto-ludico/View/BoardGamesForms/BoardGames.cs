﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using projeto_ludico.Service;

namespace projeto_ludico.View.BoardGamesForms
{
    public partial class BoardGames : BaseForm
    {
        public BoardGames()
        {
            InitializeComponent();
            ConfigureBoardGamesViewer();
        }

        //Realiza a chamada das informações do SQL, passamos as colunas que queremos e as renomeamos no da DataGrid
        private void ConfigureBoardGamesViewer() {
            dataViewer.Columns.Clear();
            dataViewer.DataSource = null;

            // Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite
            string[] desiredColumns = {
                "board_games.id as id", "COALESCE(board_games_names.name, '') AS name"
            };

            string[] searchableColumns = { "board_games_names.name", "board_games.id" };  // Colunas usadas na busca

            var columnMappings = new Dictionary<string, string>
            {
                { "id", "Id" },
                { "name", "Nome" }
            };

            string joinClause = "LEFT JOIN board_games_names ON (board_games_names.id_board_game = board_games.id AND board_games_names.is_principal = 1)";

            ConfigureDataViewer(dataViewer, "board_games", desiredColumns, columnMappings, joinClause, false);


            // Oculta as colunas especificadas
            OccultColumns(dataViewer, "id");
        }

        //Função responsável para realizar a atualização de pesquisa quando o usuário realizar a pesquisa no formulário
        private void PerformSearch(string searchString) {
            dataViewer.Columns.Clear();
            dataViewer.DataSource = null;

            // Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite
            string[] desiredColumns = {
                "board_games.id as id", "COALESCE(board_games_names.name, '') AS name"
            };

            string[] searchableColumns = { "board_games_names.name", "board_games_bar_codes.bar_code"};  // Colunas usadas na busca

            var columnMappings = new Dictionary<string, string>
            {
                { "id", "Id" },
                { "name", "Nome" }
            };

            string joinClause = "LEFT JOIN board_games_names ON (board_games_names.id_board_game = board_games.id AND board_games_names.is_principal = 1) " +
                                "LEFT JOIN board_games_bar_codes ON (board_games_bar_codes.id_board_game = board_games.id)";



            // A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            ConfigureSearchDataViewer(dataViewer, searchString, "board_games", desiredColumns, columnMappings, searchableColumns, joinClause);

            // Oculta as colunas especificadas
            OccultColumns(dataViewer, "id");

            AddActionButtonsToViewer(dataViewer, false);
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
                BoardGamesEdit boardgamesEdit = new BoardGamesEdit(row);
                boardgamesEdit.Show();
            }

            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnDelete") {
                BoardGamesDelete boardgamesDelete = new BoardGamesDelete();
                boardgamesDelete.DeleteBoardGames(row);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            BoardGamesCreate boardgamesCreate = new BoardGamesCreate();
            boardgamesCreate.Show();
        }
    }
}
