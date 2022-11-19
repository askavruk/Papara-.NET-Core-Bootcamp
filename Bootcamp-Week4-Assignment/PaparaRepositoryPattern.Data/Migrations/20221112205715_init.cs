using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaparaRepositoryPattern.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Adress", "City", "CreationDate", "DeleteDate", "Email", "Name", "Status", "TaxNumber" },
                values: new object[] { 1, "Uskudar", "Istanbul", new DateTime(2022, 11, 12, 23, 57, 14, 626, DateTimeKind.Local).AddTicks(590), null, "papara@papara.com", "Papara", 1, "123" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Adress", "City", "CreationDate", "DeleteDate", "Email", "Name", "Status", "TaxNumber" },
                values: new object[] { 2, "Beyoglu", "Istanbul", new DateTime(2022, 11, 12, 23, 57, 14, 626, DateTimeKind.Local).AddTicks(2915), null, "patika@patika.com", "Patika", 1, "123" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Adress", "City", "CreationDate", "DeleteDate", "Email", "Name", "Status", "TaxNumber" },
                values: new object[] { 3, "Beylikduzu", "Istanbul", new DateTime(2022, 11, 12, 23, 57, 14, 626, DateTimeKind.Local).AddTicks(2921), null, "company@company.com", "Company", 1, "123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
