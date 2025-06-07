using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_ludico.Repository;
using projeto_ludico.Utils;

namespace projeto_ludico.View.ListForms.ListManagerForms
{
    public class LoadDataViewers {
        private BoardGamesListRepository repositoryListGames = new BoardGamesListRepository();
        private ButtonsDataGridView buttonsDataGridView = new ButtonsDataGridView();

        public void loadViewList(DataGridView dataViewerList, int listId)
        {
            var gamesList = repositoryListGames.GetGamesByListId(listId);

            // Projeta diretamente a lista de jogos
            var dataSource = gamesList.Select(g => new
            {
                ID = g.id,
                NomeDoJogo = g.main_name
            }).ToList();

            // Define o DataSource
            dataViewerList.DataSource = dataSource;

            // Ajusta as colunas do DataGridView
            dataViewerList.Columns["NomeDoJogo"].HeaderText = "Nome do Jogo";
            dataViewerList.Columns["NomeDoJogo"].SortMode = DataGridViewColumnSortMode.Automatic;
            dataViewerList.Columns["ID"].Visible = false;

            // Adiciona botão de remoção
            if (!dataViewerList.Columns.Contains("btnRemove")) {
                var btnRemove = buttonsDataGridView.GetRemoveButton(); // Adiciona botão de remoção
                dataViewerList.Columns.Add(btnRemove);
            }
        }



    }
}
