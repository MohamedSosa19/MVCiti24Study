﻿// <auto-generated />
using System;
using MVCiti24.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCiti24.Migrations
{
    [DbContext(typeof(ITIContectDB))]
    [Migration("20241104091429_Update4")]
    partial class Update4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DepartmentInstructor", b =>
                {
                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorsId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId", "InstructorsId");

                    b.HasIndex("InstructorsId");

                    b.ToTable("DepartmentInstructor");
                });

            modelBuilder.Entity("MVCiti24.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CrsResultsId")
                        .HasColumnType("int");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("Hour")
                        .HasColumnType("int");

                    b.Property<int>("MinDegree")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CrsResultsId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("MVCiti24.Models.CrsResults", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int?>("TraineeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CrsResults");
                });

            modelBuilder.Entity("MVCiti24.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Manager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MVCiti24.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("MVCiti24.Models.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CrsResultsId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CrsResultsId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("DepartmentInstructor", b =>
                {
                    b.HasOne("MVCiti24.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCiti24.Models.Instructor", null)
                        .WithMany()
                        .HasForeignKey("InstructorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCiti24.Models.Course", b =>
                {
                    b.HasOne("MVCiti24.Models.CrsResults", "CrsResults")
                        .WithMany("Courses")
                        .HasForeignKey("CrsResultsId");

                    b.HasOne("MVCiti24.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("CrsResults");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVCiti24.Models.Instructor", b =>
                {
                    b.HasOne("MVCiti24.Models.Course", "Course")
                        .WithMany("Instructors")
                        .HasForeignKey("CourseId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("MVCiti24.Models.Trainee", b =>
                {
                    b.HasOne("MVCiti24.Models.CrsResults", "CrsResults")
                        .WithMany("Trainees")
                        .HasForeignKey("CrsResultsId");

                    b.HasOne("MVCiti24.Models.Department", "Department")
                        .WithMany("Trainees")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("CrsResults");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVCiti24.Models.Course", b =>
                {
                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("MVCiti24.Models.CrsResults", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("MVCiti24.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Trainees");
                });
#pragma warning restore 612, 618
        }
    }
}
