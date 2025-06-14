using projeto_ludico.Controllers;
using projeto_ludico.Models;
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
    public partial class RPGEdit : Form
    {
        RPGModel rpgModel = new RPGModel();
        RPGController rpgController = new RPGController();

        public RPGEdit()
        {
            InitializeComponent();
            
        }

        public void EditRPG(DataGridViewRow row)
        {
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id))
            {
                rpgModel.id = id;
                rpgModel = rpgController.GetRpg(rpgModel.id);

                txtDescricao.Text = rpgModel.description;
                txtBoxName.Text = rpgModel.name;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            rpgModel.name = txtBoxName.Text.Trim();
            rpgModel.description = txtDescricao.Text.Trim();

            rpgController.EditRPG(rpgModel);
        }
    }
}
