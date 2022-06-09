﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(CaseContext))]
    [Migration("20220609192901_Init7")]
    partial class Init7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("AppCore.Models.Case", b =>
                {
                    b.Property<int>("CaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<byte>("CaseStatusCode")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Status");

                    b.Property<string>("Client")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DeviceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Executor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.HasKey("CaseId");

                    b.HasIndex("DeviceId");

                    b.HasIndex("LocationId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("AppCore.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("AppCore.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("AppCore.Models.TypeOfWork", b =>
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

                    b.ToTable("TypeOfWork");
                });

            modelBuilder.Entity("CaseTypeOfWork", b =>
                {
                    b.Property<int>("CasesCaseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkDoneDescriptionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CasesCaseId", "WorkDoneDescriptionId");

                    b.HasIndex("WorkDoneDescriptionId");

                    b.ToTable("CaseTypeOfWork");
                });

            modelBuilder.Entity("AppCore.Models.Case", b =>
                {
                    b.HasOne("AppCore.Models.Device", "Device")
                        .WithMany("Cases")
                        .HasForeignKey("DeviceId");

                    b.HasOne("AppCore.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.Navigation("Device");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("AppCore.Models.Device", b =>
                {
                    b.HasOne("AppCore.Models.Location", "Location")
                        .WithMany("Devices")
                        .HasForeignKey("LocationId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("CaseTypeOfWork", b =>
                {
                    b.HasOne("AppCore.Models.Case", null)
                        .WithMany()
                        .HasForeignKey("CasesCaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppCore.Models.TypeOfWork", null)
                        .WithMany()
                        .HasForeignKey("WorkDoneDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppCore.Models.Device", b =>
                {
                    b.Navigation("Cases");
                });

            modelBuilder.Entity("AppCore.Models.Location", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
