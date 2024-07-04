using Microsoft.EntityFrameworkCore;
using UltimateManager.Domain.Models;

namespace UltimateManager.Data
{
    public class UltimateManagerDbContext : DbContext
    {
        public UltimateManagerDbContext(DbContextOptions dbContextOptions) 
            : base(dbContextOptions) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerPosition> PlayerPositions { get; set; }
        public DbSet<PlayerAttributes> PlayerAttributes { get; set; }
        public DbSet<PlayerStats> PlayerStats { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamStats> TeamStats { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasKey(p => p.Id);
            modelBuilder.Entity<PlayerAttributes>().HasKey(pa => pa.Id);
            modelBuilder.Entity<PlayerStats>().HasKey(ps => ps.Id);
            modelBuilder.Entity<Team>().HasKey(t => t.Id);
            modelBuilder.Entity<TeamStats>().HasKey(ts => ts.Id);
            modelBuilder.Entity<Coach>().HasKey(c => c.Id);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.PlayerAttributes)
                .WithOne()
                .HasForeignKey<Player>(p => p.PlayerAttributesId)
                .HasPrincipalKey<PlayerAttributes>(pa => pa.Id);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.PlayerStats)
                .WithOne()
                .HasForeignKey<Player>(p => p.PlayerStatsId)
                .HasPrincipalKey<PlayerStats>(ps => ps.Id);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.TeamStats)
                .WithOne()
                .HasForeignKey<Team>(t => t.TeamStatsId)
                .HasPrincipalKey<TeamStats>(ts => ts.Id);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Coach)
                .WithOne(c => c.Team)
                .HasForeignKey<Team>(t => t.CoachId)
                .HasPrincipalKey<Coach>(c => c.Id);

            modelBuilder.Entity<PlayerPosition>()
                .HasMany(pp => pp.Players)
                .WithMany(p => p.PlayerPositions)
                .UsingEntity<Dictionary<string, object>>(
                "PlayerPlayerPosition",
                r => r.HasOne<Player>().WithMany().HasForeignKey("PlayerId"),
                l => l.HasOne<PlayerPosition>().WithMany().HasForeignKey("PlayerPositionId"),
                je =>
                {
                    je.HasKey("PlayerId", "PlayerPositionId");
                });

            modelBuilder.Entity<PlayerPosition>().HasData(
                new PlayerPosition { Id = 1, PositionType = "Goalkeeper", PositionSpecified = "Goal Keeper"},
                new PlayerPosition { Id = 2, PositionType = "Defender", PositionSpecified = "Center Back" },
                new PlayerPosition { Id = 3, PositionType = "Defender", PositionSpecified = "Right Back" },
                new PlayerPosition { Id = 4, PositionType = "Defender", PositionSpecified = "Left Back" },
                new PlayerPosition { Id = 5, PositionType = "Midfielder", PositionSpecified = "Central Midfielder" },
                new PlayerPosition { Id = 6, PositionType = "Midfielder", PositionSpecified = "Central Defending Midfielder" },
                new PlayerPosition { Id = 7, PositionType = "Midfielder", PositionSpecified = "Central Attacking Midfielder" },
                new PlayerPosition { Id = 8, PositionType = "Midfielder", PositionSpecified = "Right Midfielder" },
                new PlayerPosition { Id = 9, PositionType = "Midfielder", PositionSpecified = "Left Midfielder" },
                new PlayerPosition { Id = 10, PositionType = "Forward", PositionSpecified = "Striker" },
                new PlayerPosition { Id = 11, PositionType = "Forward", PositionSpecified = "Right Winger" },
                new PlayerPosition { Id = 12, PositionType = "Forward", PositionSpecified = "Left Winger" }
            );
        }
    }
}
