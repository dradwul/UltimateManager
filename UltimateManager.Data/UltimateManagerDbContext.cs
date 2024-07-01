using Microsoft.EntityFrameworkCore;
using UltimateManager.Domain.Models;

namespace UltimateManager.Data
{
    public class UltimateManagerDbContext : DbContext
    {
        public UltimateManagerDbContext(DbContextOptions dbContextOptions) 
            : base(dbContextOptions) { }

        public DbSet<Player> Players { get; set; }
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
        }
    }
}
