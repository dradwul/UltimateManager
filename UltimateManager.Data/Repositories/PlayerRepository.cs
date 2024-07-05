﻿using Microsoft.EntityFrameworkCore;
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
            player.Overall = CalculateOverall(player);

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
                List<int?> attributes = new List<int?>
                {
                    player.PlayerAttributes?.Defending,
                    player.PlayerAttributes?.Attacking,
                    player.PlayerAttributes?.Speed,
                    player.PlayerAttributes?.Passing,
                    player.PlayerAttributes?.Shooting,
                    player.PlayerAttributes?.Intelligence,
                    player.PlayerAttributes?.Physical
                };
                attributes.RemoveAll(att => !att.HasValue);
                attributes.Sort((a,b) => b.Value.CompareTo(a.Value));
                var topFiveAttributes = attributes.Take(5);
                int total = (int)topFiveAttributes.Sum();
                int overall = total / 5;
                if(attributes.Count < 5)
                {
                    overall = 0;
                }
                return overall;
            }
        }

		public async Task<List<PlayerPosition>> GetAllPositionsAsync()
		{
			return await _context.PlayerPositions.ToListAsync();
		}

        public static string PositionShortener(Player player)
        {
            var positionMappings = new Dictionary<string, string>
            {
                {"Goal Keeper", "GK" },
                {"Center Back", "CB" },
                {"Right Back", "RB" },
                {"Left Back", "LB" },
                {"Central Midfielder", "CM" },
                {"Central Defending Midfielder", "CDM" },
                {"Central Attacking Midfielder", "CAM" },
                {"Right Midfielder", "RM" },
                {"Left Midfielder", "LM" },
                {"Striker", "ST" },
                {"Right Winger", "RW" },
                {"Left Winger", "LW" }
            };

            if(player.PlayerPositions == null || !player.PlayerPositions.Any())
            {
                return string.Empty;
            }

            var shortNames = player.PlayerPositions
                .Select(position => positionMappings.TryGetValue(position.PositionSpecified, out var shortName) ? shortName : position.PositionSpecified)
                .ToList();
            return string.Join(", ", shortNames);
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

        public async Task UpdateAllPlayersOverallAsync()
        {
            var players = await _context.Players
                .Include(p => p.PlayerAttributes)
                .Include(p => p.PlayerPositions)
                .ToListAsync();

            foreach (var player in players)
            {
                player.Overall = CalculateOverall(player);
            }

            _context.Players.UpdateRange(players);
            await _context.SaveChangesAsync();
        }

    }
}
