using Demo_4_EF.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_4_EF.Data.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            //builder
            //        .Property<string>("Adress")
            //        .HasColumnType("varchar")//varchar عايز اعرضها ف الداتا بيز ع هيئه
            //        .HasMaxLength(50)//اقصي حاجه تدخلها 50
            //        .IsRequired();//null يعني ضروري تدخل ومينفعش تشيلIsRequired
        }
    }
}
