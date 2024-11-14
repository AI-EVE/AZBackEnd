using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsBoughtProductOrdersTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopBillImage_Shops_ShopId",
                table: "ShopBillImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopBillImage",
                table: "ShopBillImage");

            migrationBuilder.RenameTable(
                name: "ShopBillImage",
                newName: "ShopBillImages");

            migrationBuilder.RenameIndex(
                name: "IX_ShopBillImage_ShopId",
                table: "ShopBillImages",
                newName: "IX_ShopBillImages_ShopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopBillImages",
                table: "ShopBillImages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(16,4)", nullable: false),
                    UnitDiscount = table.Column<decimal>(type: "numeric(16,4)", nullable: false),
                    OrderedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    IsReturned = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductsBought",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(16,4)", nullable: false),
                    UnitDiscount = table.Column<decimal>(type: "numeric(16,4)", nullable: false),
                    BoughtAt = table.Column<DateOnly>(type: "date", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ShopId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsBought", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsBought_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsBought_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ClientId",
                table: "ProductOrders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ProductId",
                table: "ProductOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsBought_ProductId",
                table: "ProductsBought",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsBought_ShopId",
                table: "ProductsBought",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopBillImages_Shops_ShopId",
                table: "ShopBillImages",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopBillImages_Shops_ShopId",
                table: "ShopBillImages");

            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "ProductsBought");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopBillImages",
                table: "ShopBillImages");

            migrationBuilder.RenameTable(
                name: "ShopBillImages",
                newName: "ShopBillImage");

            migrationBuilder.RenameIndex(
                name: "IX_ShopBillImages_ShopId",
                table: "ShopBillImage",
                newName: "IX_ShopBillImage_ShopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopBillImage",
                table: "ShopBillImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopBillImage_Shops_ShopId",
                table: "ShopBillImage",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
