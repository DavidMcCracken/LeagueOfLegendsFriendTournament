using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueOfLegendsFriendTournament.API.Migrations
{
    public partial class AddedTournamentUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TournamentUsers",
                columns: table => new
                {
                    InTournamentID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(nullable: false),
                    TournamentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentUsers", x => x.InTournamentID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TournamentUsers");
        }
    }
}
