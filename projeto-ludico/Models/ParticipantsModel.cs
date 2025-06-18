namespace projeto_ludico.Models
{
    public class ParticipantsModel
    {        
        // Propriedades
        public int Id { get; set; }
        public int id_institution { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }
        public string code { get; set; }

        public ParticipantsModel() { }
    }
}
