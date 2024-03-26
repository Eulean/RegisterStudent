using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRegisteration.Migrations
{
    /// <inheritdoc />
    public partial class newsChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_addresses_AddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "StudentDetails");

            migrationBuilder.RenameColumn(
                name: "PrifilePicturePath",
                table: "StudentDetails",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "StudentDetails",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "StudentDetailsId",
                table: "addresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addresses_StudentDetails_StudentDetailsId",
                table: "addresses");

            migrationBuilder.DropIndex(
                name: "IX_addresses_StudentDetailsId",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "StudentDetailsId",
                table: "addresses");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StudentDetails",
                newName: "PrifilePicturePath");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "StudentDetails",
                newName: "LastName");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "StudentDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_addresses_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "addresses",
                principalColumn: "Id");
        }
    }
}
