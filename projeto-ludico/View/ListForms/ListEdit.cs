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
    public partial class ListEdit : Form
    {
        public ListModel listModel { get; set; }

        public ListEdit()
        {
            InitializeComponent();
            listModel = new ListModel();
        }

        public void EditList(DataGridViewRow row)
        {
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id))
            {
                listModel.id = id;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            listModel.name = txtBoxName.Text;

            ListController listController = new ListController();
            listController.EditList(listModel);
        }
    }
}
