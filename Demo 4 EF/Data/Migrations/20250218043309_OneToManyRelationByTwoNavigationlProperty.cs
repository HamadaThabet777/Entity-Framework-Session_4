using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_4_EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyRelationByTwoNavigationlProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "departmentDeptId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_departmentDeptId",
                table: "Employees",
                column: "departmentDeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_departmentDeptId",
                table: "Employees",
                column: "departmentDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_departmentDeptId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_departmentDeptId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "departmentDeptId",
                table: "Employees");
        }
    }
}
