using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeBilheteira.Migrations
{
    /// <inheritdoc />
    public partial class Payment659 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_AspNetUsers_AppUserId",
                table: "PaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentMethods_PaymentMethodId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethods",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "PaymentMethods");

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
                name: "PaymentMethodType",
                table: "PaymentMethods");

            migrationBuilder.RenameTable(
                name: "PaymentMethods",
                newName: "Paypals");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentMethods_AppUserId",
                table: "Paypals",
                newName: "IX_Paypals_AppUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Paypals",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaypalTransactionId",
                table: "Paypals",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaypalEmail",
                table: "Paypals",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paypals",
                table: "Paypals",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AppUserId = table.Column<string>(type: "TEXT", nullable: false),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    CardHolderName = table.Column<string>(type: "TEXT", nullable: false),
                    CardNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Cvv = table.Column<string>(type: "TEXT", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_AppUserId",
                table: "Cards",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paypals_AspNetUsers_AppUserId",
                table: "Paypals",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paypals_AspNetUsers_AppUserId",
                table: "Paypals");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paypals",
                table: "Paypals");

            migrationBuilder.RenameTable(
                name: "Paypals",
                newName: "PaymentMethods");

            migrationBuilder.RenameIndex(
                name: "IX_Paypals_AppUserId",
                table: "PaymentMethods",
                newName: "IX_PaymentMethods_AppUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "PaymentMethods",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "PaypalTransactionId",
                table: "PaymentMethods",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "PaypalEmail",
                table: "PaymentMethods",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "PaymentMethods",
                type: "TEXT",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethodType",
                table: "PaymentMethods",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethods",
                table: "PaymentMethods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_AspNetUsers_AppUserId",
                table: "PaymentMethods",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentMethods_PaymentMethodId",
                table: "Payments",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
