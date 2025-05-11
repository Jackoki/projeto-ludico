using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_ludico.Utils
{
    //Classse com a responsabilidade de retornar 2 botões quando chamado em um DataView, sendo um de Editar e outro de Deletar
    internal class ButtonsDataGridView
    {
        //Retorna um botão de linha de tabela nomeado btnEdit mas que está escrito Editar
        public DataGridViewButtonColumn getEditButton()
        {
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "";
            btnEdit.Name = "btnEdit";
            btnEdit.Text = "Editar";
            btnEdit.UseColumnTextForButtonValue = true;
            return btnEdit;
        }

        //Retorna um botão de linha de tabela nomeado btnDelete mas que está escrito Deletar
        public DataGridViewButtonColumn getDeleteButton()
        {
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "";
            btnDelete.Name = "btnDelete";
            btnDelete.Text = "Deletar";
            btnDelete.UseColumnTextForButtonValue = true;
            return btnDelete;
        }
    }
}
