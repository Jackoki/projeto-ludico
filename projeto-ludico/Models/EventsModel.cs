using System;

namespace projeto_ludico.Models
{
    public class EventsModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public int id_event_local { get; set; }
        public bool is_active { get; set; }
    }
}
