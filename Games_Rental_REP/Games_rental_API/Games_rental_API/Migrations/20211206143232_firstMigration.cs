using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Games_rental_API.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "rentalHistories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalDate = table.Column<DateTime>(nullable: false),
                    GameID = table.Column<int>(nullable: false),
                    MemberID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rentalHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_rentalHistories_members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                
                
                    table.PrimaryKey("PK_rentalHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_rentalHistories_games_GameID",
                        column: x => x.GameID,
                        principalTable: "games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                }
                );

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RentalDates = table.Column<string>(nullable: true),
                    isAvailable = table.Column<bool>(nullable: false),
                    RentalHistoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.ID);
                    table.ForeignKey(
                        name: "FK_games_rentalHistories_RentalHistoryID",
                        column: x => x.RentalHistoryID,
                        principalTable: "rentalHistories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_games_RentalHistoryID",
                table: "games",
                column: "RentalHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_rentalHistories_MemberID",
                table: "rentalHistories",
                column: "MemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "rentalHistories");

            migrationBuilder.DropTable(
                name: "members");
        }
    }
}
