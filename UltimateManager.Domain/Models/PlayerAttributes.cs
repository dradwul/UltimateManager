namespace UltimateManager.Domain.Models
{
    public class PlayerAttributes
    {
        public int Id { get; set; }
        public int Defending { get; set; }
        public int Attacking { get; set; }
        public int Speed { get; set; }
        public int Passing { get; set; }
        public int Shooting { get; set; }
        public int Intelligence { get; set; }
        public int Physical { get; set; }
        public int? Goalkeeping { get; set; }
        public bool? IsSuspended { get; set; }
        public bool? IsInjured { get; set; }
    }
}
