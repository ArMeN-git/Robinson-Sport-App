using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RobinsonSportApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class EventsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opponent1 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Opponent2 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Opponent1Logo = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Opponent2Logo = table.Column<string>(type: "nvarchar(265)", maxLength: 265, nullable: true),
                    Score1 = table.Column<float>(type: "real", nullable: false),
                    Score2 = table.Column<float>(type: "real", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    SportCategory = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getUtcDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
