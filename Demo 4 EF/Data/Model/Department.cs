using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_4_EF.Data.Model
{
    public class Department
    {
        #region Department property
        public int DeptId { get; set; }
        public string Name { get; set; }
        public DateOnly CreationDate { get; set; }
        #endregion

        #region navigational property
        #region work علاقه ال
        //واحد department الواحد شغال في Employee ال
        //department دي عملتها ف كلاس  ال 

        //department ف هعملها ف كلاس ال department واحد بس دي من نحيه ال Employee الواحد شغال فيه اكتر من department ال

        //many 
        // كتار ف عايز اسقبلهم ف حاجه كبيره تشيلهم كلها Employeesبس هنا دول
        //HashSet<> واسقبلهم ف  ICollection<> ف احسن حاجه اني احطهم ف  

        [InverseProperty(nameof(Model.Employee.Department))]

        public virtual ICollection <Employee> Employees { get; set; } = new HashSet<Employee>();

        //many خلاص كده انا عملت العلاقه ال
        //Add-migration "OneToManyRelation" هروح ع الباكدج كونسول واعمل
        //لسا forgin keyمعملتش ال relation بس خلي بالك انا كده عملت ال 

        // في حته مهمه بقا ان  لو عملت الريلايشن  ف الاتنين هتسمع
        //one to many هتسمع برضو ان كل دول  ال Employee  ان  لو عملتها ف ال
        //one to many هتسمع برضو ان كل دول Department لو عملتها ف ال
        //الريلايشن لو عملتها ف الاتنبن هتسمع

        #endregion

        #region Manage علاقه ال

        [ForeignKey(nameof(Manager))]
        public int? ManagerId { get; set; }


        [InverseProperty(nameof(Model.Employee.ManageDepartment))]
        public virtual Employee Manager { get; set; }

        //هوو هيرعف منين دي بتاع اي ودي بتاع اي؟ Employee الكلام ده عمرو م يسمع ف الداتا بيز انا دلوقتي عندي علاقتين بتوع
        //علاقه عكسيه يعني هقف فوق كل ريلايشن واقولها انتي تبع مينinverse property هعمل حاجه اسمها
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
    }

}
