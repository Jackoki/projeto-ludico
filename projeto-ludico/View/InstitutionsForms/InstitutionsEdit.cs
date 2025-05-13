using System;
using System.Windows.Forms;
using projeto_ludico.Models;

namespace projeto_ludico.View.Institutions
{
    public partial class InstitutionsEdit : Form
    {
        public InstitutionsModel institutionsModel { get; set; }

        public InstitutionsEdit()
        {
            InitializeComponent();
            institutionsModel = new InstitutionsModel();
        }

        public void EditInstitution(DataGridViewRow row)
        {
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id))
            {
                institutionsModel.id = id;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            institutionsModel.name = txtBoxName.Text;

            InstitutionController institutionController = new InstitutionController();
            institutionController.EditInstitution(institutionsModel);
        }
    }
}
