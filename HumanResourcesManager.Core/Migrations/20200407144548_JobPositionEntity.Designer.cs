﻿// <auto-generated />
using System;
using HumanResourcesManager.Core.DbDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HumanResourcesManager.Core.Migrations
{
    [DbContext(typeof(HumanResourceContext))]
    [Migration("20200407144548_JobPositionEntity")]
    partial class JobPositionEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HumanResourcesManager.Core.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ManagerEmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManagerEmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HumanResourcesManager.Core.Entities.EmployeeJobPosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PositionId");

                    b.ToTable("EmployeeJobPosition");
                });

            modelBuilder.Entity("HumanResourcesManager.Core.Entities.JobPosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PositionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobPosition");
                });

            modelBuilder.Entity("HumanResourcesManager.Core.Entities.Employee", b =>
                {
                    b.HasOne("HumanResourcesManager.Core.Entities.Employee", "ManagerEmployee")
                        .WithMany()
                        .HasForeignKey("ManagerEmployeeId");
                });

            modelBuilder.Entity("HumanResourcesManager.Core.Entities.EmployeeJobPosition", b =>
                {
                    b.HasOne("HumanResourcesManager.Core.Entities.Employee", "Employee")
                        .WithMany("Positions")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("HumanResourcesManager.Core.Entities.JobPosition", "Position")
                        .WithMany("EmployeeJobPositions")
                        .HasForeignKey("PositionId");
                });
#pragma warning restore 612, 618
        }
    }
}
