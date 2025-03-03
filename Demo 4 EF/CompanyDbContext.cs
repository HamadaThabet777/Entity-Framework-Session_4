using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Demo_4_EF.Data.Model;

namespace Demo_4_EF
{
    internal class CompanyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= .;Database= CompanyG04session3;Trusted_Connection= true;trustservercertificate= true");
            optionsBuilder.UseLazyLoadingProxies();
        }


        public DbSet<Employee> Employees { get; set; }
        // السطر دا معاناه انا بحدد الكلاس اللي عايز احولو ل تبل ف الداتا بيز
        // public DbSet<Department> Departments { get; set; }

        //------------

        //update database وaddmigrationواعملCompanyDbContext و  بتعتو من هنا م ال  DbSetلا همسح ال Remove-migrationلو في تابل غلطت فيه وعايز امسحو مش هعمل 

        //Fluent APIS

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //لو انا معايا السورس كود 
            #region Employee

            //modelBuilder.Entity<Employee>()
            //        .Property<string>("Adress")
            //        .HasColumnType("varchar")//varchar عايز اعرضها ف الداتا بيز ع هيئه
            //        .HasMaxLength(50)//اقصي حاجه تدخلها 50
            //        .IsRequired();//null يعني ضروري تدخل ومينفعش تشيلIsRequired

            #endregion

            //كل الكلام دا لو انا معايا السورس كود 
            //refrence طب لو مش معايا وهاخد منو

            #region Department

            // يعني مش هيرنlibrary  البروجكت بتاعي هيكونrefrence عشان اخد 
            // مش هيرنlibrary للابليكشن اللي هو built بس لازم عشان يظهر اكون عامل اللي هي 
            //bulit وبعد اي تعدل اعمل public وكمان لازم الكلاس بتاعي يكون 
            // ولو كنت ضايفو وعدلت عليه هسمحو واضيفه م الاول تاني
            //browseواعمل add projct refernce وكلك يمين وDependacies هاجي عند ال refrence عشان اضيف 
            //bin>debug>.net8 واختاره
            //وهلاقيه assembiliy << Dependacies عشان اتاكد ان الفايل موجود هاجي ع ال
            //depset عشان استخدمه بقا هعمله


            //modelBuilder.Entity<Department>()
            //        .HasKey(D => D.DeptId);//PK بحدد ان دا هو ال
            ////---------------
            ////بتعتو واخليه انو يبدا من 10 ويزيد1 identity  طب عايز اغير ال
            ////DeptId واحدد منها الحاجه بتعتي ال هي property لازم اقف ع ال
            ////UseIdentityColumn ومنها اختار 
            //modelBuilder.Entity<Department>()
            //    .Property(D => D.DeptId).UseIdentityColumn(10, 1);
            ////---------------
            ////name عايز اعمل شويه تعديلات ع كولوم ال
            ////name واحدد منها الحاجه بتعتي ال هي property لازم اقف ع ال

            //modelBuilder.Entity<Department>()
            //        .Property(D=>D.Name)
            //        //DepartmentName خليه Name عايز اغير اسم التابل جوا الداتا بيز بدل 
            //        .HasColumnName("DepartmentName")
            //        //varchar عايز اعرضها ف الداتا بيز ع هيئه
            //        .HasColumnType("varchar")
            //        //اقصي حاجه تدخلها 50 MaxLength عايز احدد ال
            //        .HasMaxLength(50)
            //        //null يعني ضروري تدخل ومينفعش تشيلIsRequired
            //        .IsRequired();
            ////---------------
            ////date لل defult value  عايز احط 
            //// .HasDefaultValueSql("GETDATE()") هعملها باستخدام 

            //modelBuilder.Entity<Department>()
            //            .Property(D => D.CreationDate)
            //            .HasDefaultValueSql("GETDATE()");

            //DepartmentConfiguration هعملم كومنت عشان حطيتهم ف كلاس ال
            //خلاص خلصت كده ؟ متاكد ؟ اه 
            //Add-migration خلاص هيروح افتح الباكدج كونسول واعمل

            #endregion


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //هياخدها معاها  Configurationsاناا بكتب السطر دا ومعناه ان اي حاجه عندي فيها
            //بكتبو ونا بعمل الكونكشن اول مره

            // -------------------------------------------------
            //StudentCourse هعمل هنا العلاقه بتاع ال
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new
                {

                    sc.StudentsId,
                    sc.CourseId
                });

            //Fluent APIS  بال composit key  كده خلاص بقا عملت ال
            //migration هعمل بقا ال


            //view -----------------------------
            modelBuilder.Entity<EmployeeDepartmentView>()
                .ToView("EmployeeDepartmentView")
                .HasNoKey();
    
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeDepartmentView> EmployeeDepartmentView { get; set; }


        #region Fluent APIS
        // ادامي طريقين اما يكون معايا السورس كود اللي هو الكود نفسه 
        // اما مش معايا ومبعوتلي ريفرينس منه

        //CompanyDbContext بتشتغل جوا الفايل بتاع ال Fluent APIS 
        //OnModelCreating أسمها mehtoud علي  override هعمل 
        //وهمسح السطر بتاعها واكتب
        // modelBuilder.Entity<Employee اللي عايز اشتغل عليها وهي الكلاسات اللي عندي ف هشتغل ع  Entityبحدد هنا اسم ال>()
        //اللي عايز اشتغل عليها واحدد الداتا تايب Propertyعندي 3 طرق عشان احدد ال
        //      1-  .Property<string>("address اكتب هنا اسمها مثلا")
        //    اليلي عايز اعمل عليها حاجهProperty ومنها احدد الكلاس واعمل. واختار الnameofاما اختار 
        //      2-  .Property(nameof(Employee.Salary)
        //       lamda expresson اما اشتغل ب ال
        //    اليلي عايز اعمل عليها حاجهProperty ومنها احدد الكلاس واعمل. واختار ال 
        //      3-  .Property(E=>E.Salary)

        //الطريقه التانيه والتالته مش بتسمحلي احط حاجه مش عندب عكس الاولي بتسمح ب كده

        //modelBuilder.Entity<Employee>()
        //        .Property<string>("Adress")
        //        .HasColumnType("varchar")//varchar عايز اعرضها ف الداتا بيز ع هيئه
        //        .HasMaxLength(50)//اقصي حاجه تدخلها 50
        //        .IsRequired();//null يعني ضروري تدخل ومينفعش تشيلIsRequired

        //كل الكلام دا لو انا معايا السورس كود 
        //refrence طب لو مش معايا وهاخد منو


        // يعني مش هيرنlibrary  البروجكت بتاعي هيكونrefrence عشان اخد 
        // مش هيرنlibrary للابليكشن اللي هو built بس لازم عشان يظهر اكون عامل اللي هي 
        //bulit وبعد اي تعدل اعمل public وكمان لازم الكلاس بتاعي يكون 
        // ولو كنت ضايفو وعدلت عليه هسمحو واضيفه م الاول تاني
        //browseواعمل add projct refernce وكلك يمين وDependacies هاجي عند ال refrence عشان اضيف 
        //bin>debug>.net8 واختاره
        //وهلاقيه assembiliy << Dependacies عشان اتاكد ان الفايل موجود هاجي ع ال
        //depset عشان استخدمه بقا هعمله


        //modelBuilder.Entity<Department>()
        //       .HasKey(D => D.DeptId);//PK بحدد ان دا هو ال
        //---------------
        //بتعتو واخليه انو يبدا من 10 ويزيد1 identity  طب عايز اغير ال
        //DeptId واحدد منها الحاجه بتعتي ال هي property لازم اقف ع ال
        //UseIdentityColumn ومنها اختار 
        // modelBuilder.Entity<Department>()
        //     .Property(D => D.DeptId).UseIdentityColumn(10, 1);
        //---------------
        //---------------
        //name عايز اعمل شويه تعديلات ع كولوم ال
        //name واحدد منها الحاجه بتعتي ال هي property لازم اقف ع ال

        //modelBuilder.Entity<Department>()
        //            .Property(D=>D.Name)
        //            //DepartmentName خليه Name عايز اغير اسم التابل جوا الداتا بيز بدل 
        //            .HasColumnName("DepartmentName")
        //            //varchar عايز اعرضها ف الداتا بيز ع هيئه
        //            .HasColumnType("varchar")
        //            //اقصي حاجه تدخلها 50 MaxLength عايز احدد ال
        //            .HasMaxLength(50)
        //            //null يعني ضروري تدخل ومينفعش تشيلIsRequired
        //            .IsRequired();
        //---------------
        //date لل defult value  عايز احط 
        // .HasDefaultValueSql("GETDATE()") هعملها باستخدام 

        //modelBuilder.Entity<Department>()
        //                .Property(D => D.CreationDate)
        //                .HasDefaultValueSql("GETDATE()");

        //خلاص خلصت كده ؟ متاكد ؟ اه 
        //Add-migration خلاص هيروح افتح الباكدج كونسول واعمل

        #endregion

        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Students { get; set; }




    }
}
