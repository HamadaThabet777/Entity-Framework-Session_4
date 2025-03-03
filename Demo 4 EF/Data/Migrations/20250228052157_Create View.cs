using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_4_EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create view EmployeeDepartment
                                 with Encryption
                                  as
                                   select E.Code EmployeeId, E.Name EmployeeName, D.DeptId DepartmentId, D.DepartmentName DepartmentName
                                  from Departments D , Employees E
                                   where D.DeptId = E.DepartmentDeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view EmployeeDepartment");
        }
    }
}
