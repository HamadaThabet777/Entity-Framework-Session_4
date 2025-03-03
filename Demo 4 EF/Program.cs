using Demo_4_EF.Data.Model;
using Microsoft.EntityFrameworkCore.Internal;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace Demo_4_EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            using CompanyDbContext dbContext = new CompanyDbContext();

            #region Join[Inner Join] 


            //  Departmentو  Employee عندنا جدولين:
            //DepartmentId كل موظف مرتبط بقسم معين باستخدام .


            //var result = from D in dbContext.Departments
            //             join E in dbContext.Employees
            //             on D.DeptId equals E.DepartmentDeptId
            //             select new
            //             {
            //                 EmployeeID = E.Code,
            //                 EmployeeName = E.Name,
            //                 DepartmentId = D.DeptId,
            //                 DepartmentName = D.Name,

            //             };
            ////Foreach وعشان اعرض هستخدم
            //// انا عايز ارجع الموظفين والاقسام بتاعتهم
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"EmployeeName = {item.EmployeeName} Works on : {item.DepartmentName}");
            //}
            //..كل موظف في صف منفصل، مما يؤدي إلى تكرار الأقسام! 🚨
            //EmployeeName = Ahmed Works on : Sales
            //EmployeeName = Nadia Works on : Media
            //EmployeeName = Soha Works on : Markting
            //EmployeeName = Mazen Works on : Sales
            //EmployeeName = Sameh Works on : Media
            //EmployeeName = Pola Works on : Markting
            //---------------------------------------------
            //Fluent Syntax
            //  var result = dbContext.Departments.Join(dbContext.Employees,
            //D => D.DeptId,
            //E => E.DepartmentDeptId,
            //(Department, Employee) => new
            // {
            //    EmployeeID = Employee.Code,
            //    EmployeeName = Employee.Name,
            //    DepartmentId = Department.DeptId,
            //    DepartmentName = Department.Name,
            //});

            //  foreach (var item in result)
            //  {
            //      Console.WriteLine($"EmployeeName = {item.EmployeeName} Works on : {item.DepartmentName}");
            //  }
            #endregion

            #region Group Join
            //Group عادي وبعدين بعمل  Inner Join انا بعمل

            //Department و Employee لدينا جدول  
            //كل قسم يحتوي على مجموعة من الموظفين.
            //📌 نريد جلب كل قسم ومعه الموظفين المرتبطين به.

            //Department ع اساس ال Group هعمل 


            //Fluent Syntax
            //  var result = dbContext.Departments.GroupJoin(dbContext.Employees,
            //D => D.DeptId,//outer Key   //بتاعو الاول key حطيت ال Departments عشان بدات ب ال
            //E => E.DepartmentDeptId,//inner key
            //(Department, Employees) => new
            //{
            //    Department,
            //    Employees//غايز اعرض كل قسم والموظفين اللي جوا القسم ده
            //}).Where(X=>X.Employees.Count() > 0);// عملت دا عشان لو قسم فاضي ميعرضوش
            ////عشان اعرضهم هعرض الاقسام الاول بعدين الموظفين
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Department Name = {item.Department.Name}:");
            //    foreach (var employee in item.Employees)
            //    {
            //        Console.WriteLine($"Employees Name in this Department = {employee.Name}");
            //    }
            //}

            //Department Name = Sales:
            //Employees Name in this Department = Ahmed
            //Employees Name in this Department = Mazen
            //Department Name = Media:
            //Employees Name in this Department = Nadia
            //Employees Name in this Department = Sameh
            //Department Name = Markting:
            //Employees Name in this Department = Soha
            //Employees Name in this Department = Pola

            //query sentax
            //var result = (from D in dbContext.Departments
            //             join E in dbContext.Employees
            //             on D.DeptId equals E.DepartmentDeptId
            //             into Emp
            //             select new
            //             {

            //                 Department = D,
            //                 Employees = Emp

            //             }).Where(X => X.Employees.Count() > 0);
            ////عشان اعرضهم هعرض الاقسام الاول بعدين الموظفين
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Department Name = {item.Department.Name}:");
            //    foreach (var employee in item.Employees)
            //    {
            //        Console.WriteLine($"Employees Name in this Department = {employee.Name}");
            //    }
            //}

            //Department Name = Sales:
            //Employees Name in this Department = Ahmed
            //Employees Name in this Department = Mazen
            //Department Name = Media:
            //Employees Name in this Department = Nadia
            //Employees Name in this Department = Sameh
            //Department Name = Markting:
            //Employees Name in this Department = Soha
            //Employees Name in this Department = Pola


            //----------------------------------
            //Employees طب لو عايز اعمللها من نحيه ال
            // يعني الموظفين دول شغالين ف القسم الفلاني


            //Department ع اساس ال Group هعمل 


            //Fluent Syntax
            //  var result = dbContext.Employees.GroupJoin(dbContext.Departments,
            //E => E.DepartmentDeptId, //outer Key   //بتاعو الاول key حطيت ال Employees عشان بدات ب ال
            //D => D.DeptId,//inner key
            //(Employees , Department) => new
            //{
            //    Employees ,//غايز اعرض كل قسم والموظفين اللي جوا القسم ده
            //    Department
            //}).Where(X => X.Department.Count() > 0);// عملت دا عشان لو قسم فاضي ميعرضوش
            //  //عشان اعرضهم هعرض الاقسام الاول بعدين الموظفين
            //  foreach (var item in result)
            //  {
            //      Console.WriteLine($"Employees Name = {item.Employees.Name}");
            //      foreach (var Department in item.Department)
            //      {
            //      Console.WriteLine($"Department Name = {Department.Name}:");

            //      }
            //  }

            //Employees Name = Ahmed
            //Department Name = Sales:
            //Employees Name = Nadia
            //Department Name = Media:
            //Employees Name = Soha
            //Department Name = Markting:
            //Employees Name = Mazen
            //Department Name = Sales:
            //Employees Name = Sameh
            //Department Name = Media:
            //Employees Name = Pola
            //Department Name = Markting:


            //query sentax
            //var result = (from E in dbContext.Employees
            //              join D in dbContext.Departments
            //              on E.DepartmentDeptId equals D.DeptId
            //              into Dept
            //              select new
            //              {

            //                  Employees = E,
            //                  Department = Dept,


            //              }).Where(X => X.Department.Count() > 0);
            ////عشان اعرضهم هعرض الاقسام الاول بعدين الموظفين
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Employees Name = {item.Employees.Name}");
            //    foreach (var Department in item.Department)
            //    {
            //        Console.WriteLine($"Department Name = {Department.Name}:");

            //    }
            //}

            //Employees Name = Ahmed
            //Department Name = Sales:
            //Employees Name = Nadia
            //Department Name = Media:
            //Employees Name = Soha
            //Department Name = Markting:
            //Employees Name = Mazen
            //Department Name = Sales:
            //Employees Name = Sameh
            //Department Name = Media:
            //Employees Name = Pola
            //Department Name = Markting:
            #endregion

            #region Left Outer Join
            //او مفهاش employee سواء فيها  deaprtment يبقا كد هرجع كل حاجه ليها علاق ب ال deaprtment معناها اني مثلا بدات ب ال
            //Department ع اساس ال  هعمل 

            #region Example 1
            // Fluent Syntax
            //var result = dbContext.Departments.GroupJoin(dbContext.Employees,
            //D => D.DeptId,
            //E => E.DepartmentDeptId,
            //(Department, Employees) => new
            //{
            //    Department,
            //    Employees = Employees.DefaultIfEmpty()//عشان ارجع الاقسام اللي مفهاش مزظفين
            //}).SelectMany(X => X.Employees, (X, Employeeeee) => new { X.Department, Employeeeee });
            ////Department اعرض الداتا بتاع  left join دي بتاع ال
            ////عشان اعرضهم هعرض الاقسام الاول بعدين الموظفين
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Department := {item.Department.DeptId} | Name is {item.Department.Name} , Employee Name : {item.Employeeeee?.Name ?? "No Employee"}");
            //}

            // طلعلي كده 
            //Department Name = Sales: His Code is : 10
            //Department Name = Media: His Code is : 11
            //Department Name = Markting: His Code is : 12

            //طب هو ده اللي انا عايزو ؟ لاهو عارض الاقسام بس انا عايزو يعر ض كل قسم ومين الموظف اللي فيه وكده
            //Select many واكتب واخليها Select هعدل ف جمله ال
            // واعدل الجمله بتاتها اخليها 
            //SelectMany(X => X.Employees, (X, Employeeeee) =>new {X.Department, Employeeeee});
            //واعدل جمله العرض اخليها
            //Console.WriteLine($"Department := {item.Department.DeptId} | Name is {item.Department.Name} , Employee Name : {item.Employeeeee.Name}");


            //Department:= 10  | Name is Sales , Employee Name : Ahmed
            //Department := 11 | Name is Media , Employee Name : Nadia
            //Department := 12 | Name is Markting , Employee Name : Soha
            //Department := 10 | Name is Sales , Employee Name : Mazen
            //Department := 11 | Name is Media , Employee Name : Sameh
            //Department := 12 | Name is Markting , Employee Name : Pola 
            #endregion

            // طب عايزاجيب الموظفين اللي شغالين ف اقسم واللي مش شغالين ف اقسام
            //Employee هبدا بال

            #region Example 2
            // Fluent Syntax
            //var result = dbContext.Employees.GroupJoin(dbContext.Departments,
            //E => E.DepartmentDeptId,
            //D => D.DeptId,
            //(Employees,Department ) => new
            //{
            //    Employees,
            //   Department=Department.DefaultIfEmpty()// عشان ارجع الموظفين اللي شغالين ف اقسم واللي مش شغالين ف اقسام

            //}).SelectMany(D => D.Department, (X, Departmenttt) => new { X.Employees, Departmenttt });
            ////Department اعرض الداتا بتاع  left join دي بتاع ال
            ////عشان اعرضهم هعرض الاقسام الاول بعدين الموظفين
            //foreach (var item in result)
            //{
            //    Console.WriteLine($" Employee Name is {item.Employees.Name} , Department Name : {item.Departmenttt?.Name ?? "No Department"}");
            //}

            //Employee Name is Ahmed , Department Name : Sales
            //Employee Name is Nadia , Department Name : Media
            //Employee Name is Soha , Department Name : Markting
            //Employee Name is Mazen , Department Name : Sales
            //Employee Name is Sameh , Department Name : Media
            //Employee Name is Pola , Department Name : Markting
            #endregion
            #endregion

            #region Cross Join
            //real data مش بيجيب
            //cartizan product بيعمل دمج بين كل الصفوف من الجدول الأول مع كل الصفوف من الجدول الثاني .
            // Left Join او Inner في ال on مش بيكون فيه شرط للربط بين الجدولين(زي
            //كل صف في الجدول الأول هيندمج مع كل صف في الجدول الثاني، حتى لو مفيش علاقة بينهم.

            //Cross Join متى تستخدم الـ
            //✅ لو عايز تجرب كل الاحتمالات الممكنة بين مجموعتين من البيانات.
            //✅ في حالات تحليل البيانات، زي لو عندك منتجات و فئات وعايز تجرب كل منتج مع كل فئة.
            //✅ لو بتعمل عمليات حسابية، زي مقارنة كل موظف مع كل موظف آخر في نفس الشركة.

            // Query sentax
            //var result = from D in dbContext.Employees
            //             from E in dbContext.Departments // ✅ مفيش ON شرط، ده Cross Join
            //             select new
            //             {
            //                 Employee = E,
            //                 Departmen = D

            //             };

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Department: {item.Departmen.Name} - Employee: {item.Employee.Name}");
            //}

            //Fluent Syntax
            //var result = dbContext.Employees
            //.SelectMany(dept => dbContext.Departments, (emp, dept) => new
            //{
            //    EmployeeName = emp.Name,
            //    DepartmentName = dept.Name

            //});

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Department: {item.DepartmentName} - Employee: {item.EmployeeName}");
            //}

            #endregion

            #region View
            //2 table يعني عندي يعني اي View دلوقت انا عايز اعمل
            // عايز اخلي اليوزر يشفوف حاجه معينه م التابل مش التابل كلو 
            //sql! كنا بعملها ازاي في ال
            //كده
            //Create view EmployeeDepartment
            // with Encryption
            //as
            // select E.Code EmployeeId, E.Name EmployeeName, D.DeptId Department, D.DepartmentName DepartmentName
            //from Departments D , Employees E
            // where D.DeptId = E.DepartmentDeptId

            //ده بعمل view وكنت عشان امسح ال
            // drop view EmployeeDepartment
            //Add migraton ف الفيجوال مينفعش اعمل كده انا هعمل
            //dropهحط كود ال down هحط الكود ده وف كود ال up وف كود ال

            //بقا map طب عايز احول الكلام ده لتابل بقا اعملو
            #region Mapping View
            //عشان ارجع حاج م الداتا بيز محتاج افتح كوكشن الاول وان كد كد فاتحو فوق
            //EmployeeDepartment  هروح بقا اعملها كلاس بنفس اسم الفيو
            //  واحط جواه الحاجات اللي كانت هترجع م الفيو ده بنفس الاسامي بالظبط
            //EmployeeId, EmployeeName, Department,  DepartmentName
            //fluent api وعشان افهو ان دا فيو اعملها ف الdbset هزود CompanyDbContext وهزود جوا ال

            //var result = from item in dbContext.EmployeeDepartmentView
            //             select item;
            //foreach (var item in result.dbContext.EmployeeDepartmentView)
            //{
            //    Console.WriteLine($"{item.EmployeeName}--{item.DepartmentName}");
            //}

            //او اكتب الكود كلو مره واحده  
            //foreach (var item in dbContext.EmployeeDepartmentView)
            //{
            //    Console.WriteLine($"{item.EmployeeName}--{item.DepartmentName}");
            //}



            #endregion
            #endregion

            #region DataBse First
            //اول حاجه هاجي ع الباكج كونسول وهكتب شويه حاجات
            //1- Scaffold-DbContext -Connection"Server=.;DataBase= sqlاكتب هنا اسم الداتا بيز اللي ف ال ;Trusted_Connection=True;
            //TrustServerCertificate=True"محتاج نا احدد نوع البروفيدر اللي شغال عليه علي نوع الداتا بيز بتعتي اي
            //-Provider "Microsoft.EntityFrameworkCore.SqlServer"
            //عشان احدد التابل اللي عندي-Tables Product, Customers,Suppliers,Categories,Product "" بطو بينviewعشان احط "viwe Name"

            //Scaffold يعني بعمل داتا بيز فرست

            //1- Scaffold-DbContext -Connection"Server=.;DataBase= NorthWind;Trusted_Connection=True;TrustServerCertificate=True"-Provider "Microsoft.EntityFrameworkCore.SqlServer"-Tables Product, Customers,Suppliers,Categories,Product "ViewName"

            //DataBse First وفي اخر 3 فيديوهات ف سيشن 4 بتوع ال
            #endregion
        }
    }
}
  