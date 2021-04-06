using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImmediateSupervisor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Department_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_Name = table.Column<int>(type: "int", nullable: false),
                    User_ID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Department_ID);
                    table.ForeignKey(
                        name: "FK_Department_User_User_ID",
                        column: x => x.User_ID,
                        principalTable: "User",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_User_ID",
                table: "Department",
                column: "User_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
