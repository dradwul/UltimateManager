namespace UltimateManager.Domain.Models
{
    public class Coach
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Rating { get; set; }
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
