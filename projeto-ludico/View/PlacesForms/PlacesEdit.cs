using projeto_ludico.Models;
using System;
using System.Windows.Forms;

namespace projeto_ludico.View.Places
{
    public partial class PlacesEdit : Form
    {
        public PlacesModel placesModel { get; set; }

        public PlacesEdit()
        {
            InitializeComponent();
            placesModel = new PlacesModel();
        }

        public void EditPlace(DataGridViewRow row)
        {
            if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out int id))
            {
                placesModel.id = id;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            placesModel.name = txtBoxName.Text;

            PlacesController placesController = new PlacesController();
            placesController.EditPlace(placesModel);
        }
    }
}
