using projeto_ludico.Models;

public class ParticipantsEscapeRoomModel
{
    public int Id { get; set; }
    public int id_escape_room { get; set; }
    public int id_participant { get; set; }

    public EscapeRoomsModel EscapeRoomsModel { get; set; }
    public ParticipantsModel ParticipantsModel { get; set; }
}