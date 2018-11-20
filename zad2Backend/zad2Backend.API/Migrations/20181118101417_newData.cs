using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace zad2Backend.API.Migrations
{
    public partial class newData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Novinky",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nazov = table.Column<string>(nullable: true),
                    datum = table.Column<DateTime>(nullable: false),
                    text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novinky", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Terminy",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nazov = table.Column<string>(nullable: true),
                    datum = table.Column<DateTime>(nullable: false),
                    text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminy", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Novinky");

            migrationBuilder.DropTable(
                name: "Terminy");
        }
    }
}
