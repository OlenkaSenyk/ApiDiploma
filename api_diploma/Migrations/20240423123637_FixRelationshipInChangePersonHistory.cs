using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_diploma.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationshipInChangePersonHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChangePersonHistory_PersonId",
                table: "ChangePersonHistory");

            migrationBuilder.DropIndex(
                name: "IX_ChangePersonHistory_UserId",
                table: "ChangePersonHistory");

            migrationBuilder.CreateIndex(
                name: "IX_ChangePersonHistory_PersonId",
                table: "ChangePersonHistory",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangePersonHistory_UserId",
                table: "ChangePersonHistory",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChangePersonHistory_PersonId",
                table: "ChangePersonHistory");

            migrationBuilder.DropIndex(
                name: "IX_ChangePersonHistory_UserId",
                table: "ChangePersonHistory");

            migrationBuilder.CreateIndex(
                name: "IX_ChangePersonHistory_PersonId",
                table: "ChangePersonHistory",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChangePersonHistory_UserId",
                table: "ChangePersonHistory",
                column: "UserId",
                unique: true);
        }
    }
}
