using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KatsCoffeMachine.Data.Migrations
{
    public partial class cupPackages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CupsInPackage",
                table: "Coffee",
                newName: "CupPackages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CupPackages",
                table: "Coffee",
                newName: "CupsInPackage");
        }
    }
}
