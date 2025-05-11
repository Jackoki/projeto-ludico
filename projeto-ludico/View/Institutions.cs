using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
    }
}
