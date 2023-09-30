using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRegister.Migrations
{
    /// <inheritdoc />
    public partial class addedchangedbarcodemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarcodeImage",
                table: "EmployeeMasters");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "EmployeeMasters",
                newName: "BarcodeImageData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BarcodeImageData",
                table: "EmployeeMasters",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<byte[]>(
                name: "BarcodeImage",
                table: "EmployeeMasters",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
