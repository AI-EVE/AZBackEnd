using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class defineTableProductCarGenerations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCarGenerations",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    CarGenerationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCarGenerations", x => new { x.ProductId, x.CarGenerationId });
                    table.ForeignKey(
                        name: "FK_ProductCarGenerations_CarGenerations_CarGenerationId",
                        column: x => x.CarGenerationId,
                        principalTable: "CarGenerations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCarGenerations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCarGenerations_CarGenerationId",
                table: "ProductCarGenerations",
                column: "CarGenerationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCarGenerations_ProductId_CarGenerationId",
                table: "ProductCarGenerations",
                columns: new[] { "ProductId", "CarGenerationId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCarGenerations");
        }
    }
}
