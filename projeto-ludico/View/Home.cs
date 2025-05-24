using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_ludico.View;
using projeto_ludico.View.BoardGamesForms;
using projeto_ludico.View.InstitutionsForms;
using projeto_ludico.View.ParticipantsForms;

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
            loadScreen<Institutions>();
        }

        private void participantsMenuItem_Click(object sender, EventArgs e)
        {
            loadScreen<Participants>();
        }

        private void gamesMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void jogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadScreen<BoardGames>();
        }
    }
}
