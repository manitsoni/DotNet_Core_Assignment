using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessEntities.Migrations
{
    public partial class initialanother : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Departments_DepartmentId",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Departments_DepartmentId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employee");
        }
    }
}
