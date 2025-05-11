using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using projeto_ludico.Utils;

namespace projeto_ludico.View
{
    public partial class BaseForm : Form
    {
        protected void ConfigureDataViewer(DataGridView dataViewer, string tableName, string[] desiredColumns, Dictionary<string, string> columnMappings)
        {
            var tableData = GetDataForViewer(tableName, desiredColumns, columnMappings);
            dataViewer.DataSource = tableData;

            AddActionButtonsToViewer(dataViewer);
        }

        private DataTable GetDataForViewer(string tableName, string[] desiredColumns, Dictionary<string, string> columnMappings)
        {
            var tableStructure = new DataTableStructure();
            return tableStructure.getTableStructure(tableName, desiredColumns, columnMappings);
        }

        private void AddActionButtonsToViewer(DataGridView dataViewer)
        {
            var editButton = CreateEditButton();
            dataViewer.Columns.Add(editButton);

            var deleteButton = CreateDeleteButton();
            dataViewer.Columns.Add(deleteButton);
        }

        private DataGridViewButtonColumn CreateEditButton()
        {
            var btnDataGridViewEdit = new ButtonsDataGridView();
            return btnDataGridViewEdit.getEditButton();
        }

        private DataGridViewButtonColumn CreateDeleteButton()
        {
            var btnDataGridViewDelete = new ButtonsDataGridView();
            return btnDataGridViewDelete.getDeleteButton();
        }
    }
}
