using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_ludico.Models
{
    public class BoardGamesModel
    {        
        // Propriedades
        public int id { get; set; }
        public string description { get; set; }
        public int min_players { get; set; }
        public int max_players { get; set; }
        public int game_time { get; set; }
        public int year { get; set; }
        public List<BoardGamesNamesModel> names { get; set; }
        public List<BoardGamesBarCodesModel> codes { get; set; }

        public BoardGamesModel() { }
    }
}
