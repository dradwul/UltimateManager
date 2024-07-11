﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UltimateManager.Data;

#nullable disable

namespace UltimateManager.Data.Migrations
{
    [DbContext(typeof(UltimateManagerDbContext))]
    partial class UltimateManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MatchStatsBenchPlayer", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("MatchStatsId")
                        .HasColumnType("integer");

                    b.HasKey("PlayerId", "MatchStatsId");

                    b.HasIndex("MatchStatsId");

                    b.ToTable("MatchStatsBenchPlayer");
                });

            modelBuilder.Entity("MatchStatsPlayer", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("MatchStatsId")
                        .HasColumnType("integer");

                    b.HasKey("PlayerId", "MatchStatsId");

                    b.HasIndex("MatchStatsId");

                    b.ToTable("MatchStatsPlayer");
                });

            modelBuilder.Entity("PlayerPlayerPosition", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerPositionId")
                        .HasColumnType("integer");

                    b.HasKey("PlayerId", "PlayerPositionId");

                    b.HasIndex("PlayerPositionId");

                    b.ToTable("PlayerPlayerPosition");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MatchStatsId")
                        .HasColumnType("integer");

                    b.Property<int>("Minute")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MatchStatsId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("Rating")
                        .HasColumnType("integer");

                    b.Property<int?>("TeamId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MatchStatsId")
                        .HasColumnType("integer");

                    b.Property<int>("Minute")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MatchStatsId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AwayTeamId")
                        .HasColumnType("integer");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("integer");

                    b.Property<int?>("HomeTeamStatsId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("MatchDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("HomeTeamStatsId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.MatchStats", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("MatchStats");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BirthYear")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<int?>("Overall")
                        .HasColumnType("integer");

                    b.Property<int?>("PlayerAttributesId")
                        .HasColumnType("integer");

                    b.Property<int?>("PlayerStatsId")
                        .HasColumnType("integer");

                    b.Property<string>("ShirtName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShirtNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TeamId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlayerAttributesId")
                        .IsUnique();

                    b.HasIndex("PlayerStatsId")
                        .IsUnique();

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.PlayerAttributes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Attacking")
                        .HasColumnType("integer");

                    b.Property<int>("Defending")
                        .HasColumnType("integer");

                    b.Property<int?>("Goalkeeping")
                        .HasColumnType("integer");

                    b.Property<int>("Intelligence")
                        .HasColumnType("integer");

                    b.Property<bool?>("IsInjured")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsSuspended")
                        .HasColumnType("boolean");

                    b.Property<int>("Passing")
                        .HasColumnType("integer");

                    b.Property<int>("Physical")
                        .HasColumnType("integer");

                    b.Property<int>("Shooting")
                        .HasColumnType("integer");

                    b.Property<int>("Speed")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("PlayerAttributes");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.PlayerPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PositionSpecified")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PositionType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PlayerPositions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PositionSpecified = "Goal Keeper",
                            PositionType = "Goalkeeper"
                        },
                        new
                        {
                            Id = 2,
                            PositionSpecified = "Center Back",
                            PositionType = "Defender"
                        },
                        new
                        {
                            Id = 3,
                            PositionSpecified = "Right Back",
                            PositionType = "Defender"
                        },
                        new
                        {
                            Id = 4,
                            PositionSpecified = "Left Back",
                            PositionType = "Defender"
                        },
                        new
                        {
                            Id = 5,
                            PositionSpecified = "Central Midfielder",
                            PositionType = "Midfielder"
                        },
                        new
                        {
                            Id = 6,
                            PositionSpecified = "Central Defending Midfielder",
                            PositionType = "Midfielder"
                        },
                        new
                        {
                            Id = 7,
                            PositionSpecified = "Central Attacking Midfielder",
                            PositionType = "Midfielder"
                        },
                        new
                        {
                            Id = 8,
                            PositionSpecified = "Right Midfielder",
                            PositionType = "Midfielder"
                        },
                        new
                        {
                            Id = 9,
                            PositionSpecified = "Left Midfielder",
                            PositionType = "Midfielder"
                        },
                        new
                        {
                            Id = 10,
                            PositionSpecified = "Striker",
                            PositionType = "Forward"
                        },
                        new
                        {
                            Id = 11,
                            PositionSpecified = "Right Winger",
                            PositionType = "Forward"
                        },
                        new
                        {
                            Id = 12,
                            PositionSpecified = "Left Winger",
                            PositionType = "Forward"
                        });
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.PlayerStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Assists")
                        .HasColumnType("integer");

                    b.Property<int?>("Draws")
                        .HasColumnType("integer");

                    b.Property<int?>("Goals")
                        .HasColumnType("integer");

                    b.Property<int?>("Losses")
                        .HasColumnType("integer");

                    b.Property<int?>("RedCards")
                        .HasColumnType("integer");

                    b.Property<int?>("Wins")
                        .HasColumnType("integer");

                    b.Property<int?>("YellowCards")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("PlayerStats");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CoachId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Overall")
                        .HasColumnType("integer");

                    b.Property<string>("PrimaryColor")
                        .HasColumnType("text");

                    b.Property<string>("SecondaryColor")
                        .HasColumnType("text");

                    b.Property<int?>("TeamStatsId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CoachId")
                        .IsUnique();

                    b.HasIndex("TeamStatsId")
                        .IsUnique();

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.TeamStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Draws")
                        .HasColumnType("integer");

                    b.Property<int?>("Goals")
                        .HasColumnType("integer");

                    b.Property<int?>("Losses")
                        .HasColumnType("integer");

                    b.Property<int?>("RedCards")
                        .HasColumnType("integer");

                    b.Property<int?>("Wins")
                        .HasColumnType("integer");

                    b.Property<int?>("YellowCards")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("TeamStats");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TeamId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TeamId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MatchStatsBenchPlayer", b =>
                {
                    b.HasOne("UltimateManager.Domain.Models.MatchStats", null)
                        .WithMany()
                        .HasForeignKey("MatchStatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UltimateManager.Domain.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MatchStatsPlayer", b =>
                {
                    b.HasOne("UltimateManager.Domain.Models.MatchStats", null)
                        .WithMany()
                        .HasForeignKey("MatchStatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UltimateManager.Domain.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlayerPlayerPosition", b =>
                {
                    b.HasOne("UltimateManager.Domain.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UltimateManager.Domain.Models.PlayerPosition", null)
                        .WithMany()
                        .HasForeignKey("PlayerPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.Card", b =>
                {
                    b.HasOne("UltimateManager.Domain.Models.MatchStats", "MatchStats")
                        .WithMany("Cards")
                        .HasForeignKey("MatchStatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UltimateManager.Domain.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MatchStats");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.Goal", b =>
                {
                    b.HasOne("UltimateManager.Domain.Models.MatchStats", "MatchStats")
                        .WithMany("Goals")
                        .HasForeignKey("MatchStatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UltimateManager.Domain.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MatchStats");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.Match", b =>
                {
                    b.HasOne("UltimateManager.Domain.Models.Team", "AwayTeam")
                        .WithMany()
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UltimateManager.Domain.Models.Team", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UltimateManager.Domain.Models.MatchStats", "HomeTeamStats")
                        .WithMany()
                        .HasForeignKey("HomeTeamStatsId");

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");

                    b.Navigation("HomeTeamStats");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.MatchStats", b =>
                {
                    b.HasOne("UltimateManager.Domain.Models.Match", null)
                        .WithOne("AwayTeamStats")
                        .HasForeignKey("UltimateManager.Domain.Models.MatchStats", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.Player", b =>
                {
                    b.HasOne("UltimateManager.Domain.Models.PlayerAttributes", "PlayerAttributes")
                        .WithOne()
                        .HasForeignKey("UltimateManager.Domain.Models.Player", "PlayerAttributesId");

                    b.HasOne("UltimateManager.Domain.Models.PlayerStats", "PlayerStats")
                        .WithOne()
                        .HasForeignKey("UltimateManager.Domain.Models.Player", "PlayerStatsId");

                    b.HasOne("UltimateManager.Domain.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.Navigation("PlayerAttributes");

                    b.Navigation("PlayerStats");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.Team", b =>
                {
                    b.HasOne("UltimateManager.Domain.Models.Coach", "Coach")
                        .WithOne("Team")
                        .HasForeignKey("UltimateManager.Domain.Models.Team", "CoachId");

                    b.HasOne("UltimateManager.Domain.Models.TeamStats", "TeamStats")
                        .WithOne()
                        .HasForeignKey("UltimateManager.Domain.Models.Team", "TeamStatsId");

                    b.Navigation("Coach");

                    b.Navigation("TeamStats");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.User", b =>
                {
                    b.HasOne("UltimateManager.Domain.Models.Team", "Team")
                        .WithOne("User")
                        .HasForeignKey("UltimateManager.Domain.Models.User", "TeamId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Team");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.Coach", b =>
                {
                    b.Navigation("Team");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.Match", b =>
                {
                    b.Navigation("AwayTeamStats");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.MatchStats", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Goals");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.Team", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
