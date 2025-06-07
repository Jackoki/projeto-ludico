using projeto_ludico.Models;

public class BoardGamesListModel
{
    public int id { get; set; }
    public int id_list { get; set; }
    public ListModel List { get; set; }
    public int id_board_game { get; set; }
    public BoardGamesModel boardGames { get; set; }
}
