using System.Data.Entity;
using projeto_ludico.Models;

public class AppDbContext : DbContext
{
    public AppDbContext() : base("name=AppDbContext") { }

    public DbSet<BoardGamesModel> BoardGames { get; set; }
    public DbSet<BoardGamesNamesModel> BoardGamesNames { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.Add(new BoardGamesModelConfiguration());
        modelBuilder.Configurations.Add(new BoardGamesNamesModelConfiguration());
    }
}
