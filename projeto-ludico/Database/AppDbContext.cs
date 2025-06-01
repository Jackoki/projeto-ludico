using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using projeto_ludico.Models;

public class AppDbContext : DbContext
{
    public AppDbContext() : base(CreateConnection(), true) { }

    private static DbConnection CreateConnection()
    {
        string connectionString = CreateConnectionString();
        var connection = new SQLiteConnection(connectionString);
        return connection;
    }

    private static string CreateConnectionString()
    {
        string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
        string databasePath = Path.Combine(directoryPath, @"..\..\Database\Database.db");
        databasePath = Path.GetFullPath(databasePath);
        return $"Data Source={databasePath};Version=3;";
    }

    public DbSet<BoardGamesModel> BoardGames { get; set; }
    public DbSet<BoardGamesNamesModel> BoardGamesNames { get; set; }
    public DbSet<BoardGamesBarCodesModel> BoardGamesBarCodes { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.Add(new BoardGamesModelConfiguration());
        modelBuilder.Configurations.Add(new BoardGamesNamesModelConfiguration());
        modelBuilder.Configurations.Add(new BoardGamesBarCodesModelConfiguration());
    }
}
