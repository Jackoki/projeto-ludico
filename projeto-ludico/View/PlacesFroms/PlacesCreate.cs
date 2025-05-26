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

namespace projeto_ludico.View.PlacesForms
{
    public partial class PlacesCreate : Form
    {
        public event EventHandler PlaceRegistered;
        public PlacesCreate()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            PlacesModel placesModel = new PlacesModel();
            placesModel.name = txtBoxName.Text;

            PlacesController placesController = new PlacesController();
            placesController.RegisterPlace(placesModel);

            OnPlaceRegistered();
        }

        protected virtual void OnPlaceRegistered()
        {
            PlaceRegistered?.Invoke(this, EventArgs.Empty);
        }
    }
}
