using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_4_EF.Data.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //Course وكلاس ال Student دلوقتي عملت كلاس ال
        //Stud_Course وفي علاقه بينهم اسمها
        //يعني الطلاب بيسجلو ف كوسات كتير والكورسات بيسجهلها طلاب كتير
        //many to many  العلاقه
        //هل هعملها كلاس لوحدها؟؟؟؟؟؟؟ لا انا مش هعمل كده امال هعمل اي ؟
        // تشيل الاتننين ICollection هعمل
        //Studentبتاع ال ICollection هحط ال Course ف كلاس ال
        //Courseبتاع ال ICollection هحط ال Student وف كلاس ال
        ////public ICollection<Student> Students { get; set; }=new HashSet<Student>();

        // -----------
        //هروح اضيفها واجي CompanyDbContext ااه نسينا نضيفها ف ال
        //migration اعمل بقا 
        //CourseId , StudentsId وحطيتلي جواه  CourseStudent عملتلي تابل جديد اسمو migration دلوقتي ال

        //اللي كانت بتبقي فوق الريليشن ف الداتا بيز grade طب افرض انا دلوقتي عندي علاقه اللي اسها 
        // CourseStudent لو تفتكر كنا بنحطها فين ؟ ف الكلاس اللي اسمو
        // ?? جواه grade طب هو انا اصلا عندي التابل ده عشان امثل ال
        //دي وهعمل انا الكلاس ب ايدي migration لا مش عندي عشان كده هممسح ال

        //-------------
        ////public ICollection<Student> Students { get; set; }=new HashSet<Student>();
        //دي كده انا هلغيها عشان انا هعملها م الاول 

        public virtual ICollection<StudentCourse> StudentCourse { get; set; } = new HashSet<StudentCourse>();





    }
}
