using System.Data.Entity.ModelConfiguration;
using projeto_ludico.Models;

public class ParticipantsEscapeRoomModelConfiguration : EntityTypeConfiguration<ParticipantsEscapeRoomModel>
{
    public ParticipantsEscapeRoomModelConfiguration()
    {
        ToTable("participants_escape_rooms");

        HasKey(e => e.Id);

        // Mapeia as propriedades para as colunas do banco explicitamente
        Property(e => e.Id).HasColumnName("id");
        Property(e => e.id_escape_room).HasColumnName("id_escape_room");
        Property(e => e.id_participant).HasColumnName("id_participant");

        HasRequired(e => e.EscapeRoomsModel)
            .WithMany()
            .HasForeignKey(e => e.id_escape_room)
            .WillCascadeOnDelete(true);

        HasRequired(e => e.ParticipantsModel)
            .WithMany()
            .HasForeignKey(e => e.id_participant)
            .WillCascadeOnDelete(false);
    }
}
