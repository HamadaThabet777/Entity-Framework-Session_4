using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_4_EF.Data.Model
{
    public class StudentCourse
    {
        [ForeignKey(nameof(Student))]//Student دا تبع العلاقه اللي اسمها
        public int StudentsId { get; set; }

        [ForeignKey(nameof(Course))]//Course دا تبع العلاقه اللي اسمها

        public int CourseId { get; set; }
        public int Grade { get; set; }

        //هنا navigational property ده دلووقتي التابل اللي هيمثلي الريليشن ف هعمل ال
        // وهكسر الريليشن !! يعني اي؟؟
        //لوحده Course لوحده ومع ال Student هيتعامل مع ال StudentCourse يعني ال
    
        public virtual Student Student { get; set; }
        //navigational property => one (Student) << Student وبين الStudentCourse بين ال

        public virtual Course Course { get; set; }
        //navigational property => one (Course) << Course وبين الStudentCourse بين ال

        // محتاج بقا ارجع اعمل الريليشن دي ف الكلاسات

        //-----------------------------
        //PK طب مش دا تابل ؟ اه ومش هيتمثل ف الداتا بيز ؟ اه امال فين ال

        //OnModelCreating جوا ال CompanyDbContext مبتشتغلش غير جوا ال Fluent APIS وطبعا ال Fluent APIS مش هعرف اعملو غير ب ال

        //    modelBuilder.Entity<StudentCourse>()
        //            .HasKey(sc => new
        //            {

        //                sc.StudentsId,
        //                sc.CourseId
        //});

        //Fluent APIS  بال composit key  كده خلاص بقا عملت ال
        //migration هعمل بقا ال

    }
}
