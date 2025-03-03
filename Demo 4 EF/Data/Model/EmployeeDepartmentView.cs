using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_4_EF.Data.Model
{
    internal class EmployeeDepartmentView
    {
        public int EmployeeId { get; set; } 
        public string EmployeeName { get; set; } 
        public int DepartmentId { get; set; } 
       public string DepartmentName { get; set; }
    }
}
