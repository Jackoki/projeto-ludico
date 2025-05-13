using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_ludico.Models
{
    internal class ParticipantsModel
    {        
        // Propriedades
        public int id { get; set; }
        public int id_institution { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public string code { get; set; }

        public ParticipantsModel() { }
    }
}
