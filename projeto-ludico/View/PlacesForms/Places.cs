using projeto_ludico.Service;
using projeto_ludico.View.Places;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_ludico.View.PlacesForms
{
    public partial class Places : BaseForm
    {
        public Places()
        {
            InitializeComponent();
            ConfigurePlacesViewer();
            dataViewer.CellContentClick += DataViewer_CellContentClick;
        }

        private void Places_Load(object sender, EventArgs e)
        {

        }

        private void ConfigurePlacesViewer()
        {
            string[] desiredColumns = { "name", "id" };
            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" }
            };

            ConfigureDataViewer(dataViewer, "events_local", desiredColumns, columnMappings, null, false);
            OccultColumns(dataViewer, "id");
        }

        private void PerformSearch(string searchString)
        {
            string[] desiredColumns = { "name", "id" };
            string[] searchableColumns = { "name" };

            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" }
            };

            ConfigureSearchDataViewer(dataViewer, searchString, "events_local", desiredColumns, columnMappings, searchableColumns, null);
            OccultColumns(dataViewer, "id");
        }

        private void DataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataViewer.Rows[e.RowIndex];

            if (dataViewer.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                PlacesEdit placesEdit = new PlacesEdit();
                placesEdit.EditPlace(row);
                placesEdit.Show();
            }
            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                PlacesDelete placesDelete = new PlacesDelete();
                placesDelete.DeletePlace(row);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            PlacesCreate placesCreate = new PlacesCreate();
            placesCreate.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchString = boxSearch.Text.Trim();
            PerformSearch(searchString);
        }

        private void boxSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
