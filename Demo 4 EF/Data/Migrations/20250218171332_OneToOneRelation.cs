using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_4_EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class OneToOneRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_departmentDeptId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "departmentDeptId",
                table: "Employees",
                newName: "DepartmentDeptId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_departmentDeptId",
                table: "Employees",
                newName: "IX_Employees_DepartmentDeptId");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerId",
                table: "Departments",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_ManagerId",
                table: "Departments",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentDeptId",
                table: "Employees",
                column: "DepartmentDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_ManagerId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentDeptId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ManagerId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "DepartmentDeptId",
                table: "Employees",
                newName: "departmentDeptId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentDeptId",
                table: "Employees",
                newName: "IX_Employees_departmentDeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_departmentDeptId",
                table: "Employees",
                column: "departmentDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
