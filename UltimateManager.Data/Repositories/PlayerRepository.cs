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
    }
}
