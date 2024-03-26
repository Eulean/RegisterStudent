using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRegisteration.Migrations
{
    /// <inheritdoc />
    public partial class NewInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addresses_StudentDetails_StudentDetailsId",
                table: "addresses");

            migrationBuilder.DropIndex(
                name: "IX_StudentDetails_UserId",
                table: "StudentDetails");

            migrationBuilder.DropIndex(
                name: "IX_addresses_StudentDetailsId",
                table: "addresses");

            migrationBuilder.AlterColumn<string>(
                name: "StudentDetailsId",
                table: "addresses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetails_UserId",
                table: "StudentDetails",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_addresses_StudentDetailsId",
                table: "addresses",
                column: "StudentDetailsId",
                unique: true,
                filter: "[StudentDetailsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_addresses_StudentDetails_StudentDetailsId",
                table: "addresses",
                column: "StudentDetailsId",
                principalTable: "StudentDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addresses_StudentDetails_StudentDetailsId",
                table: "addresses");

            migrationBuilder.DropIndex(
                name: "IX_StudentDetails_UserId",
                table: "StudentDetails");

            migrationBuilder.DropIndex(
                name: "IX_addresses_StudentDetailsId",
                table: "addresses");

            migrationBuilder.AlterColumn<string>(
                name: "StudentDetailsId",
                table: "addresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetails_UserId",
                table: "StudentDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_StudentDetailsId",
                table: "addresses",
                column: "StudentDetailsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_addresses_StudentDetails_StudentDetailsId",
                table: "addresses",
                column: "StudentDetailsId",
                principalTable: "StudentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
