using System.Collections.Generic;

namespace projeto_ludico.Models
{
    public class ListModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int EventId { get; set; }
        public EventsModel Event { get; set; }
        public List<BoardGamesListModel> games { get; set; }

        public ListModel()
        {
            games = new List<BoardGamesListModel>();
            Event = new EventsModel();
        }

    }
}
