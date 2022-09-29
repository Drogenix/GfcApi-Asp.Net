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
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    ShortInfo = table.Column<string>(type: "TEXT", nullable: false),
                    TextDocUrl = table.Column<string>(type: "TEXT", nullable: false),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Published = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fighters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sex = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SecondName = table.Column<string>(type: "TEXT", nullable: false),
                    Nickname = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<string>(type: "TEXT", nullable: false),
                    PfpRating = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    Win = table.Column<int>(type: "INTEGER", nullable: false),
                    Lose = table.Column<int>(type: "INTEGER", nullable: false),
                    Draw = table.Column<int>(type: "INTEGER", nullable: false),
                    Winstreak = table.Column<int>(type: "INTEGER", nullable: false),
                    Byknockout = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstRoundWins = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalHits = table.Column<int>(type: "INTEGER", nullable: false),
                    AccurateHits = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalTakedowns = table.Column<int>(type: "INTEGER", nullable: false),
                    AccurateTakedowns = table.Column<int>(type: "INTEGER", nullable: false),
                    WinByKoTko = table.Column<int>(type: "INTEGER", nullable: false),
                    WInByDecision = table.Column<int>(type: "INTEGER", nullable: false),
                    WinBySubmission = table.Column<int>(type: "INTEGER", nullable: false),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fighters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Place = table.Column<string>(type: "TEXT", nullable: false),
                    IsComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    TournamentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Card = table.Column<string>(type: "TEXT", nullable: false),
                    IsTitleFight = table.Column<bool>(type: "INTEGER", nullable: false),
                    FirstFighterId = table.Column<int>(type: "INTEGER", nullable: false),
                    SecondFighterId = table.Column<int>(type: "INTEGER", nullable: false),
                    WinnerNum = table.Column<int>(type: "INTEGER", nullable: false),
                    WinReason = table.Column<string>(type: "TEXT", nullable: false),
                    Round = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstEndRating = table.Column<int>(type: "INTEGER", nullable: false),
                    SecondEndRating = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fights_Fighters_FirstFighterId",
                        column: x => x.FirstFighterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fights_Fighters_SecondFighterId",
                        column: x => x.SecondFighterId,
                        principalTable: "Fighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fights_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fights_FirstFighterId",
                table: "Fights",
                column: "FirstFighterId");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_SecondFighterId",
                table: "Fights",
                column: "SecondFighterId");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_TournamentId",
                table: "Fights",
                column: "TournamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Fights");

            migrationBuilder.DropTable(
                name: "Fighters");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
