using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_ludico.Database;
using projeto_ludico.View;

namespace projeto_ludico
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        public void loadScreen<T>() where T : Form, new()
        {
            T form = new T();

            form.Show();
        }

        private void institutionsMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseConnection.GetConnection();
            loadScreen<Institutions>();
        }
    }
}
