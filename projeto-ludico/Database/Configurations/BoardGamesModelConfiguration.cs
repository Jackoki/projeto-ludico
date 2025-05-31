using System.Data.Entity.ModelConfiguration;
using projeto_ludico.Models;

public class BoardGamesModelConfiguration : EntityTypeConfiguration<BoardGamesModel>
{
    public BoardGamesModelConfiguration()
    {
        ToTable("board_games");
        HasKey(e => e.id);
        Property(e => e.description)
            .HasMaxLength(550);

        HasMany(e => e.names)
            .WithRequired()
            .HasForeignKey(n => n.id_board_game)
            .WillCascadeOnDelete(true);

        HasMany(e => e.codes)
            .WithRequired()
            .HasForeignKey(n => n.id_board_game)
            .WillCascadeOnDelete(true);
    }
}
