using System.Data.Entity.ModelConfiguration;

public class BoardGamesListModelConfiguration : EntityTypeConfiguration<BoardGamesListModel>
{
    public BoardGamesListModelConfiguration()
    {
        ToTable("board_games_list");
        HasKey(e => e.id);

        HasRequired(e => e.List)
            .WithMany(l => l.games)
            .HasForeignKey(e => e.id_list)
            .WillCascadeOnDelete(true);

        HasRequired(e => e.boardGames)
            .WithMany()
            .HasForeignKey(e => e.id_board_game);
    }
}
