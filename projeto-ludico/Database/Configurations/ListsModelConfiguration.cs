using System.Data.Entity.ModelConfiguration;
using projeto_ludico.Models;

public class ListsModelConfiguration : EntityTypeConfiguration<ListModel>
{
    public ListsModelConfiguration()
    {
        ToTable("lists");
        HasKey(e => e.id);
        Property(e => e.name)
            .HasMaxLength(550);

        HasOptional(e => e.Event)
            .WithMany()
            .Map(m => m.MapKey("id_event"));

        HasMany(e => e.games)
            .WithRequired()
            .HasForeignKey(n => n.id_list)
            .WillCascadeOnDelete(true);
    }
}
