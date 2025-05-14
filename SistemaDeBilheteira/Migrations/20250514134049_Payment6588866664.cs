using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeBilheteira.Migrations
{
    /// <inheritdoc />
    public partial class Payment6588866664 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "balance",
                table: "Paypals",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "balance",
                table: "Cards",
                newName: "Balance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Paypals",
                newName: "balance");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Cards",
                newName: "balance");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Rentals",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
