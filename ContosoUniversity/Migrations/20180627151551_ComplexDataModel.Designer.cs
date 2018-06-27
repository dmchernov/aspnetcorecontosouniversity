﻿// <auto-generated />
using System;
using ContosoUniversity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContosoUniversity.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20180627151551_ComplexDataModel")]
    partial class ComplexDataModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContosoUniversity.Models.Course", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("Credits");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("CourseId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("ContosoUniversity.Models.CourseAssignment", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("InstructorId");

                    b.HasKey("CourseId", "InstructorId");

                    b.HasIndex("InstructorId");

                    b.ToTable("CourseAssignment");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<int?>("InstructorId");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<DateTime>("StartDate");

                    b.HasKey("DepartmentId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<int?>("Grade");

                    b.Property<int>("StudentId");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasMaxLength(50);

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("ContosoUniversity.Models.OfficeAssignment", b =>
                {
                    b.Property<int>("InstructorId");

                    b.Property<string>("Location")
                        .HasMaxLength(50);

                    b.HasKey("InstructorId");

                    b.ToTable("OfficeAssignment");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Course", b =>
                {
                    b.HasOne("ContosoUniversity.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ContosoUniversity.Models.CourseAssignment", b =>
                {
                    b.HasOne("ContosoUniversity.Models.Course", "Course")
                        .WithMany("CourseAssignments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ContosoUniversity.Models.Instructor", "Instructor")
                        .WithMany("CourseAssignments")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ContosoUniversity.Models.Department", b =>
                {
                    b.HasOne("ContosoUniversity.Models.Instructor", "Administrator")
                        .WithMany()
                        .HasForeignKey("InstructorId");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Enrollment", b =>
                {
                    b.HasOne("ContosoUniversity.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ContosoUniversity.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ContosoUniversity.Models.OfficeAssignment", b =>
                {
                    b.HasOne("ContosoUniversity.Models.Instructor", "Instructor")
                        .WithOne("OfficeAssignment")
                        .HasForeignKey("ContosoUniversity.Models.OfficeAssignment", "InstructorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
