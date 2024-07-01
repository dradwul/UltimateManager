namespace SimBox.Domain.Models
{
    public class TeamStats
    {
        public int Id { get; set; }
        public int? Wins { get; set; }
        public int? Draws { get; set; }
        public int? Losses { get; set; }
        public int? Goals { get; set; }
        public int? YellowCards { get; set; }
        public int? RedCards { get; set; }
    }
}