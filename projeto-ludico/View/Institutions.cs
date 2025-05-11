using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using projeto_ludico.Controllers;

namespace projeto_ludico.View
{
    public partial class Institutions : BaseForm
    {
        public Institutions()
        {
            InitializeComponent();
            ConfigureInstitutionsViewer();
        }

        private void ConfigureInstitutionsViewer()
        {
            string[] desiredColumns = { "name" };
            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" }
            };

            ConfigureDataViewer(dataViewer, "institutions", desiredColumns, columnMappings);
        }

        private void Institutions_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchString = boxSearch.Text;

            var filters = new List<SearchFilter>
            {
                new SearchFilter { ColumnName = "name", SearchTerm = searchString, Operator = SearchOperator.Contains }
            };

            try
            {
                var researchTable = new ResearchTable();
                DataTable results = researchTable.SearchWithFilters("institutions", filters);

                dataViewer.DataSource = results;
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao executar a pesquisa: {ex.Message}");
            }
        }

    }
}
