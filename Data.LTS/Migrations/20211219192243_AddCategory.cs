using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.LTS.Migrations
{
    public partial class AddCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryDto_CategoryDto_ParentCategoryId",
                table: "CategoryDto");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryDto_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryDto",
                table: "CategoryDto");

            migrationBuilder.RenameTable(
                name: "CategoryDto",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryDto_ParentCategoryId",
                table: "Categories",
                newName: "IX_Categories_ParentCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "CategoryDto");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "CategoryDto",
                newName: "IX_CategoryDto_ParentCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryDto",
                table: "CategoryDto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryDto_CategoryDto_ParentCategoryId",
                table: "CategoryDto",
                column: "ParentCategoryId",
                principalTable: "CategoryDto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryDto_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "CategoryDto",
                principalColumn: "Id");
        }
    }
}
