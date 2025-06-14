using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_ludico.Models
{
    public class ParticipantsEventsModel
    {        
        // Propriedades
        public int Id { get; set; }
        public DateTime arrived_hour { get; set; }
        public int id_event { get; set; }
        public int id_participant { get; set; }

        public ParticipantsEventsModel() { }
    }
}
