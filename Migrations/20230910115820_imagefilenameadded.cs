using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRegister.Migrations
{
    /// <inheritdoc />
    public partial class imagefilenameadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "EmployeeMasters");
        }
    }
}
