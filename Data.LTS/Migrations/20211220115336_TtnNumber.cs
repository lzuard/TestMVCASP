using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.LTS.Migrations
{
    public partial class TtnNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Ttns",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Ttns");
        }
    }
}
