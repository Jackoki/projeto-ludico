using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_ludico.Models
{
    internal class EscapeRoomsModel
    {        
        // Propriedades
        public int id { get; set; }
        public int id_event { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public EscapeRoomsModel() { }
    }
}
