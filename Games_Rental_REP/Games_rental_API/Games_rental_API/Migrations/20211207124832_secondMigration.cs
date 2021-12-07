using Microsoft.EntityFrameworkCore.Migrations;

namespace Games_rental_API.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_games_rentalHistories_RentalHistoryID",
                table: "games");

            migrationBuilder.DropIndex(
                name: "IX_games_RentalHistoryID",
                table: "games");

            migrationBuilder.DropColumn(
                name: "RentalHistoryID",
                table: "games");

            migrationBuilder.CreateIndex(
                name: "IX_rentalHistories_GameID",
                table: "rentalHistories",
                column: "GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_rentalHistories_games_GameID",
                table: "rentalHistories",
                column: "GameID",
                principalTable: "games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rentalHistories_games_GameID",
                table: "rentalHistories");

            migrationBuilder.DropIndex(
                name: "IX_rentalHistories_GameID",
                table: "rentalHistories");

            migrationBuilder.AddColumn<int>(
                name: "RentalHistoryID",
                table: "games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_games_RentalHistoryID",
                table: "games",
                column: "RentalHistoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_games_rentalHistories_RentalHistoryID",
                table: "games",
                column: "RentalHistoryID",
                principalTable: "rentalHistories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
