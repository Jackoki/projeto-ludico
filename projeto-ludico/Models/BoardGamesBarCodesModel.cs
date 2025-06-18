namespace projeto_ludico.Models
{
    public class BoardGamesBarCodesModel
    {        
        // Propriedades
        public int id { get; set; }
        public string bar_code { get; set; }
        public int id_board_game { get; set; }

        public BoardGamesBarCodesModel() { }
    }
}
