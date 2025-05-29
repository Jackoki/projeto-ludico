using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_ludico.Models
{
    internal class BoardGamesNamesModel
    {        
        // Propriedades
        public int id { get; set; }
        public string name { get; set; }
        public bool is_principal { get; set; }
        public int id_board_game { get; set; }

        public BoardGamesNamesModel() { }
    }
}
