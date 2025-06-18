using projeto_ludico.Models;
using System;
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

        //Ao clicar no botão de criação, será montado as informações preenchidas ao Local, sendo esse passado no Controller, que por sua vez chama o Repository
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
