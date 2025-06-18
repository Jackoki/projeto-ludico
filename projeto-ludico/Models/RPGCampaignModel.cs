namespace projeto_ludico.Models
{
    public class RPGCampaignModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int id_role_play_game { get; set; }
        public int id_event { get; set; }
        public string name_event { get; set; }
    }
}
