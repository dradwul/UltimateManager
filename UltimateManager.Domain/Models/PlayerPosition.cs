namespace UltimateManager.Domain.Models
{
    public class PlayerPosition
    {
        public int Id { get; set; }
        public string PositionType { get; set; }
        public string PositionSpecified { get; set; }
        public ICollection<Player>? Players { get;}
    }
}
