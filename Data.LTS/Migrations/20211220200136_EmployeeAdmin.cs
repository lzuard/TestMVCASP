using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Data.LTS.Migrations
{
    public partial class EmployeeAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[]
                {
                    "SecondName", "FirstName", "ThirdName", "BirthDate", "PhoneNumber", "Password", "Login", "IsFired"
                },
                values: new object[]
                {
                    "Админов", "Админ", "Админович", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                    "89008005050", "4297F44B13955235245B2497399D7A93", "admin", false
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Employees");
        }
    }
}
