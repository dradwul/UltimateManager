namespace UltimateManager.Domain.Models
{
	public class Match
	{
		public int Id { get; set; }
		public int HomeTeamId { get; set; }
		public Team HomeTeam { get; set; }
		public int AwayTeamId { get; set; }
		public Team AwayTeam { get; set; }
		public MatchStats? HomeTeamStats { get; set; }
		public MatchStats? AwayTeamStats { get; set; }
		public DateTime? MatchDate { get; set; }
	}
}
