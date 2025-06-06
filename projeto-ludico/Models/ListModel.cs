using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_ludico.Models
{
    public class ListModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int id_event { get; set; }
        public List<BoardGamesList> games { get; set; }

        public ListModel()
        {
            games = new List<BoardGamesList>();
        }

    }
}
