using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_ludico.Models;

namespace projeto_ludico.View.InstitutionsForms
{
    public partial class InstitutionsCreate : Form
    {
        //Classe EventHandler (nativa do C#), ele serve para mandar "notificação" para outras telas ao realizar alguma ação, acionando outras funções em outras telas
        public event EventHandler InstitutionRegistered;

        public InstitutionsCreate()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            InstitutionsModel institutionsModel = new InstitutionsModel();
            institutionsModel.name = txtBoxName.Text;

            InstitutionController institutionController = new InstitutionController();
            institutionController.RegisterInstitution(institutionsModel);

            //Chama o EventHandler após tentar realizar o registro
            OnInstitutionRegistered();
        }

        //Chamada do EventHandler depois de clicar no botão de Registrar, permitindo que outras funções de outras telas sejam chamadas
        protected virtual void OnInstitutionRegistered()
        {
            InstitutionRegistered?.Invoke(this, EventArgs.Empty);
        }
    }
}
