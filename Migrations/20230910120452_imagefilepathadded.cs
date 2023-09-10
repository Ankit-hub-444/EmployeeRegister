using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRegister.Migrations
{
    /// <inheritdoc />
    public partial class imagefilepathadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFilePath",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFilePath",
                table: "EmployeeMasters");
        }
    }
}
