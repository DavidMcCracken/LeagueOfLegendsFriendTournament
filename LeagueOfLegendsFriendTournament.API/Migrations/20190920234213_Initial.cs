using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueOfLegendsFriendTournament.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalted = table.Column<byte[]>(nullable: true),
                    TournamentsWon = table.Column<int>(nullable: false),
                    TournamentsLost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "GameDatas",
                columns: table => new
                {
                    GameDataId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(nullable: false),
                    TournamentID = table.Column<int>(nullable: false),
                    Win = table.Column<bool>(nullable: false),
                    Kills = table.Column<int>(nullable: false),
                    Deaths = table.Column<int>(nullable: false),
                    Assists = table.Column<float>(nullable: false),
                    LongestTimeSpentLiving = table.Column<int>(nullable: false),
                    KillingSprees = table.Column<int>(nullable: false),
                    GoldEarned = table.Column<int>(nullable: false),
                    DotalDamageDealt = table.Column<int>(nullable: false),
                    VisionScore = table.Column<int>(nullable: false),
                    Champion = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDatas", x => x.GameDataId);
                    table.ForeignKey(
                        name: "FK_GameDatas_Tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameDatas_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TournamentUsers",
                columns: table => new
                {
                    TournamentUserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Wins = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    TournamentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentUsers", x => x.TournamentUserId);
                    table.ForeignKey(
                        name: "FK_TournamentUsers_Tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentUsers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameDatas_TournamentID",
                table: "GameDatas",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_GameDatas_UserID",
                table: "GameDatas",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentUsers_TournamentID",
                table: "TournamentUsers",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentUsers_UserID",
                table: "TournamentUsers",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameDatas");

            migrationBuilder.DropTable(
                name: "TournamentUsers");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
