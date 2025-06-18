using projeto_ludico.Controllers;
using projeto_ludico.Models;
using System;
using System.Windows.Forms;

namespace projeto_ludico.View.ListForms
{
    public partial class ListCreate : Form
    {

        //Ao renderizar a função, será carregado o ComboBox da função abaixo, atribuindo o Nome e Id como Valor
        public ListCreate()
        {
            InitializeComponent();
        }

        //Ao clicar no botão de criação, será montado as informações preenchidas à Lista, sendo esse passado no Controller, que por sua vez chama o Repository
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
