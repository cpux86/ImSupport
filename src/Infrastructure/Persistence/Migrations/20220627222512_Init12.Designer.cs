﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(CaseContext))]
    [Migration("20220627222512_Init12")]
    partial class Init12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("Domain.Models.Case", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<string>("CaseManager")
                        .HasColumnType("TEXT");

                    b.Property<byte>("CaseStatusCode")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Status");

                    b.Property<string>("Client")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ClientOfficeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DeviceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Master")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.Property<string>("WorksList")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientOfficeId");

                    b.HasIndex("DeviceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("Domain.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Companys");
                });

            modelBuilder.Entity("Domain.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OfficeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Domain.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("OfficeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("OfficeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Domain.Models.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("Domain.Models.WorksList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("WorksList");
                });

            modelBuilder.Entity("Domain.Models.Case", b =>
                {
                    b.HasOne("Domain.Models.Office", "ClientOffice")
                        .WithMany()
                        .HasForeignKey("ClientOfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Device", "Device")
                        .WithMany("Cases")
                        .HasForeignKey("DeviceId");

                    b.HasOne("Domain.Models.Office", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientOffice");

                    b.Navigation("Device");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Domain.Models.Device", b =>
                {
                    b.HasOne("Domain.Models.Office", "Office")
                        .WithMany("Devices")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("Domain.Models.Employee", b =>
                {
                    b.HasOne("Domain.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Models.Office", null)
                        .WithMany("Employees")
                        .HasForeignKey("OfficeId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.Models.Office", b =>
                {
                    b.HasOne("Domain.Models.Company", "Company")
                        .WithMany("Offices")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.Models.Company", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Offices");
                });

            modelBuilder.Entity("Domain.Models.Device", b =>
                {
                    b.Navigation("Cases");
                });

            modelBuilder.Entity("Domain.Models.Office", b =>
                {
                    b.Navigation("Devices");

                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}