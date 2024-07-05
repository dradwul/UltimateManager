using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateManager.Domain.Models;

namespace UltimateManager.Data.Repositories
{
    public class TeamRepository
    {
        private readonly UltimateManagerDbContext _context;
        public TeamRepository(UltimateManagerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Team>> GetAllTeamsAsync()
        {
            return await _context.Teams
                .Include(t => t.Players)
                .ToListAsync();
        }

        public async Task<Team> GetTeamByIdAsync(int teamId)
        {
            return await _context.Teams
                .Include(t => t.Players)
                .FirstOrDefaultAsync(t => t.Id == teamId);
        }

        public async Task SaveTeamAsync(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
        }
		public async Task DeleteTeamAsync(Team team)
		{
			_context.Remove(team);
			await _context.SaveChangesAsync();
		}

        public async Task CalculateAllTeamsOverallAsync()
        {
            var teams = await _context.Teams
                .Include(t => t.Players)
                .ToListAsync();

            foreach(var team in teams)
            {
                foreach(var player in team.Players)
                {
                    if(player.Overall != null)
                    {
                        team.Overall += player.Overall;
					}
                }
                team.Overall; /// HÄR SKA DET DIVIDERAS MED ANTAL SPELARE TYP
            }

            _context.Teams.UpdateRange(teams);
            await _context.SaveChangesAsync();
        }
	}
}
