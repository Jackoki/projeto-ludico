﻿using projeto_ludico.Controllers;
using projeto_ludico.Models;
using System;
using System.Windows.Forms;

namespace projeto_ludico.View.RPGForms
{
    public partial class RPGCreate : Form
    {
        public event EventHandler RPGRegistered;

        public RPGCreate()
        {
            InitializeComponent();
        }

         //Ao clicar no botão de criação, será montado as informações preenchidas ao RPG, sendo esse passado no Controller, que por sua vez chama o Repository
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RPGModel rpgModel = new RPGModel();
            rpgModel.name = txtBoxName.Text.Trim();
            rpgModel.description = txtDescricao.Text.Trim();

            RPGController rpgController = new RPGController();
            rpgController.RegisterRPG(rpgModel);

            OnRPGRegistered();
        }

        protected virtual void OnRPGRegistered()
        {
            RPGRegistered?.Invoke(this, EventArgs.Empty);
        }
    }
}
