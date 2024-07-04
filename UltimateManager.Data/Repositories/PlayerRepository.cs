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
                .Include(p => p.PlayerAttributes)
                .Include(p => p.Team)
                .Include(p => p.PlayerPositions)
                .ToListAsync();
        }

        public async Task SavePlayerAsync(Player player)
        {
            if (player.Id == 0)
            {
                _context.Players.Add(player);
            }
            else
            {
                _context.Players.Update(player);
            }
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

        public static int? CalculateOverall(Player player)
        {
            if (player == null)
            {
                return null;
            }
            bool isGoalkeeper = player.PlayerPositions.Any(pp => pp.PositionType == "Goalkeeper");
            if (isGoalkeeper && player.PlayerAttributes != null && player.PlayerAttributes.Goalkeeping.HasValue)
            {
                return player.PlayerAttributes.Goalkeeping;
            }
            else
            {
                return
                    ((player.PlayerAttributes?.Defending ?? 0) +
                    (player.PlayerAttributes?.Attacking ?? 0) +
                    (player.PlayerAttributes?.Speed ?? 0) +
                    (player.PlayerAttributes?.Passing ?? 0) +
                    (player.PlayerAttributes?.Shooting ?? 0) +
                    (player.PlayerAttributes?.Intelligence ?? 0) +
                    (player.PlayerAttributes?.Physical ?? 0))
                    / 7;
            }
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
