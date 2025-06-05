using projeto_ludico.View.ListForms;
using projeto_ludico.View.PlacesForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_ludico.View.ListForms
{
    public partial class List : BaseForm
    {
        public List()
        {
            InitializeComponent();
            ConfigureListViewer();
            dataViewer.CellContentClick += DataViewer_CellContentClick;
        }

        private void ConfigureListViewer()
        {
            string[] desiredColumns = { "name", "id"};
            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome da Lista" },
            };

            //Passamos o false para dizer que não iremos adicionar o botão "Gerenciar" na linha
            ConfigureDataViewer(dataViewer, "lists", desiredColumns, columnMappings, null, false);
            OccultColumns(dataViewer, "id");

            if (!dataViewer.Columns.Contains("btnManage"))
            {
                DataGridViewButtonColumn btnManage = new DataGridViewButtonColumn
                {
                    Name = "btnManage",
                    HeaderText = "",
                    Text = "Gerenciar",
                    UseColumnTextForButtonValue = true
                };
                dataViewer.Columns.Add(btnManage);
            }
        }

        private void PerformSearch(string searchString)
        {
            string[] desiredColumns = { "name", "id"};
            string[] searchableColumns = { "name" };

            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome da Lista" },
            };

            ConfigureSearchDataViewer(dataViewer, searchString, "lists", desiredColumns, columnMappings, searchableColumns, null);
            OccultColumns(dataViewer, "id");
        }
        private void DataViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataViewer.Rows[e.RowIndex];

            if (dataViewer.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                ListEdit editForm = new ListEdit();
                editForm.EditList(row);
                editForm.Show();
            }
            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                ListDelete deleteForm = new ListDelete();
                deleteForm.DeleteList(row);
            }
            else if (dataViewer.Columns[e.ColumnIndex].Name == "btnManage")
            {
                ListManager manageForm = new ListManager();
                manageForm.ManageList(row);
                manageForm.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchString = textBox1.Text.Trim();
            PerformSearch(searchString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListCreate listCreate = new ListCreate();
            listCreate.Show();
        }
    }
}
