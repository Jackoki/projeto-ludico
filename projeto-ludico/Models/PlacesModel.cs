using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using projeto_ludico.Database;

namespace projeto_ludico.Models
{
    public class PlacesModel
    {
        // Propriedades
        public int id { get; set; }
        public string name { get; set; }

        public PlacesModel() { }
    }
}
