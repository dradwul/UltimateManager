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
        public DbSet<PlayerPositionRelation> PlayerPositionsRelations { get; set; }
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

            modelBuilder.Entity<PlayerPositionRelation>()
                .HasKey(ppr => new { ppr.PlayerId, ppr.PlayerPositionId });

            modelBuilder.Entity<PlayerPositionRelation>()
                .HasOne(ppr => ppr.Player)
                .WithMany(p => p.PlayerPositionRelations)
                .HasForeignKey(ppr => ppr.PlayerId);

            modelBuilder.Entity<PlayerPositionRelation>()
                .HasOne(ppr => ppr.PlayerPosition)
                .WithMany(pp => pp.PlayerPositionRelations)
                .HasForeignKey(ppr => ppr.PlayerPositionId);

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

            modelBuilder.Entity<Player>()
                .HasOne(p => p.PlayerPosition)
                .WithMany()
                .HasForeignKey(p => p.PlayerPositionId);

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
        }
    }
}
