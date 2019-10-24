﻿// <auto-generated />
using System;
using LeagueOfLegendsFriendTournament.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LeagueOfLegendsFriendTournament.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("LeagueOfLegendsFriendTournament.API.Models.GameData", b =>
                {
                    b.Property<int>("GameDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Assists");

                    b.Property<string>("Champion");

                    b.Property<int>("Deaths");

                    b.Property<int>("GoldEarned");

                    b.Property<int>("KillingSprees");

                    b.Property<int>("Kills");

                    b.Property<int>("LongestTimeSpentLiving");

                    b.Property<string>("Role");

                    b.Property<int>("TournamentID");

                    b.Property<int>("UserID");

                    b.Property<int>("VisionScore");

                    b.Property<bool>("Win");

                    b.Property<int>("totalDamageDealt");

                    b.HasKey("GameDataId");

                    b.HasIndex("TournamentID");

                    b.HasIndex("UserID");

                    b.ToTable("GameDatas");
                });

            modelBuilder.Entity("LeagueOfLegendsFriendTournament.API.Models.Tournament", b =>
                {
                    b.Property<int>("TournamentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Active");

                    b.Property<int>("CreatorOfTournament");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("GameType");

                    b.Property<int>("PlayerCount");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("TournamentName");

                    b.HasKey("TournamentId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("LeagueOfLegendsFriendTournament.API.Models.TournamentUser", b =>
                {
                    b.Property<int>("TournamentUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TournamentID");

                    b.Property<int>("UserID");

                    b.Property<int>("Wins");

                    b.HasKey("TournamentUserId");

                    b.HasIndex("TournamentID");

                    b.HasIndex("UserID");

                    b.ToTable("TournamentUsers");
                });

            modelBuilder.Entity("LeagueOfLegendsFriendTournament.API.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalted");

                    b.Property<int>("TournamentsLost");

                    b.Property<int>("TournamentsWon");

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LeagueOfLegendsFriendTournament.API.Models.GameData", b =>
                {
                    b.HasOne("LeagueOfLegendsFriendTournament.API.Models.Tournament", "Tournament")
                        .WithMany("GameData")
                        .HasForeignKey("TournamentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LeagueOfLegendsFriendTournament.API.Models.User", "User")
                        .WithMany("GameData")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LeagueOfLegendsFriendTournament.API.Models.TournamentUser", b =>
                {
                    b.HasOne("LeagueOfLegendsFriendTournament.API.Models.Tournament", "Tournament")
                        .WithMany("TournamentUser")
                        .HasForeignKey("TournamentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LeagueOfLegendsFriendTournament.API.Models.User", "User")
                        .WithMany("TournamentUser")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
