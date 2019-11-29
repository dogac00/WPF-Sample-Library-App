using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CetLibrary.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CanChangePassword = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Surname = table.Column<string>(maxLength: 100, nullable: false),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CetUsers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CanChangePassword", "Name" },
                values: new object[] { 1, true, "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CanChangePassword", "Name" },
                values: new object[] { 2, false, "student" });

            migrationBuilder.InsertData(
                table: "CetUsers",
                columns: new[] { "Id", "CreatedDate", "Name", "Password", "RoleId", "Surname", "UserName" },
                values: new object[] { 1, new DateTime(2019, 11, 29, 10, 52, 49, 923, DateTimeKind.Local).AddTicks(4093), "dogac", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", 1, "akyildiz", "dogac" });

            migrationBuilder.CreateIndex(
                name: "IX_CetUsers_RoleId",
                table: "CetUsers",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CetUsers");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
