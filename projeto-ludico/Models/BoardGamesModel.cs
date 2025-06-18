using System.Collections.Generic;
using System.Linq;

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

        public string MainName {
            get {
                return names?.FirstOrDefault(n => n.is_principal)?.name ?? "";
            }
        }


        public BoardGamesModel() {
            names = new List<BoardGamesNamesModel>();
            codes = new List<BoardGamesBarCodesModel>();
        }
    }
}
