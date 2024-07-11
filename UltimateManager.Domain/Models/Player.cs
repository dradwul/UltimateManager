namespace UltimateManager.Domain.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
		public string ShirtName { get; set; }
		public string ShirtNumber { get; set; }
        public int? BirthYear { get; set; }
        public int? Overall { get; set; }
        public int? PlayerAttributesId { get; set; }
        public PlayerAttributes? PlayerAttributes { get; set; }
        public int? PlayerStatsId { get; set; }
        public PlayerStats? PlayerStats { get; set; }
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
        public ICollection<PlayerPosition>? PlayerPositions { get; set; }
    }
}
