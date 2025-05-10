using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_ludico.Database;
using projeto_ludico.Utils;

namespace projeto_ludico.View
{
    public partial class Institutions : Form
    {
        public Institutions()
        {
            InitializeComponent();
            string[] desiredColumns = { "name" };
            var columnMappings = new Dictionary<string, string>
            {
                { "name", "Nome" }
            };

            DataTable tableData = DataTableStructure.getTableStructure("institutions", desiredColumns, columnMappings);
            dataViewer.DataSource = tableData;
        }

        private void Institutions_Load(object sender, EventArgs e)
        {

        }
    }
}
