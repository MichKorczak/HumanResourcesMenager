using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanResourcesManager.Core.Migrations
{
    public partial class JobPositionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "ManagerEmployeeId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ManagerId",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "JobPosition",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PositionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeJobPosition",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PositionId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeJobPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeJobPosition_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeJobPosition_JobPosition_PositionId",
                        column: x => x.PositionId,
                        principalTable: "JobPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerEmployeeId",
                table: "Employees",
                column: "ManagerEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobPosition_EmployeeId",
                table: "EmployeeJobPosition",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeJobPosition_PositionId",
                table: "EmployeeJobPosition",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ManagerEmployeeId",
                table: "Employees",
                column: "ManagerEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ManagerEmployeeId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeJobPosition");

            migrationBuilder.DropTable(
                name: "JobPosition");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ManagerEmployeeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ManagerEmployeeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
