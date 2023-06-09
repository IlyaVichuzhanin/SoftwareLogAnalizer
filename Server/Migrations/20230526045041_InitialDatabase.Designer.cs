﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SoftwareLogAnalizer.Server;

#nullable disable

namespace SoftwareLogAnalizer.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230526045041_InitialDatabase")]
    partial class InitialDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeType")
                        .HasColumnType("integer");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ResourceID")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ResourceID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.PetexPrimaryLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsLog")
                        .HasColumnType("boolean");

                    b.Property<string>("LogInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LogIsStructurated")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("PetexPrimaryLogs");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ProjectResourceId")
                        .HasColumnType("integer");

                    b.Property<int>("ResourceCategory")
                        .HasColumnType("integer");

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ResourceType")
                        .HasColumnType("integer");

                    b.Property<int>("ResourceUsageState")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LogInDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LogOutDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("SessionIsFinished")
                        .HasColumnType("boolean");

                    b.Property<int>("SoftwareId")
                        .HasColumnType("integer");

                    b.Property<int>("SoftwareModuleId")
                        .HasColumnType("integer");

                    b.Property<int>("SoftwareUserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SoftwareId");

                    b.HasIndex("SoftwareModuleId");

                    b.HasIndex("SoftwareUserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.Software", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("SoftwareName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Softwares");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.SoftwareModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ResourceID")
                        .HasColumnType("integer");

                    b.Property<int>("SoftwareId")
                        .HasColumnType("integer");

                    b.Property<string>("SoftwareModuleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ResourceID");

                    b.HasIndex("SoftwareId");

                    b.ToTable("SoftwareModules");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.SoftwareUser", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("ComputerUserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<string>("WindowsUserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("SoftwareUsers");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.StructuredLog", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<bool?>("ErrorLog")
                        .HasColumnType("boolean");

                    b.Property<bool?>("LogIsMatched")
                        .HasColumnType("boolean");

                    b.Property<int>("Operation")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OperationDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("SoftwareId")
                        .HasColumnType("integer");

                    b.Property<int?>("SoftwareModuleId")
                        .HasColumnType("integer");

                    b.Property<int?>("SoftwareUserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SoftwareId");

                    b.HasIndex("SoftwareModuleId");

                    b.HasIndex("SoftwareUserId");

                    b.ToTable("StructuredLogs");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.tNavPrimaryLog", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<string>("ComputerUserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Feature")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("IsLog")
                        .HasColumnType("boolean");

                    b.Property<bool?>("LogIsStructurated")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OperationDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("OperationType")
                        .HasColumnType("integer");

                    b.Property<int?>("ReturnedId")
                        .HasColumnType("integer");

                    b.Property<long?>("TNavLogID")
                        .HasColumnType("bigint");

                    b.Property<string>("WindowsUserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("tNavPrimaryLogs");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.Employee", b =>
                {
                    b.HasOne("SoftwareLogAnalizer.Shared.Model.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftwareLogAnalizer.Shared.Model.Resource", "Resource")
                        .WithMany("Employees")
                        .HasForeignKey("ResourceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.Session", b =>
                {
                    b.HasOne("SoftwareLogAnalizer.Shared.Model.Employee", "Employee")
                        .WithMany("Sessions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftwareLogAnalizer.Shared.Model.Software", "Software")
                        .WithMany("Sessions")
                        .HasForeignKey("SoftwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftwareLogAnalizer.Shared.Model.SoftwareModule", "SoftwareModule")
                        .WithMany("Sessions")
                        .HasForeignKey("SoftwareModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftwareLogAnalizer.Shared.Model.SoftwareUser", "SoftwareUser")
                        .WithMany("Sessions")
                        .HasForeignKey("SoftwareUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Software");

                    b.Navigation("SoftwareModule");

                    b.Navigation("SoftwareUser");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.SoftwareModule", b =>
                {
                    b.HasOne("SoftwareLogAnalizer.Shared.Model.Resource", "Resource")
                        .WithMany("SoftwareModules")
                        .HasForeignKey("ResourceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftwareLogAnalizer.Shared.Model.Software", "Software")
                        .WithMany("SoftwareModules")
                        .HasForeignKey("SoftwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");

                    b.Navigation("Software");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.SoftwareUser", b =>
                {
                    b.HasOne("SoftwareLogAnalizer.Shared.Model.Employee", "Employee")
                        .WithMany("SoftwareUsers")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.StructuredLog", b =>
                {
                    b.HasOne("SoftwareLogAnalizer.Shared.Model.Employee", "Employee")
                        .WithMany("StructuredLogs")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("SoftwareLogAnalizer.Shared.Model.Software", "Software")
                        .WithMany("StructuredLogs")
                        .HasForeignKey("SoftwareId");

                    b.HasOne("SoftwareLogAnalizer.Shared.Model.SoftwareModule", "SoftwareModule")
                        .WithMany("StructuredLogs")
                        .HasForeignKey("SoftwareModuleId");

                    b.HasOne("SoftwareLogAnalizer.Shared.Model.SoftwareUser", "SoftwareUser")
                        .WithMany("StructuredLogs")
                        .HasForeignKey("SoftwareUserId");

                    b.Navigation("Employee");

                    b.Navigation("Software");

                    b.Navigation("SoftwareModule");

                    b.Navigation("SoftwareUser");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.Company", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.Employee", b =>
                {
                    b.Navigation("Sessions");

                    b.Navigation("SoftwareUsers");

                    b.Navigation("StructuredLogs");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.Resource", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("SoftwareModules");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.Software", b =>
                {
                    b.Navigation("Sessions");

                    b.Navigation("SoftwareModules");

                    b.Navigation("StructuredLogs");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.SoftwareModule", b =>
                {
                    b.Navigation("Sessions");

                    b.Navigation("StructuredLogs");
                });

            modelBuilder.Entity("SoftwareLogAnalizer.Shared.Model.SoftwareUser", b =>
                {
                    b.Navigation("Sessions");

                    b.Navigation("StructuredLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
