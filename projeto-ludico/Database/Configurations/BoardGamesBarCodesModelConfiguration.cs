using System.Data.Entity.ModelConfiguration;
using System.Reflection;
using projeto_ludico.Models;

public class BoardGamesBarCodesModelConfiguration : EntityTypeConfiguration<BoardGamesBarCodesModel>
{
    public BoardGamesBarCodesModelConfiguration()
    {
        ToTable("board_games_bar_codes");
        HasKey(e => e.id);
        Property(e => e.bar_code)
               .IsRequired()
               .HasMaxLength(255);
    }
}
