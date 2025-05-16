using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeBilheteira.Migrations
{
    /// <inheritdoc />
    public partial class Payment658886666466548765647664 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Rentals",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Rentals",
                newName: "EndDate");

            migrationBuilder.AddColumn<string>(
                name: "StateName",
                table: "Rentals",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateName",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Rentals",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Rentals",
                newName: "endDate");
        }
    }
}
