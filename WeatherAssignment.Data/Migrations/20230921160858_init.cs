using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherAssignment.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Generationtime_ms = table.Column<double>(type: "float", nullable: false),
                    Utc_offset_seconds = table.Column<int>(type: "int", nullable: false),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timezone_abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elevation = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrentWeather",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Windspeed = table.Column<double>(type: "float", nullable: false),
                    WindDirection = table.Column<int>(type: "int", nullable: false),
                    WeatherCode = table.Column<int>(type: "int", nullable: false),
                    is_Day = table.Column<int>(type: "int", nullable: false),
                    WeatherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentWeather", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentWeather_Weathers_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weathers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrentWeather_WeatherId",
                table: "CurrentWeather",
                column: "WeatherId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentWeather");

            migrationBuilder.DropTable(
                name: "Weathers");
        }
    }
}
