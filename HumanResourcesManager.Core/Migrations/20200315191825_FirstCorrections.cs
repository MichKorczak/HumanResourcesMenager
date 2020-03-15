using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanResourcesManager.Core.Migrations
{
    public partial class FirstCorrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LasttName",
                table: "Employes");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employes");

            migrationBuilder.AddColumn<string>(
                name: "LasttName",
                table: "Employes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
