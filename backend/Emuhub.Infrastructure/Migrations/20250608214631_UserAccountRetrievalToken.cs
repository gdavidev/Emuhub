using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emuhub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserAccountRetrievalToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBanned",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "PasswordRetrievalToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordRetrievalTokenExpiryDate",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordRetrievalToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordRetrievalTokenExpiryDate",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "IsBanned",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
