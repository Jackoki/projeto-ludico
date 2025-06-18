namespace projeto_ludico.Models
{
    public class BoardGamesNamesModel
    {        
        // Propriedades
        public int id { get; set; }
        public string name { get; set; }
        public bool is_principal { get; set; }
        public int id_board_game { get; set; }

        public BoardGamesNamesModel() { }
    }
}
