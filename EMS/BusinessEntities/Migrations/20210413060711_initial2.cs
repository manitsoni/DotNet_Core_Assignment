using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessEntities.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Employee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "(N'')");
        }
    }
}
