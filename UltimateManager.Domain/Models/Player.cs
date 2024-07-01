namespace UltimateManager.Domain.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? Overall { get; set; }
        public int? PlayerAttributesId { get; set; }
        public PlayerAttributes? PlayerAttributes { get; set; }
        public int? PlayerStatsId { get; set; }
        public PlayerStats? PlayerStats { get; set; }
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
