using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRegister.Migrations
{
    /// <inheritdoc />
    public partial class NearFinalModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SignatureFilePath",
                table: "EmployeeMasters",
                newName: "SignatureData");

            migrationBuilder.RenameColumn(
                name: "SignatureFileName",
                table: "EmployeeMasters",
                newName: "ImageFileData");

            migrationBuilder.RenameColumn(
                name: "ImageFilePath",
                table: "EmployeeMasters",
                newName: "FormANo");

            migrationBuilder.RenameColumn(
                name: "ImageFileName",
                table: "EmployeeMasters",
                newName: "EmergencyMobileNumber");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmployeeDateOfBirth",
                table: "EmployeeMasters",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeDateOfBirth",
                table: "EmployeeMasters");

            migrationBuilder.RenameColumn(
                name: "SignatureData",
                table: "EmployeeMasters",
                newName: "SignatureFilePath");

            migrationBuilder.RenameColumn(
                name: "ImageFileData",
                table: "EmployeeMasters",
                newName: "SignatureFileName");

            migrationBuilder.RenameColumn(
                name: "FormANo",
                table: "EmployeeMasters",
                newName: "ImageFilePath");

            migrationBuilder.RenameColumn(
                name: "EmergencyMobileNumber",
                table: "EmployeeMasters",
                newName: "ImageFileName");
        }
    }
}
