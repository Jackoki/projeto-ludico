using System.Windows.Forms;

namespace projeto_ludico.Utils
{
    //Classse com a responsabilidade de retornar 2 botões quando chamado em um DataView, sendo um de Editar e outro de Deletar
    internal class ButtonsDataGridView
    {
        //Retorna um botão de linha de tabela nomeado btnEdit mas que está escrito Editar
        public DataGridViewButtonColumn GetEditButton()
        {
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "";
            btnEdit.Name = "btnEdit";
            btnEdit.Text = "Editar";
            btnEdit.UseColumnTextForButtonValue = true;
            return btnEdit;
        }

        //Retorna um botão de linha de tabela nomeado btnDelete mas que está escrito Deletar
        public DataGridViewButtonColumn GetDeleteButton()
        {
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "";
            btnDelete.Name = "btnDelete";
            btnDelete.Text = "Deletar";
            btnDelete.UseColumnTextForButtonValue = true;
            return btnDelete;
        }
        public DataGridViewButtonColumn GetManagementButton()
        {
            DataGridViewButtonColumn btnManagement = new DataGridViewButtonColumn();
            btnManagement.HeaderText = "";
            btnManagement.Name = "btnManagement";
            btnManagement.Text = "Gerenciar";
            btnManagement.UseColumnTextForButtonValue = true;
            return btnManagement;
        }

        public DataGridViewButtonColumn GetAddButton()
        {
            DataGridViewButtonColumn btnManagement = new DataGridViewButtonColumn();
            btnManagement.HeaderText = "";
            btnManagement.Name = "btnAdd";
            btnManagement.Text = "Adicionar";
            btnManagement.UseColumnTextForButtonValue = true;
            return btnManagement;
        }

        public DataGridViewButtonColumn GetRemoveButton()
        {
            DataGridViewButtonColumn btnRemove = new DataGridViewButtonColumn();
            btnRemove.HeaderText = "";
            btnRemove.Name = "btnRemove";
            btnRemove.Text = "Remover";
            btnRemove.UseColumnTextForButtonValue = true;
            return btnRemove;
        }

        public DataGridViewButtonColumn GetReturnButton()
        {
            DataGridViewButtonColumn btnReturn = new DataGridViewButtonColumn();
            btnReturn.HeaderText = "";
            btnReturn.Name = "btnReturn";
            btnReturn.Text = "Devolver Jogo";
            btnReturn.UseColumnTextForButtonValue = true;
            return btnReturn;
        }
    }
}
