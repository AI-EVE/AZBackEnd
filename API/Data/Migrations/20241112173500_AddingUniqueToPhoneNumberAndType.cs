using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingUniqueToPhoneNumberAndType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SocialTypes_Type",
                table: "SocialTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientPhones_PhoneNumber",
                table: "ClientPhones",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SocialTypes_Type",
                table: "SocialTypes");

            migrationBuilder.DropIndex(
                name: "IX_ClientPhones_PhoneNumber",
                table: "ClientPhones");
        }
    }
}
