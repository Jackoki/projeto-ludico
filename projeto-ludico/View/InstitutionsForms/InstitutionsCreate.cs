using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_ludico.Models;

namespace projeto_ludico.View.InstitutionsForms
{
    public partial class InstitutionsCreate : Form
    {
        public InstitutionsCreate()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            InstitutionsModel institutionsModel = new InstitutionsModel();
            institutionsModel.Name = txtBoxName.Text;

            InstitutionController institutionController = new InstitutionController();
            institutionController.RegisterInstitution(institutionsModel);
        }
    }
}
