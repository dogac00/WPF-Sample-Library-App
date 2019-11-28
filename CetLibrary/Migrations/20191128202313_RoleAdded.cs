using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CetLibrary.Migrations
{
    public partial class RoleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "CetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 28, 23, 23, 13, 121, DateTimeKind.Local).AddTicks(815));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "CetUsers");

            migrationBuilder.UpdateData(
                table: "CetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 22, 12, 49, 14, 792, DateTimeKind.Local).AddTicks(6429));
        }
    }
}
