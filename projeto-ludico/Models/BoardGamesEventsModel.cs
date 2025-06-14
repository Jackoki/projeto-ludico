using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_ludico.Models
{
    internal class BoardGamesEventsModel
    {
        public int id { get; set; }
        public string board_games_name { get; set; }
        public string details { get; set; }
        public bool is_available { get; set; }
        public DateTime removal_time { get; set; }
        public int id_participant { get; set; }
        public int id_board_game { get; set; }
        public int id_event { get; set; }
    }
}
