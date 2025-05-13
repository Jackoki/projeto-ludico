using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using projeto_ludico.Utils;

namespace projeto_ludico.View
{
    public partial class BaseForm : Form
    {
        //Função utilizada para chamar o GetDataForViewer e a adição dos botões de edição e alteração na linha
        protected void ConfigureDataViewer(DataGridView dataViewer, string tableName, string[] desiredColumns, Dictionary<string, string> columnMappings, string joinClause) {
            //Chamada da função que realiza a pesquisa da tabela do SQLite e posteriormente nomeação das colunas da tabela
            var tableData = GetDataForViewer(tableName, desiredColumns, columnMappings, joinClause);
            dataViewer.DataSource = tableData;

            //Realiza a chamada da ação dos botões de edição e deleção nas colunas
            AddActionButtonsToViewer(dataViewer);
        }

        protected DataTable GetDataForViewer(string tableName, string[] desiredColumns, Dictionary<string, string> columnMappings, string joinClause) {
            //Realiza a função de pesquisa do nome da tabela e a nomeação das colunas da classe DataTableStructure
            var tableStructure = new DataTableStructure();
            return tableStructure.GetTableStructure(tableName, desiredColumns, columnMappings, joinClause);
        }

        protected void ConfigureSearchDataViewer(DataGridView dataViewer, string searchInfo, string tableName, string[] desiredColumns, Dictionary<string, string> columnMappings, string[] searchableColumns, string joinClause) {
            // Chamada da função que realiza a pesquisa da tabela do SQLite
            var tableData = GetSearchDataForViewer(tableName, searchInfo, desiredColumns, columnMappings, searchableColumns, joinClause);
            dataViewer.DataSource = tableData;
        }

        //A diferença é que essa função necessita de 2 lista de strings a mais, sendo um de colunas desejadas e outra de colunas a serem consideradas na consulta
        protected DataTable GetSearchDataForViewer(string tableName, string searchInfo, string[] desiredColumns, Dictionary<string, string> columnMappings, string[] searchableColumns, string joinClause) {
            var tableStructure = new DataTableSearchStructure();
            return tableStructure.GetTableSearchStructure(tableName, searchInfo, desiredColumns, columnMappings, searchableColumns, joinClause);
        }

        //Função para adicionar os botões de edição e deleção na linha
        protected void AddActionButtonsToViewer(DataGridView dataViewer) {
            var editButton = CreateEditButton();
            dataViewer.Columns.Add(editButton);

            var deleteButton = CreateDeleteButton();
            dataViewer.Columns.Add(deleteButton);
        }

        //Função para chamada da classe que retorna o botão de editar
        private DataGridViewButtonColumn CreateEditButton() {
            var btnDataGridViewEdit = new ButtonsDataGridView();
            return btnDataGridViewEdit.GetEditButton();
        }

        //Função para chamada da classe que retorna o botão de deletar
        private DataGridViewButtonColumn CreateDeleteButton() {
            var btnDataGridViewDelete = new ButtonsDataGridView();
            return btnDataGridViewDelete.GetDeleteButton();
        }

        //Função utilizada para ocultar colunas da tabela, sendo passada a tabela e as colunas a serem ocultadas
        protected void OccultColumns(DataGridView viewer, params string[] columnsToOccult) {
            foreach (var column in columnsToOccult) {
                if (viewer.Columns.Contains(column)) {
                    viewer.Columns[column].Visible = false;
                }
            }
        }

    }
}
