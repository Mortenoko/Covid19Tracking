﻿// <auto-generated />
using System;
using Covid19Tracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Covid19Tracking.Migrations
{
    [DbContext(typeof(CovidDbContext))]
    [Migration("20210118223605_Test")]
    partial class Test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Covid19Tracking.Citizen", b =>
                {
                    b.Property<string>("SSN")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<int>("MunicipalityID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sex")
                        .HasColumnType("TEXT");

                    b.Property<int>("age")
                        .HasColumnType("INTEGER");

                    b.HasKey("SSN");

                    b.HasIndex("MunicipalityID");

                    b.ToTable("Citizen");
                });

            modelBuilder.Entity("Covid19Tracking.CitizenLocation", b =>
                {
                    b.Property<string>("SSN")
                        .HasColumnType("TEXT");

                    b.Property<string>("Addr")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.HasKey("SSN");

                    b.HasIndex("Addr");

                    b.ToTable("citizenLocations");
                });

            modelBuilder.Entity("Covid19Tracking.Location", b =>
                {
                    b.Property<string>("Addr")
                        .HasColumnType("TEXT");

                    b.Property<int>("MunicipalityID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Addr");

                    b.HasIndex("MunicipalityID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Covid19Tracking.Municipality", b =>
                {
                    b.Property<int>("MunicipalityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NationName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Population")
                        .HasColumnType("INTEGER");

                    b.Property<string>("mName")
                        .HasColumnType("TEXT");

                    b.HasKey("MunicipalityID");

                    b.HasIndex("NationName");

                    b.ToTable("Municipality");
                });

            modelBuilder.Entity("Covid19Tracking.Nation", b =>
                {
                    b.Property<string>("NationName")
                        .HasColumnType("TEXT");

                    b.HasKey("NationName");

                    b.ToTable("Nation");
                });

            modelBuilder.Entity("Covid19Tracking.TestCenter", b =>
                {
                    b.Property<string>("centerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hours")
                        .HasColumnType("TEXT");

                    b.Property<int>("MunicipalityID")
                        .HasColumnType("INTEGER");

                    b.HasKey("centerName");

                    b.HasIndex("MunicipalityID");

                    b.ToTable("Testcenter");
                });

            modelBuilder.Entity("Covid19Tracking.TestCenterManagement", b =>
                {
                    b.Property<int>("phoneNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("centerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.HasKey("phoneNum");

                    b.HasIndex("centerName")
                        .IsUnique();

                    b.ToTable("Testcentermanagement");
                });

            modelBuilder.Entity("Covid19Tracking.TestedAt", b =>
                {
                    b.Property<string>("SSN")
                        .HasColumnType("TEXT");

                    b.Property<string>("centerName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<string>("result")
                        .HasColumnType("TEXT");

                    b.Property<string>("status")
                        .HasColumnType("TEXT");

                    b.HasKey("SSN");

                    b.HasIndex("centerName");

                    b.ToTable("testedAts");
                });

            modelBuilder.Entity("Covid19Tracking.Citizen", b =>
                {
                    b.HasOne("Covid19Tracking.Municipality", "municipality")
                        .WithMany("citizens")
                        .HasForeignKey("MunicipalityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("municipality");
                });

            modelBuilder.Entity("Covid19Tracking.CitizenLocation", b =>
                {
                    b.HasOne("Covid19Tracking.Location", "location")
                        .WithMany("citizenLocations")
                        .HasForeignKey("Addr");

                    b.HasOne("Covid19Tracking.Citizen", "citizen")
                        .WithMany("citizenLocations")
                        .HasForeignKey("SSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("citizen");

                    b.Navigation("location");
                });

            modelBuilder.Entity("Covid19Tracking.Location", b =>
                {
                    b.HasOne("Covid19Tracking.Municipality", "municipality")
                        .WithMany("locations")
                        .HasForeignKey("MunicipalityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("municipality");
                });

            modelBuilder.Entity("Covid19Tracking.Municipality", b =>
                {
                    b.HasOne("Covid19Tracking.Nation", "nation")
                        .WithMany("municipalities")
                        .HasForeignKey("NationName");

                    b.Navigation("nation");
                });

            modelBuilder.Entity("Covid19Tracking.TestCenter", b =>
                {
                    b.HasOne("Covid19Tracking.Municipality", "municipality")
                        .WithMany("testCenters")
                        .HasForeignKey("MunicipalityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("municipality");
                });

            modelBuilder.Entity("Covid19Tracking.TestCenterManagement", b =>
                {
                    b.HasOne("Covid19Tracking.TestCenter", "testCenter")
                        .WithOne("testCenterManagement")
                        .HasForeignKey("Covid19Tracking.TestCenterManagement", "centerName");

                    b.Navigation("testCenter");
                });

            modelBuilder.Entity("Covid19Tracking.TestedAt", b =>
                {
                    b.HasOne("Covid19Tracking.Citizen", "citizen")
                        .WithMany("testedAts")
                        .HasForeignKey("SSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Covid19Tracking.TestCenter", "testCenter")
                        .WithMany("testedAts")
                        .HasForeignKey("centerName");

                    b.Navigation("citizen");

                    b.Navigation("testCenter");
                });

            modelBuilder.Entity("Covid19Tracking.Citizen", b =>
                {
                    b.Navigation("citizenLocations");

                    b.Navigation("testedAts");
                });

            modelBuilder.Entity("Covid19Tracking.Location", b =>
                {
                    b.Navigation("citizenLocations");
                });

            modelBuilder.Entity("Covid19Tracking.Municipality", b =>
                {
                    b.Navigation("citizens");

                    b.Navigation("locations");

                    b.Navigation("testCenters");
                });

            modelBuilder.Entity("Covid19Tracking.Nation", b =>
                {
                    b.Navigation("municipalities");
                });

            modelBuilder.Entity("Covid19Tracking.TestCenter", b =>
                {
                    b.Navigation("testCenterManagement");

                    b.Navigation("testedAts");
                });
#pragma warning restore 612, 618
        }
    }
}
