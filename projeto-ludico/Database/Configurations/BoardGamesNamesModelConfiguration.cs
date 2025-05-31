using System.Data.Entity.ModelConfiguration;
using System.Reflection;
using projeto_ludico.Models;

public class BoardGamesNamesModelConfiguration : EntityTypeConfiguration<BoardGamesNamesModel>
{
    public BoardGamesNamesModelConfiguration()
    {
        ToTable("board_games_names");
        HasKey(e => e.id);
        Property(e => e.name)
               .IsRequired()
               .HasMaxLength(255);
    }
}
