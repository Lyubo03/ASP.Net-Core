using Microsoft.EntityFrameworkCore.Migrations;

namespace Panda.Data.Migrations
{
    public partial class NzBrat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageStatuses_StatusId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_StatusId",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Packages",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Packages",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Packages",
                newName: "StatusId");

            migrationBuilder.AlterColumn<string>(
                name: "StatusId",
                table: "Packages",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_StatusId",
                table: "Packages",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageStatuses_StatusId",
                table: "Packages",
                column: "StatusId",
                principalTable: "PackageStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
