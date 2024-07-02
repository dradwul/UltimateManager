﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UltimateManager.Data;

#nullable disable

namespace UltimateManager.Data.Migrations
{
    [DbContext(typeof(UltimateManagerDbContext))]
    [Migration("20240702200836_ChangesToTeamEntity")]
    partial class ChangesToTeamEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UltimateManager.Domain.Models.Coach", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("Rating")
                        .HasColumnType("integer");

                    b.Property<int?>("TeamId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Overall")
                        .HasColumnType("integer");

                    b.Property<int?>("PlayerAttributesId")
                        .HasColumnType("integer");

                    b.Property<int?>("PlayerStatsId")
                        .HasColumnType("integer");

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

            modelBuilder.Entity("UltimateManager.Domain.Models.Coach", b =>
                {
                    b.Navigation("Team");
                });

            modelBuilder.Entity("UltimateManager.Domain.Models.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
