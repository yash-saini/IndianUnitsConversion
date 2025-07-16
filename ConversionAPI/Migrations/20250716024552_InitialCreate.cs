using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversionAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConversionHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConversionType = table.Column<string>(type: "TEXT", nullable: false),
                    ConversionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InputValue = table.Column<string>(type: "TEXT", nullable: false),
                    InputUnit = table.Column<string>(type: "TEXT", nullable: false),
                    OutputValue = table.Column<string>(type: "TEXT", nullable: false),
                    OutputUnit = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversionHistories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversionHistories");
        }
    }
}
