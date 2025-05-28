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
using projeto_ludico.View.BoardGamesForms;

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
        private void ConfigureBoardGamesViewer()
        {
            string[] desiredColumns = {
                "board_games.id", "board_games_names.name", "board_games.description", "board_games.min_players", "board_games.max_players",
                "board_games.game_time"
            };

            var columnMappings = new Dictionary<string, string>
            {
                { "id", "Id" },
                { "name", "Nome" },
                { "description", "Descrição" },
                { "min_players", "Minimo de Jogadores" },
                { "max_players", "Maximo de Jogadores" },
                { "game_time", "Duração de Jogo" }
            };

            string joinClause = "LEFT JOIN board_games_names ON (board_games_names.id_board_game = board_games.id AND board_games_names.is_principal = 1)";

            ConfigureDataViewer(dataViewer, "board_games", desiredColumns, columnMappings, joinClause);


            // Oculta as colunas especificadas
            OccultColumns(dataViewer, "id");
        }

        //Função responsável para realizar a atualização de pesquisa quando o usuário realizar a pesquisa no formulário
        private void PerformSearch(string searchString)
        {
            // Passamos o nome da coluna que queremos que seja retornada da consulta do SQLite
            string[] desiredColumns = {
                "board_games.id", "board_games_names.name", "board_games.description", "board_games.min_players", "board_games.max_players",
                "board_games.game_time"
            };

            string[] searchableColumns = { "board_games_names.name", "board_games.id" };  // Colunas usadas na busca

            var columnMappings = new Dictionary<string, string>
            {
                { "id", "Id" },
                { "name", "Nome" },
                { "description", "Descrição" },
                { "min_players", "Minimo de Jogadores" },
                { "max_players", "Maximo de Jogadores" },
                { "game_time", "Duração de Jogo" }
            };

            string joinClause = "LEFT JOIN board_games_names ON (board_games_names.id_board_game = board_games.id AND board_games_names.is_principal = 1)";


            // A chamada das funções é feita pelo BaseForm, que é a classe mãe desse formulário
            //Passamos o null no final pois não temos nenhum JOIN a ser retornado na tabela
            ConfigureSearchDataViewer(dataViewer, searchString, "board_games", desiredColumns, columnMappings, searchableColumns, joinClause);

            // Oculta as colunas especificadas


            // Oculta as colunas especificadas
            OccultColumns(dataViewer, "id");
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            string searchString = boxSearch.Text.Trim();
            PerformSearch(searchString);
        }

        //Criação dos botões de editar e deletar em cada linha de forma automática
        private void dataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e) {
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
