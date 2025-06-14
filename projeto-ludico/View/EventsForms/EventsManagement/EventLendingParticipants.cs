using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_ludico.View.EventsForms.EventsManagement
{
    public partial class EventLendingParticipants : Form
    {
        public int id_event;
        public EventLendingParticipants(int id_event) {
            this.id_event = id_event;
            InitializeComponent();
        }
    }
}
