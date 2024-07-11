﻿namespace UltimateManager.Domain.Models
{
	public class Goal
	{
		public int Id { get; set; }
		public int PlayerId { get; set; }
		public Player Player { get; set; }
		public int MatchStatsId { get; set; }
		public MatchStats MatchStats { get; set; }
		public int Minute { get; set; }
	}
}
