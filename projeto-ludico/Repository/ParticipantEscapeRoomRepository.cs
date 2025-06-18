using System;
using System.Collections.Generic;
using System.Linq;

namespace projeto_ludico.Repository
{
    internal class ParticipantsEscapeRoomRepository
    {
        public void AddParticipant(int id_escape_room, int id_participant)
        {
            using (var context = new AppDbContext())
            {
                // Verifica se o participante já está na sala
                bool exists = context.ParticipantsEscapeRooms
                    .Any(per => per.id_escape_room == id_escape_room && per.id_participant == id_participant);

                if (exists)
                {
                    throw new Exception("O participante já está associado ao Escape Room.");
                }

                // Cria a relação usando só os IDs, sem buscar entidades completas
                var participantEscapeRoom = new ParticipantsEscapeRoomModel
                {
                    id_escape_room = id_escape_room,
                    id_participant = id_participant
                };

                context.ParticipantsEscapeRooms.Add(participantEscapeRoom);
                context.SaveChanges();
            }
        }


        public void RemoveParticipant(int id_escape_room, int id_participant)
        {
            using (var context = new AppDbContext())
            {
                // Localiza a relação a ser removida
                var entity = context.ParticipantsEscapeRooms
                    .FirstOrDefault(per => per.id_escape_room == id_escape_room && per.id_participant == id_participant);


                if (entity != null)
                {
                    context.ParticipantsEscapeRooms.Remove(entity);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Participante não encontrado no Escape Room.");
                }
            }
        }

        public List<(int id, string name)> GetParticipantsById(int id_escape_room)
        {
            using (var context = new AppDbContext())
            {
                var query = from per in context.ParticipantsEscapeRooms
                            join p in context.Participants on per.id_participant equals p.Id
                            where per.id_escape_room == id_escape_room
                            select new
                            {
                                p.Id,
                                p.name
                            };

                var result = query
                    .AsEnumerable()
                    .Select(x => (x.Id, x.name))
                    .ToList();

                return result;
            }
        }







    }
}
