using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_ludico.Utils
{
    internal class ButtonsDataGridView
    {
        public DataGridViewButtonColumn getEditButton()
        {
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "";
            btnEdit.Name = "btnEdit";
            btnEdit.Text = "Editar";
            btnEdit.UseColumnTextForButtonValue = true;
            return btnEdit;
        }

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
