using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademicPageDotNet.Migrations
{
    /// <inheritdoc />
    public partial class TheButton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clicks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Count = table.Column<long>(type: "INTEGER", nullable: false),
                    LastClickIP = table.Column<string>(type: "TEXT", nullable: true),
                    LastClickTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clicks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clicks");
        }
    }
}
