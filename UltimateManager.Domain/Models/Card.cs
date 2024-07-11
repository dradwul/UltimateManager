namespace UltimateManager.Domain.Models
{
	public class Card
	{
		public int Id { get; set; }
		public int PlayerId { get; set; }
		public Player Player { get; set; }
		public int MatchStatsId { get; set; }
		public MatchStats MatchStats { get; set; }
		public CardType Type { get; set; }
		public int Minute { get; set; }
	}
}
