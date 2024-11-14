using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTableNamingOfLastMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarGeneration_CarModel_CarModelId",
                table: "CarGeneration");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModel_CarMaker_CarMakerId",
                table: "CarModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarMaker",
                table: "CarMaker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarGeneration",
                table: "CarGeneration");

            migrationBuilder.RenameTable(
                name: "CarModel",
                newName: "CarModels");

            migrationBuilder.RenameTable(
                name: "CarMaker",
                newName: "CarMakers");

            migrationBuilder.RenameTable(
                name: "CarGeneration",
                newName: "CarGenerations");

            migrationBuilder.RenameIndex(
                name: "IX_CarModel_Name_CarMakerId",
                table: "CarModels",
                newName: "IX_CarModels_Name_CarMakerId");

            migrationBuilder.RenameIndex(
                name: "IX_CarModel_CarMakerId",
                table: "CarModels",
                newName: "IX_CarModels_CarMakerId");

            migrationBuilder.RenameIndex(
                name: "IX_CarMaker_Name",
                table: "CarMakers",
                newName: "IX_CarMakers_Name");

            migrationBuilder.RenameIndex(
                name: "IX_CarGeneration_Name_CarModelId",
                table: "CarGenerations",
                newName: "IX_CarGenerations_Name_CarModelId");

            migrationBuilder.RenameIndex(
                name: "IX_CarGeneration_CarModelId",
                table: "CarGenerations",
                newName: "IX_CarGenerations_CarModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModels",
                table: "CarModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarMakers",
                table: "CarMakers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarGenerations",
                table: "CarGenerations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarGenerations_CarModels_CarModelId",
                table: "CarGenerations",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_CarMakers_CarMakerId",
                table: "CarModels",
                column: "CarMakerId",
                principalTable: "CarMakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarGenerations_CarModels_CarModelId",
                table: "CarGenerations");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_CarMakers_CarMakerId",
                table: "CarModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModels",
                table: "CarModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarMakers",
                table: "CarMakers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarGenerations",
                table: "CarGenerations");

            migrationBuilder.RenameTable(
                name: "CarModels",
                newName: "CarModel");

            migrationBuilder.RenameTable(
                name: "CarMakers",
                newName: "CarMaker");

            migrationBuilder.RenameTable(
                name: "CarGenerations",
                newName: "CarGeneration");

            migrationBuilder.RenameIndex(
                name: "IX_CarModels_Name_CarMakerId",
                table: "CarModel",
                newName: "IX_CarModel_Name_CarMakerId");

            migrationBuilder.RenameIndex(
                name: "IX_CarModels_CarMakerId",
                table: "CarModel",
                newName: "IX_CarModel_CarMakerId");

            migrationBuilder.RenameIndex(
                name: "IX_CarMakers_Name",
                table: "CarMaker",
                newName: "IX_CarMaker_Name");

            migrationBuilder.RenameIndex(
                name: "IX_CarGenerations_Name_CarModelId",
                table: "CarGeneration",
                newName: "IX_CarGeneration_Name_CarModelId");

            migrationBuilder.RenameIndex(
                name: "IX_CarGenerations_CarModelId",
                table: "CarGeneration",
                newName: "IX_CarGeneration_CarModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarMaker",
                table: "CarMaker",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarGeneration",
                table: "CarGeneration",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarGeneration_CarModel_CarModelId",
                table: "CarGeneration",
                column: "CarModelId",
                principalTable: "CarModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModel_CarMaker_CarMakerId",
                table: "CarModel",
                column: "CarMakerId",
                principalTable: "CarMaker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
