﻿using projeto_ludico.Controllers;
using projeto_ludico.Models;
using System;
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

        //Atribuimos os campos de preenchimento do formulário com as informações do RPG identificado pelo Id passado pelo Row
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
