using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRegister.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmployeeAadharNo",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "AuthoritySignature",
                table: "EmployeeMasters",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EmployeeIMEDate",
                table: "EmployeeMasters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeNo",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "IMENo",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdCardNo",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignatureFileName",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignatureFilePath",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "VtcCertificate",
                table: "EmployeeMasters",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "VtcNo",
                table: "EmployeeMasters",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "AuthoritySignature",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "EmployeeIMEDate",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "EmployeeNo",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "FormA",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "FormO",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "IMENo",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "IdCardNo",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "SignatureFileName",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "SignatureFilePath",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "VtcCertificate",
                table: "EmployeeMasters");

            migrationBuilder.DropColumn(
                name: "VtcNo",
                table: "EmployeeMasters");

            migrationBuilder.AlterColumn<long>(
                name: "EmployeeAadharNo",
                table: "EmployeeMasters",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
