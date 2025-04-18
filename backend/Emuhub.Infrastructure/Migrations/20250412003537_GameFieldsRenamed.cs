using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emuhub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GameFieldsRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
