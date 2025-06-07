using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_ludico.Models
{
    public class EscapeRoomsModel
    {        
        // Propriedades
        public int Id { get; set; }
        public int id_event { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public EscapeRoomsModel() { }
    }
}
