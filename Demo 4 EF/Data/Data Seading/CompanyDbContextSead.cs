using Demo_4_EF.Data.Model;
using Microsoft.IdentityModel.Tokens.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Demo_4_EF.Data.Data_Seading
{
    internal class CompanyDbContextSead
    {
        public static void seed(CompanyDbContext dbContext)
        {
            //employees ولل departments لل seed هبدا بقا اعمل جواها 
            //الاول ماهو مينفعش اقول ان الموظف شغال ف قسم 10 وانا معنديش قسم اصلا departments وابدا بالترتيب اخلي ال

            #region Department
            //departments.json لازم ابعت الباث اللي موجود فيه ملف ال
            //departments.json < Data Seading < Data < Demo 3 EF هفتح الفولدر بتاع 

            ////  var DepartmentsData =File.ReadAllText ("F:\\Rout\\Entity framework\\session 3\\Demo 3 EF\\Data\\Data Seading\\departments.json");
            //عشان اعتبره داتا حقيقه Deserialize كده هو معتبر ان الباث ده شويه سترينج وبس ف انا هعملو حاجه اسمها
            //Deserialize << لداتا حقيقه String  من 
            //serialize <<  String من داتا حقيقه ل 
            // // var Departments = JsonSerializer.Deserialize<List<Department>>(DepartmentsData);
            //Department من ال List بقوله اني عايز احولها ل 

            //عايز بقا اسمع الكلام ده ف الداتا بيز 
            // بس عشان مش كل مره اعل رن يدخل الداتا هتشسك م الاو لو فيخا داتا متدخلش لو مفهاش دخل

            if (!dbContext.Departments.Any())
            {
                var DepartmentsData = File.ReadAllText("F:\\Rout\\Entity framework\\session 3\\Demo 3 EF\\Data\\Data Seading\\departments.json");
                var Departments = JsonSerializer.Deserialize<List<Department>>(DepartmentsData);


                if (Departments?.Count > 0)
                {
                    foreach (var Department in Departments)
                    {
                        dbContext.Departments.Add(Department);
                    }
                    dbContext.SaveChanges();
                }

                //وافتح كونكشن main لازم اروح ف ال seed  عشان اعمله 


            }

            #endregion

            #region Employee
            //employees.json لازم ابعت الباث اللي موجود فيه ملف ال
            //employees.json < Data Seading < Data < Demo 3 EF هفتح الفولدر بتاع 

            // var EmployeesData = File.ReadAllText("F:\\Rout\\Entity framework\\session 3\\Demo 3 EF\\Data\\Data Seading\\employees.json");
            //عشان اعتبره داتا حقيقه Deserialize كده هو معتبر ان الباث ده شويه سترينج وبس ف انا هعملو حاجه اسمها
            //Deserialize << لداتا حقيقه String  من 
            //serialize <<  String من داتا حقيقه ل 
            // var Employee = JsonSerializer.Deserialize<List<Employee>>(EmployeesData);
            //Employee من ال List بقوله اني عايز احولها ل 

            if (!dbContext.Employees.Any())
            {
                var EmployeesData = File.ReadAllText("F:\\Rout\\Entity framework\\session 3\\Demo 3 EF\\Data\\Data Seading\\employees.json");
                var Employees = JsonSerializer.Deserialize<List<Employee>>(EmployeesData);


                if (Employees?.Count > 0)
                {
                    foreach (var employee in Employees)
                    {
                        dbContext.Employees.Add(employee);
                    }
                    dbContext.SaveChanges();
                }

            }
            #endregion

        }
    } 
}
