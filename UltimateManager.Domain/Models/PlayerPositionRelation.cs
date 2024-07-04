using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateManager.Domain.Models
{
	public class PlayerPositionRelation
	{
		public int PlayerId { get;set; }
		public Player Player { get;set; }
		public int PlayerPositionId { get;set; }
		public PlayerPosition PlayerPosition { get;set; }
	}
}
