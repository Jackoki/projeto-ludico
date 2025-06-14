using projeto_ludico.View.ListForms;
using projeto_ludico.View.RPGForms.RPGManagerForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void ConfigureRPGViewer()
        {
            string[] desiredColumns = { "name", "id" };
            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" },
            };

            ConfigureDataViewer(dataViewer, "role_play_games", desiredColumns, columnMappings, null, true);
            OccultColumns(dataViewer, "id");
        }

        private void PerformSearch(string searchString)
        {
            string[] desiredColumns = { "name", "id" };
            string[] searchableColumns = { "name" };

            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" },
            };

            ConfigureSearchDataViewer(dataViewer, searchString, "role_play_games", desiredColumns, columnMappings, searchableColumns, null);
            OccultColumns(dataViewer, "id");
        }

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
                RPGManager rpgManager = new RPGManager();
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
