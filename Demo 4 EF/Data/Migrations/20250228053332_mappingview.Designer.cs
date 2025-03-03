﻿// <auto-generated />
using System;
using Demo_4_EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Demo_4_EF.Data.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    [Migration("20250228053332_mappingview")]
    partial class mappingview
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Demo_4_EF.Data.Model.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Demo_4_EF.Data.Model.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeptId"), 10L);

                    b.Property<DateOnly>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("DepartmentName");

                    b.HasKey("DeptId");

                    b.HasIndex("ManagerId")
                        .IsUnique()
                        .HasFilter("[ManagerId] IS NOT NULL");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Demo_4_EF.Data.Model.Employee", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Code"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentDeptId")
                        .HasColumnType("int");

                    b.Property<string>("EmaliAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Code");

                    b.HasIndex("DepartmentDeptId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Demo_4_EF.Data.Model.EmployeeDepartmentView", b =>
                {
                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("EmployeeDepartmentView", (string)null);
                });

            modelBuilder.Entity("Demo_4_EF.Data.Model.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Demo_4_EF.Data.Model.StudentCourse", b =>
                {
                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.HasKey("StudentsId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("Demo_4_EF.Data.Model.Department", b =>
                {
                    b.HasOne("Demo_4_EF.Data.Model.Employee", "Manager")
                        .WithOne("ManageDepartment")
                        .HasForeignKey("Demo_4_EF.Data.Model.Department", "ManagerId");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Demo_4_EF.Data.Model.Employee", b =>
                {
                    b.HasOne("Demo_4_EF.Data.Model.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentDeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Demo_4_EF.Data.Model.StudentCourse", b =>
                {
                    b.HasOne("Demo_4_EF.Data.Model.Course", "Course")
                        .WithMany("StudentCourse")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demo_4_EF.Data.Model.Student", "Student")
                        .WithMany("StudentCourse")
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Demo_4_EF.Data.Model.Course", b =>
                {
                    b.Navigation("StudentCourse");
                });

            modelBuilder.Entity("Demo_4_EF.Data.Model.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Demo_4_EF.Data.Model.Employee", b =>
                {
                    b.Navigation("ManageDepartment")
                        .IsRequired();
                });

            modelBuilder.Entity("Demo_4_EF.Data.Model.Student", b =>
                {
                    b.Navigation("StudentCourse");
                });
#pragma warning restore 612, 618
        }
    }
}
