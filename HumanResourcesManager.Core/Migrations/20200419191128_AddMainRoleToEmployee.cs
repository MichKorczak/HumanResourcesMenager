using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanResourcesManager.Core.Migrations
{
    public partial class AddMainRoleToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainRole",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainRole",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainRole",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MainRole",
                table: "Employees");
        }
    }
}
