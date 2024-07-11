using Microsoft.EntityFrameworkCore;
using UltimateManager.Domain.Models;

namespace UltimateManager.Data.Repositories
{
	public class MatchRepository
	{
		private readonly UltimateManagerDbContext _context;
		public MatchRepository(UltimateManagerDbContext context)
		{
			_context = context;
		}

		public async Task<Match> GetMatchByIdAsync(int id)
		{
			return await _context.Matches
				.Include(m => m.HomeTeam)
				.Include(m => m.AwayTeam)
				.Include(m => m.HomeTeamStats)
				.Include(m => m.AwayTeamStats)
				.FirstOrDefaultAsync(m => m.Id == id);
		}

		public async Task<IEnumerable<Match>> GetAllMatchesAsync()
		{
			return await _context.Matches
				.Include(m => m.HomeTeam)
				.Include(m => m.AwayTeam)
				.Include(m => m.HomeTeamStats)
				.Include(m => m.AwayTeamStats)
				.ToListAsync();
		}

		public async Task AddMatchAsync(Match match)
		{
			_context.Matches.Add(match);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateMatchAsync(Match match)
		{
			_context.Matches.Update(match);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteMatchAsync(int id)
		{
			var match = await GetMatchByIdAsync(id);
			if(match != null)
			{
				_context.Matches.Remove(match);
				await _context.SaveChangesAsync();
			}
		}
	}
}
