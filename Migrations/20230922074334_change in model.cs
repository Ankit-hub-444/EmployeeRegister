using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRegister.Migrations
{
    /// <inheritdoc />
    public partial class changeinmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthoritySignature",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "FormA",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "FormO",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "VtcCertificate",
                table: "EmployeeMasters");

            migrationBuilder.AddColumn<string>(
                name: "AuthoritySignatureData",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormAData",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormOData",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VtcCertificateData",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthoritySignatureData",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "FormAData",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "FormOData",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "VtcCertificateData",
                table: "EmployeeMasters");

            migrationBuilder.AddColumn<byte>(
                name: "AuthoritySignature",
                table: "EmployeeMasters",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "FormA",
                table: "EmployeeMasters",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "FormO",
                table: "EmployeeMasters",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "VtcCertificate",
                table: "EmployeeMasters",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
