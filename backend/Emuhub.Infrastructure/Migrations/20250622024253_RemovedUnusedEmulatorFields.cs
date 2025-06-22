using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emuhub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUnusedEmulatorFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Emulators");

            migrationBuilder.DropColumn(
                name: "Console",
                table: "Emulators");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Emulators",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Console",
                table: "Emulators",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
