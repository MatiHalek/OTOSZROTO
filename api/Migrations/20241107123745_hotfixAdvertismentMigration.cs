using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class hotfixAdvertismentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int?>(
                name: "UserID",
                table: "Advertisements",
                type: "integer",
                nullable: true);  // Make it nullable initially

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_UserID",
                table: "Advertisements",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Users_UserID",
                table: "Advertisements",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Users_UserID",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_UserID",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Advertisements");
        }
    }
}
