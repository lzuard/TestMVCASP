using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.LTS.Migrations
{
    public partial class AgentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AgentTypes",
                columns: new[] { "Name" },
                values: new object[] { "Клиент" });
            migrationBuilder.InsertData(
                table: "AgentTypes",
                columns: new[] { "Name" },
                values: new object[] { "Поставщик" });
            migrationBuilder.InsertData(
                table: "AgentTypes",
                columns: new[] { "Name" },
                values: new object[] { "Транспортная компания" });
            migrationBuilder.InsertData(
                table: "AgentTypes",
                columns: new[] { "Name" },
                values: new object[] { "Утилизатор" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE AgentTypes");
        }
    }
}
