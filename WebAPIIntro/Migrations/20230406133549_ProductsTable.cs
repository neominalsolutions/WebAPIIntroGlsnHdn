using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIIntro.Migrations
{
    public partial class ProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ÜrünTablosu_Categories_CategoryId",
                table: "ÜrünTablosu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ÜrünTablosu",
                table: "ÜrünTablosu");

            migrationBuilder.RenameTable(
                name: "ÜrünTablosu",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_ÜrünTablosu_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ÜrünTablosu");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "ÜrünTablosu",
                newName: "IX_ÜrünTablosu_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ÜrünTablosu",
                table: "ÜrünTablosu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ÜrünTablosu_Categories_CategoryId",
                table: "ÜrünTablosu",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
