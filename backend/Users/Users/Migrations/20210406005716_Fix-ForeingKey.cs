using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Migrations
{
    public partial class FixForeingKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_User_User_ID",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_User_ID",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "Department");

            migrationBuilder.CreateIndex(
                name: "IX_User_Department_ID",
                table: "User",
                column: "Department_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Department_Department_ID",
                table: "User",
                column: "Department_ID",
                principalTable: "Department",
                principalColumn: "Department_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Department_Department_ID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Department_ID",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "User_ID",
                table: "Department",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_User_ID",
                table: "Department",
                column: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_User_User_ID",
                table: "Department",
                column: "User_ID",
                principalTable: "User",
                principalColumn: "User_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
