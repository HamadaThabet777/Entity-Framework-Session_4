using Microsoft.EntityFrameworkCore;
using Demo_4_EF.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_4_EF.Data.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Department> builder)
        {
            builder
                    .HasKey(D => D.DeptId);//PK بحدد ان دا هو ال
                                           //---------------
            builder
                .Property(D => D.DeptId).UseIdentityColumn(10, 1);
            //---------------
            //name عايز اعمل شويه تعديلات ع كولوم ال
            //name واحدد منها الحاجه بتعتي ال هي property لازم اقف ع ال

            builder
                .Property(D => D.Name)
                    //DepartmentName خليه Name عايز اغير اسم التابل جوا الداتا بيز بدل 
                    .HasColumnName("DepartmentName")
                    //varchar عايز اعرضها ف الداتا بيز ع هيئه
                    .HasColumnType("varchar")
                    //اقصي حاجه تدخلها 50 MaxLength عايز احدد ال
                    .HasMaxLength(50)
                    //null يعني ضروري تدخل ومينفعش تشيلIsRequired
                    .IsRequired();
            //---------------
            //date لل defult value  عايز احط 
            // .HasDefaultValueSql("GETDATE()") هعملها باستخدام 

            builder
                .Property(D => D.CreationDate)
                        .HasDefaultValueSql("GETDATE()");

        }
    }
}
