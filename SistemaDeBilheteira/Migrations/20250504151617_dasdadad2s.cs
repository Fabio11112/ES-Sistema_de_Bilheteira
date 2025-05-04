using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeBilheteira.Migrations
{
    /// <inheritdoc />
    public partial class dasdadad2s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardHolderName",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "Cvv",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Currencies");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Currencies",
                newName: "Symbol");

            migrationBuilder.RenameColumn(
                name: "CurrencySymbol",
                table: "Currencies",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CurrencyName",
                table: "Currencies",
                newName: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Symbol",
                table: "Currencies",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Currencies",
                newName: "CurrencySymbol");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Currencies",
                newName: "CurrencyName");

            migrationBuilder.AddColumn<string>(
                name: "CardHolderName",
                table: "PaymentMethods",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "PaymentMethods",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cvv",
                table: "PaymentMethods",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "PaymentMethods",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Currencies",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Currencies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CurrencyId",
                table: "Currencies",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
