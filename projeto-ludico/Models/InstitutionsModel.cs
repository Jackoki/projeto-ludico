using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using projeto_ludico.Database;

namespace projeto_ludico.Models
{
    public class InstitutionsModel
    {
        // Propriedades
        public int Id { get; set; }
        public string Name { get; set; }

        public InstitutionsModel() { }
    }
}
