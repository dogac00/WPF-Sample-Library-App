using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CetLibrary.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CetUsers",
                columns: new[] { "Id", "CreatedDate", "Name", "Password", "Surname", "UserName" },
                values: new object[] { 1, new DateTime(2019, 11, 22, 12, 49, 14, 792, DateTimeKind.Local).AddTicks(6429), "Super", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", "User", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CetUsers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
