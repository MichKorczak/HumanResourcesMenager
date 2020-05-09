using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanResourcesManager.Core.Migrations
{
    public partial class AddJobPositionData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeJobPosition_Employees_EmployeeId",
                table: "EmployeeJobPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeJobPosition_JobPosition_PositionId",
                table: "EmployeeJobPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPosition",
                table: "JobPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeJobPosition",
                table: "EmployeeJobPosition");

            migrationBuilder.RenameTable(
                name: "JobPosition",
                newName: "JobPositions");

            migrationBuilder.RenameTable(
                name: "EmployeeJobPosition",
                newName: "EmployeeJobPositions");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeJobPosition_PositionId",
                table: "EmployeeJobPositions",
                newName: "IX_EmployeeJobPositions_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeJobPosition_EmployeeId",
                table: "EmployeeJobPositions",
                newName: "IX_EmployeeJobPositions_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPositions",
                table: "JobPositions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeJobPositions",
                table: "EmployeeJobPositions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeJobPositions_Employees_EmployeeId",
                table: "EmployeeJobPositions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeJobPositions_JobPositions_PositionId",
                table: "EmployeeJobPositions",
                column: "PositionId",
                principalTable: "JobPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeJobPositions_Employees_EmployeeId",
                table: "EmployeeJobPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeJobPositions_JobPositions_PositionId",
                table: "EmployeeJobPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPositions",
                table: "JobPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeJobPositions",
                table: "EmployeeJobPositions");

            migrationBuilder.RenameTable(
                name: "JobPositions",
                newName: "JobPosition");

            migrationBuilder.RenameTable(
                name: "EmployeeJobPositions",
                newName: "EmployeeJobPosition");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeJobPositions_PositionId",
                table: "EmployeeJobPosition",
                newName: "IX_EmployeeJobPosition_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeJobPositions_EmployeeId",
                table: "EmployeeJobPosition",
                newName: "IX_EmployeeJobPosition_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPosition",
                table: "JobPosition",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeJobPosition",
                table: "EmployeeJobPosition",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeJobPosition_Employees_EmployeeId",
                table: "EmployeeJobPosition",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeJobPosition_JobPosition_PositionId",
                table: "EmployeeJobPosition",
                column: "PositionId",
                principalTable: "JobPosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
