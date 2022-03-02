using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalFinanceManagement.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountSummaries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountSummaries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AccountSummaries",
                columns: new[] { "Id", "AccountNo", "Address", "Balance", "DateCreated", "DateModified", "FirstName", "LastName" },
                values: new object[] { "0b9ce807-3402-4a9d-b7cc-c712bed8a90f", "2119174850", "Sangotedo", 8036844238.0, new DateTime(2022, 2, 24, 7, 14, 53, 382, DateTimeKind.Local).AddTicks(306), new DateTime(2022, 2, 24, 7, 14, 53, 382, DateTimeKind.Local).AddTicks(307), "Akperhe", "Smith" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountSummaries");
        }
    }
}
