using Microsoft.EntityFrameworkCore;
using UltimateManager.Domain.Models;

namespace UltimateManager.Data.Repositories
{
    public class PlayerRepository
    {
        private readonly UltimateManagerDbContext _context;
        public PlayerRepository(UltimateManagerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> GetAllPlayersAsync()
        {
            return await _context.Players
                .Include(p => p.Team)
                .ToListAsync();
        }

        public async Task SavePlayerAsync(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlayerAsync(Player player)
        {
            _context.Remove(player);
            await _context.SaveChangesAsync();
        }

        public static int? CalculateAge(Player player)
        {
            return DateTime.Now.Year - player.BirthYear;
        }


		public async Task<List<PlayerPosition>> GetAllPositionsAsync()
		{
			return await _context.PlayerPositions.ToListAsync();
		}

        public async Task SavePositionAsync(PlayerPosition position)
        {
            await _context.PlayerPositions.AddAsync(position);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePositionAsync(PlayerPosition position)
        {
            _context.Remove(position);
            await _context.SaveChangesAsync();
        }
	}
}
