using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationAPI.Repository.Migrations
{
    /// <inheritdoc />
    public partial class otp2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Pins");

            migrationBuilder.DropColumn(
                name: "DisabledAt",
                table: "Biometrics");

            migrationBuilder.RenameColumn(
                name: "HashedPin",
                table: "Pins",
                newName: "PinCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PinCode",
                table: "Pins",
                newName: "HashedPin");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Pins",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DisabledAt",
                table: "Biometrics",
                type: "datetime2",
                nullable: true);
        }
    }
}
