using Microsoft.EntityFrameworkCore.Migrations;

namespace Panda.Data.Migrations
{
    public partial class ReceiptRecipient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipientId",
                table: "Receipts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_RecipientId",
                table: "Receipts",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_AspNetUsers_RecipientId",
                table: "Receipts",
                column: "RecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_AspNetUsers_RecipientId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_RecipientId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "Receipts");
        }
    }
}
