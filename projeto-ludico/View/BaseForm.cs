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
        protected void ConfigureDataViewer(DataGridView dataViewer, string tableName, string[] desiredColumns, Dictionary<string, string> columnMappings)
        {
            //Chamada da função que realiza a pesquisa da tabela do SQLite e posteriormente nomeação das colunas da tabela
            var tableData = GetDataForViewer(tableName, desiredColumns, columnMappings);
            dataViewer.DataSource = tableData;

            //Realiza a chamada da ação dos botões de edição e deleção nas colunas
            AddActionButtonsToViewer(dataViewer);
        }

        protected void ConfigureSearchDataViewer(DataGridView dataViewer, string searchInfo, string tableName, string[] desiredColumns, Dictionary<string, string> columnMappings)
        {
            //Chamada da função que realiza a pesquisa da tabela do SQLite e posteriormente nomeação das colunas da tabela
            //A diferença dessa função com a de cima, é que ele tem como utilidade a realização de busca a partir do que o usuário digitar
            var tableData = GetSearchDataForViewer(tableName, searchInfo, desiredColumns, columnMappings);
            dataViewer.DataSource = tableData;
        }

        protected DataTable GetDataForViewer(string tableName, string[] desiredColumns, Dictionary<string, string> columnMappings)
        {
            //Realiza a função de pesquisa do nome da tabela e a nomeação das colunas da classe DataTableStructure
            var tableStructure = new DataTableStructure();
            return tableStructure.getTableStructure(tableName, desiredColumns, columnMappings);
        }

        protected DataTable GetSearchDataForViewer(string tableName, string searchInfo, string[] desiredColumns, Dictionary<string, string> columnMappings)
        {
            //Realiza a função de pesquisa do nome da tabela e a nomeação das colunas da classe DataTableSearchStructure
            var tableStructure = new DataTableSearchStructure();
            return tableStructure.getTableSearchStructure(tableName, searchInfo, desiredColumns, columnMappings);
        }

        //Função para adicionar os botões de edição e deleção na linha
        protected void AddActionButtonsToViewer(DataGridView dataViewer)
        {
            var editButton = CreateEditButton();
            dataViewer.Columns.Add(editButton);

            var deleteButton = CreateDeleteButton();
            dataViewer.Columns.Add(deleteButton);
        }

        //Função para chamada da classe que retorna o botão de editar
        private DataGridViewButtonColumn CreateEditButton()
        {
            var btnDataGridViewEdit = new ButtonsDataGridView();
            return btnDataGridViewEdit.getEditButton();
        }

        //Função para chamada da classe que retorna o botão de deletar
        private DataGridViewButtonColumn CreateDeleteButton()
        {
            var btnDataGridViewDelete = new ButtonsDataGridView();
            return btnDataGridViewDelete.getDeleteButton();
        }
    }
}
