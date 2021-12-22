using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Datas.Migrations
{
    public partial class EmployeeLeaveTypeAddColumnIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EmployeeLeaveTypes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EmployeeLeaveTypes");
        }
    }
}
