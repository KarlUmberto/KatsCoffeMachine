using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KatsCoffeMachine.Data.Migrations
{
    public partial class CreateCoffeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coffee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoffeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CupsAvailable = table.Column<int>(type: "int", nullable: false),
                    CupsInPackage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffee", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coffee");
        }
    }
}
