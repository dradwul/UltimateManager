using System.ComponentModel.DataAnnotations;

namespace UltimateManager.Domain.Models
{
	public class MatchStats
	{
		public int Id { get; set; }
		public ICollection<Player>? TeamSquad { get; set; } = new List<Player>();
		public ICollection<Player>? TeamBench { get; set; } = new List<Player>();
		public ICollection<Goal>? Goals { get; set; } = new List<Goal>();
		public ICollection<Card>? Cards { get; set; } = new List<Card>();
	}
}
