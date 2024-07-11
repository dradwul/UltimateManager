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
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchStats> MatchStats { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<Team>()
                .HasOne(t => t.User)
                .WithOne(u => u.Team)
                .HasForeignKey<Team>(t => t.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Team)
                .WithOne(t => t.User)
                .HasForeignKey<User>(u => u.TeamId)
                .OnDelete(DeleteBehavior.SetNull);

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

            //Match entities
            modelBuilder.Entity<Match>().HasKey(m => m.Id);
            modelBuilder.Entity<Match>()
                .HasOne(m => m.HomeTeam)
                .WithMany()
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.AwayTeam)
                .WithMany()
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.HomeTeamStats)
                .WithOne()
                .HasForeignKey<MatchStats>(ms => ms.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.AwayTeamStats)
                .WithOne()
                .HasForeignKey<MatchStats>(ms => ms.Id)
                .OnDelete(DeleteBehavior.Cascade);

            // Konfiguration för MatchStats entiteter
            modelBuilder.Entity<MatchStats>().HasKey(ms => ms.Id);
            modelBuilder.Entity<MatchStats>()
                .HasMany(ms => ms.TeamSquad)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "MatchStatsPlayer",
                    r => r.HasOne<Player>().WithMany().HasForeignKey("PlayerId"),
                    l => l.HasOne<MatchStats>().WithMany().HasForeignKey("MatchStatsId"),
                    je =>
                    {
                        je.HasKey("PlayerId", "MatchStatsId");
                    });

            modelBuilder.Entity<MatchStats>()
                .HasMany(ms => ms.TeamBench)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "MatchStatsBenchPlayer",
                    r => r.HasOne<Player>().WithMany().HasForeignKey("PlayerId"),
                    l => l.HasOne<MatchStats>().WithMany().HasForeignKey("MatchStatsId"),
                    je =>
                    {
                        je.HasKey("PlayerId", "MatchStatsId");
                    });

            modelBuilder.Entity<Goal>().HasKey(g => g.Id);
            modelBuilder.Entity<Goal>()
                .HasOne(g => g.Player)
                .WithMany()
                .HasForeignKey(g => g.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Goal>()
                .HasOne(g => g.MatchStats)
                .WithMany(ms => ms.Goals)
                .HasForeignKey(g => g.MatchStatsId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Card>().HasKey(c => c.Id);
            modelBuilder.Entity<Card>()
                .HasOne(c => c.Player)
                .WithMany()
                .HasForeignKey(c => c.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Card>()
                .HasOne(c => c.MatchStats)
                .WithMany(ms => ms.Cards)
                .HasForeignKey(c => c.MatchStatsId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Card>()
                .Property(c => c.Type)
                .HasConversion<string>();

		}
    }
}
