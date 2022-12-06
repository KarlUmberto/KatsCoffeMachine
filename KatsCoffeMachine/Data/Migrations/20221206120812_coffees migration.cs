using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KatsCoffeMachine.Data.Migrations
{
    public partial class coffeesmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Coffee");

            migrationBuilder.DropColumn(
                name: "CoffeeType",
                table: "Coffee");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Coffee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoffeeTypeId",
                table: "Coffee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coffee_BrandId",
                table: "Coffee",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Coffee_CoffeeTypeId",
                table: "Coffee",
                column: "CoffeeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coffee_Brand_BrandId",
                table: "Coffee",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coffee_CoffeeType_CoffeeTypeId",
                table: "Coffee",
                column: "CoffeeTypeId",
                principalTable: "CoffeeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coffee_Brand_BrandId",
                table: "Coffee");

            migrationBuilder.DropForeignKey(
                name: "FK_Coffee_CoffeeType_CoffeeTypeId",
                table: "Coffee");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "CoffeeType");

            migrationBuilder.DropIndex(
                name: "IX_Coffee_BrandId",
                table: "Coffee");

            migrationBuilder.DropIndex(
                name: "IX_Coffee_CoffeeTypeId",
                table: "Coffee");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Coffee");

            migrationBuilder.DropColumn(
                name: "CoffeeTypeId",
                table: "Coffee");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Coffee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoffeeType",
                table: "Coffee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
