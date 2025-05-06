using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeBilheteira.Migrations
{
    /// <inheritdoc />
    public partial class Payment6596 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Cards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Cards",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
