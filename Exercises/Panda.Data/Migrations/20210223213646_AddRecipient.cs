using Microsoft.EntityFrameworkCore.Migrations;

namespace Panda.Data.Migrations
{
    public partial class AddRecipient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AspNetUsers_ReceiptId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_ReceiptId",
                table: "Packages");

            migrationBuilder.AlterColumn<string>(
                name: "RecipientId",
                table: "Packages",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiptId",
                table: "Packages",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_RecipientId",
                table: "Packages",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AspNetUsers_RecipientId",
                table: "Packages",
                column: "RecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AspNetUsers_RecipientId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_RecipientId",
                table: "Packages");

            migrationBuilder.AlterColumn<string>(
                name: "RecipientId",
                table: "Packages",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiptId",
                table: "Packages",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ReceiptId",
                table: "Packages",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AspNetUsers_ReceiptId",
                table: "Packages",
                column: "ReceiptId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
