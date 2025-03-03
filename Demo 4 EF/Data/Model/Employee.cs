using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_4_EF.Data.Model
{
    // عندنا 4 طرق عشان نحول الكلاس دا ل تابل
    //1- By Convention [ defult ] >>defult يعني لومحددتش اني طريقه دي هتبقا ال
    //2- Data Anotation (set of attribute)
    //3- Fluent Fluent APIS (set of Methouds)
    //4- Configuration Classes

    public class Employee
    {
        #region Employee property

        //{EmployeeId ولاIdمش عايزو ولا يكون PKانا دلوقتي عايز اغير اسم ال
        //Data Anotation مش هتخليني اعرف اعمل حاجه زي دي ف هنلجأ لل By Conventionال
        //فوق السطر ده Data Anotation ولما اعوز اطبق حاجه ع سطر بحط الكلام ال

        //[Key]  // تحديد الـ Primary Key
        //(1.1)ع الكولم بتاعي بس شرط انو هيكون Identityلو عايز انزل
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]//(1.1)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//(1.1)
        public int Code { get; set; }
        //ncarchar(max)بيتحول ل  stringانت عارف ان ال
        //طب انا عايز اغيرو
        //واحدد عايز يتحول ل اي TypeNameطاالما عايز تغير ف داتا تايب بروح ع  الكولم ةاختاار
        //[Column(TypeName ="بحدد اسم الحاجه اللي عايز احول ليها")]

        //يعني اقصي واقل عدد حروف يدخلة min length ,maxlengthطب انا عايز اغير ال
        // [StringLength(بحدد اكبر عدد يدخلو , MinimumLength = بحدد اقل عدد يدخلو)]
        //مش هتتخزن ف الداتا بيز website تبع ال validation بس دي تبع ال MinimumLength انا معنديش حاجه ف الداتا بيظ اسمها
        [Column(TypeName = "Varchar")]
        [StringLength(50, MinimumLength = 10)]
        public string? Name { get; set; }

        //decimal انا عايز اخليه يتخزن ف الداتا بيز ك  double السالري بتاعي هنا
        //واحدد عايز يتحول ل اي TypeNameطاالما عايز تغير ف داتا تايب بروح ع  الكولم ةاختاار
        [Column(TypeName = "decimal(12,2)")]// هيتخزن 12 رقم و رقمين بعد العلامه
        public double Salary { get; set; }
        //اكبر من 22 واصغر من 30Age مثلا عايز اخلي ال
        //Range صح ف هستخدم range انا هنا بتكلم ف 
        //[Range (الحد الاقصي, الحد الادني)]

        //not alowwedاقل من 22  alowwed يعني مثلا من 22 ل 30 values allow لو عايز يكون عندي 
        //[AllowedValues(عندي alowwed بحدد الحاجات ال)]

        //not alowwed لو عايز احدد داتا متكونش متاحه معايا
        //[DeniedValues(متاح معايا من كام ل كام)]
        //مش هتتخزن ف الداتا بيز website تبع ال validation ودا طبعا مش هيتخزن ف داتا بيز كل ده 

        [Range(22, 30)]//الرينج بتاعي من كام ل كام
        [AllowedValues(22, 23, 24, 25, 26, 27, 28, 29, 30)]//الداتا المتاح معايا اي
        [DeniedValues(10, 15)]//الداتا اللي مش متاحه ايه
        //طبعا انا مش بحط التلاته انا بحط واحده منهم بس
        public int? Age { get; set; }
        //وعايز اعرف الداتا بيز ان دا ايميل مهي متعرفش حاجه اسمها ايميل هي بتعتبره سترينج EmaliAddress طب عندي
        //[EmailAddress]  // يتحقق من أن القيمة بريد إلكتروني صحيح
        //او 
        //[DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? EmaliAddress { get; set; }
        //وعايز اعرف الداتا بيز ان دا رقم تليفون مهي متعرفش حاجه اسمها تليفون هي بتعتبره سترينج PhoneNumber طب عندي
        //[Phone]  // يتحقق من صحة رقم الهاتف
        //او
        //[DataType(DataType.PhoneNumber)]

        [Phone]
        public string? PhoneNumber { get; set; }
        //وعايز اعرف الداتا بيز ان دا باسورد مهي متعرفش حاجه اسمها باسورد هي بتعتبره سترينج Password طب عندي
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        //ميتخزنش ف الداتا بيز websiteبس يكون تبع ال property طب انا عابز احط 
        //[NotMapped]//معناه مش هيتحول ل داتا بيز 
        [NotMapped]
        public double NetSalary { get; set; }

        #endregion

        #region navigational property
        #region work علاقه ال
        //واحد department الواحد شغال في Employee ال
        //department ف هعملها ف كلاس ال department واحد بس دي من نحيه ال Employee الواحد شغال فيه اكتر من department ال

        //one 
        //public Department Department { get; set;  }
        //many عشان امثل العلاقه ال department اروح بقا ل كلاس ال
        //لسا forgin keyمعملتش ال relation بس خلي بالك انا كده عملت ال 

        //بتاعو  PK بيكون اسم الكلاس وجمبو ال forgin key عشان اعمل
        //Department بتاعة ال forgin key هحط ال Employee انا هنا ف ال
        //public int DepartmentDeptId { get; set; }
        // ------------
        [ForeignKey(nameof(Department))]
        public int DepartmentDeptId { get; set; }

        [InverseProperty(nameof(Model.Department.Employees))]
        public virtual Department Department { get; set; }


        #endregion

        #region Manage علاقه ال

        [InverseProperty(nameof(Model.Department.Manager))]
        public virtual Department ManageDepartment { get; set; }




        #endregion

        #region خلاصه الريليشن
        //Department خاصه ب كلاس ال Department الريليشن اسمها
        //Employee واسمها اسم الريليشن Employee مرتبطه ب كلاس ال
        //||<<  واعرف فوقيها انها مرتبطه ب الريليشن التانيه Department يبق هاجي ع ريليشن ال
        // [InverseProperty(nameof(Model.Department.Employees))]
        //public Department Department { get; set; }

        //----

        //||<<  واعرف فوقيها انها مرتبطه ب الريليشن التانيه Employees  وهاجي ع ريليشن ال
        //[InverseProperty(nameof(Model.Employee.Department))]
        //public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        //-----------------------

        //Department خاصه ب كلاس ال ManageDepartment الريليشن اسمها
        //Manager واسمها اسم الريليشن Employee مرتبطه ب كلاس ال
        //||<<  واعرف فوقيها انها مرتبطه ب الريليشن التانيه ManageDepartment يبق هاجي ع ريليشن ال

        // [InverseProperty(nameof(Model.Department.Manager))]
        // public Department ManageDepartment { get; set; }

        //----

        //||<<  واعرف فوقيها انها مرتبطه ب الريليشن التانيه Manager  وهاجي ع ريليشن ال
        // [InverseProperty(nameof(Model.Employee.ManageDepartment))]
        //public Employee Manager { get; set; }

        //-----------------------

        //forgin keyخلصنا ال الريليشن نجي نشوف 
        // Department لازم اقول ده تبع اني ريليشن هو تبع ريليشن الDepartmentDeptId اسمو forgin key عندي
        //ومرتبط ب مين forgin key هاجي فوقيه واعرف ال
        // [ForeignKey(nameof(Department))]
        // public int DepartmentDeptId { get; set; }

        //----

        // Manager لازم اقول ده تبع اني ريليشن هو تبع ريليشن ManagerId اسمو forgin key عندي
        //ومرتبط ب مين forgin key هاجي فوقيه واعرف ال

        //[ForeignKey(nameof(Manager))]
        //public int? ManagerId { get; set; } 
        #endregion

        #endregion

        //---------------------------------

        


    }
}
