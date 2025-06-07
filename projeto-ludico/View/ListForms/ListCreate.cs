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

namespace projeto_ludico.View.ListForms
{
    public partial class ListCreate : Form
    {
        public ListCreate()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Cria o modelo com os dados do formulário
            ListModel listModel = new ListModel();
            listModel.name = txtBoxName.Text;
            listModel.EventId = 0;

            // Chama o controller para salvar no banco
            ListController listController = new ListController();
            listController.CreateList(listModel);
        }
    }
}
