namespace UltimateManager.Domain.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PrimaryColor { get; set; }
        public string? SecondaryColor { get; set; }
        public int? Overall { get; set; }
        public int? CoachId { get; set; }
        public Coach? Coach { get; set; }
        public int? TeamStatsId { get; set; }
        public TeamStats? TeamStats { get; set; }
        public ICollection<Player>? Players { get; set; }
    }
}
