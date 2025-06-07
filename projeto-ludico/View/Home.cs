using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_ludico.View;
using projeto_ludico.View.BoardGamesForms;
using projeto_ludico.View.EventsForms;
using projeto_ludico.View.InstitutionsForms;
using projeto_ludico.View.ListForms;
using projeto_ludico.View.ParticipantsForms;
using projeto_ludico.View.PlacesForms;
using projeto_ludico.View.EscapeRoomsForms;
using projeto_ludico.View.RPGForms;

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

        private void locaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadScreen<Places>();
        }

        private void gamesMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void jogosToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            loadScreen<BoardGames>();
        }

        private void listaDeJogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadScreen<List>();
        }

        private void eventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadScreen<Events>();
        }
        private void escapeRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadScreen<EscapeRooms>();
        }

        private void rpgMenuItem_Click(object sender, EventArgs e)
        {
            loadScreen<RPG>();
        }
    }
}
