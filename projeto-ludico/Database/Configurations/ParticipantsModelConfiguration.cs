using System.Data.Entity.ModelConfiguration;
using projeto_ludico.Models;

public class ParticipantsModelConfiguration : EntityTypeConfiguration<ParticipantsModel>
{
    public ParticipantsModelConfiguration()
    {
        ToTable("participants");

        HasKey(p => p.Id);

        Property(p => p.id_institution)
            .IsOptional();

        Property(p => p.name)
            .IsRequired()
            .HasMaxLength(255);

        Property(p => p.email)
            .IsOptional()
            .HasMaxLength(255);

        Property(p => p.cpf)
            .IsOptional()
            .HasMaxLength(20);

        Property(p => p.code)
            .IsOptional()
            .HasMaxLength(50);
    }
}
