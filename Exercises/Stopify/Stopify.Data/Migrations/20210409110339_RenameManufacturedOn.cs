using Microsoft.EntityFrameworkCore.Migrations;

namespace Stopify.Data.Migrations
{
    public partial class RenameManufacturedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ManifacturedOn",
                table: "Products",
                newName: "ManufacturedOn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ManufacturedOn",
                table: "Products",
                newName: "ManifacturedOn");
        }
    }
}
