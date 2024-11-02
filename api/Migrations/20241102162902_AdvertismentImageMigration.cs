using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AdvertismentImageMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertismentImages",
                columns: table => new
                {
                    AdvertismentImageID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageSource = table.Column<string>(type: "text", nullable: true),
                    AdvertismentID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertismentImages", x => x.AdvertismentImageID);
                    table.ForeignKey(
                        name: "FK_AdvertismentImages_Advertisements_AdvertismentID",
                        column: x => x.AdvertismentID,
                        principalTable: "Advertisements",
                        principalColumn: "AdvertisementID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertismentImages_AdvertismentID",
                table: "AdvertismentImages",
                column: "AdvertismentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertismentImages");
        }
    }
}
