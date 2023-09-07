using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRegister.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeMasters",
                columns: table => new
                {
                    EmployeeVtccertificateNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeFathersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeBatchNo = table.Column<int>(type: "int", nullable: true),
                    EmployeeStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeAadharNo = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMasters", x => x.EmployeeVtccertificateNo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeMasters");
        }
    }
}
