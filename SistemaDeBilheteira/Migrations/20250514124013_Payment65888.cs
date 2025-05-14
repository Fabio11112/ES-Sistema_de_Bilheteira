using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeBilheteira.Migrations
{
    /// <inheritdoc />
    public partial class Payment65888 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "balance",
                table: "Paypals",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "balance",
                table: "Cards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "balance",
                table: "Paypals");

            migrationBuilder.DropColumn(
                name: "balance",
                table: "Cards");
        }
    }
}
