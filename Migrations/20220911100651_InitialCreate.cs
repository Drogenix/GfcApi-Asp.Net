using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gfc.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fighter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Win = table.Column<int>(type: "int", nullable: false),
                    Lose = table.Column<int>(type: "int", nullable: false),
                    Draw = table.Column<int>(type: "int", nullable: false),
                    Winstreak = table.Column<int>(type: "int", nullable: false),
                    Byknockout = table.Column<int>(type: "int", nullable: false),
                    FirstRoundWins = table.Column<int>(type: "int", nullable: false),
                    TotalHits = table.Column<int>(type: "int", nullable: false),
                    AccurateHits = table.Column<int>(type: "int", nullable: false),
                    TotalTakedowns = table.Column<int>(type: "int", nullable: false),
                    AccurateTakedowns = table.Column<int>(type: "int", nullable: false),
                    WinByKoTko = table.Column<int>(type: "int", nullable: false),
                    WInByDecision = table.Column<int>(type: "int", nullable: false),
                    WinBySubmission = table.Column<int>(type: "int", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fighter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsComplete = table.Column<int>(type: "int", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    Card = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTitleFight = table.Column<int>(type: "int", nullable: false),
                    FirstFighterId = table.Column<int>(type: "int", nullable: false),
                    SecondFighterId = table.Column<int>(type: "int", nullable: false),
                    IsComplete = table.Column<int>(type: "int", nullable: false),
                    WinnerNum = table.Column<int>(type: "int", nullable: false),
                    WinReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstEndRating = table.Column<int>(type: "int", nullable: false),
                    SecondEndRating = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fight_Fighter_FirstFighterId",
                        column: x => x.FirstFighterId,
                        principalTable: "Fighter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Fight_Fighter_SecondFighterId",
                        column: x => x.SecondFighterId,
                        principalTable: "Fighter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Fight_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fight_FirstFighterId",
                table: "Fight",
                column: "FirstFighterId");

            migrationBuilder.CreateIndex(
                name: "IX_Fight_SecondFighterId",
                table: "Fight",
                column: "SecondFighterId");

            migrationBuilder.CreateIndex(
                name: "IX_Fight_TournamentId",
                table: "Fight",
                column: "TournamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fight");

            migrationBuilder.DropTable(
                name: "Fighter");

            migrationBuilder.DropTable(
                name: "Tournament");
        }
    }
}
