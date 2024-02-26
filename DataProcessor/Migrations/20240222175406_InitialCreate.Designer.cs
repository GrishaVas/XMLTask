﻿// <auto-generated />
using System;
using DataProcessor.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataProcessor.Migrations
{
    [DbContext(typeof(DataProcessorDbContext))]
    [Migration("20240222175406_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("DataProcessor.Infrastructure.Models.CombinedStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Buzzer")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Channel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CombinedStatusType")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Flow")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBusy")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsError")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsReady")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("KeyLock")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MaximumInjectionVolume")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MaximumTemperatureLimit")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MinimumPressureLimit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mode")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModuleState")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.Property<bool?>("OvenOn")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("PercentB")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("PercentC")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("PercentD")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Pressure")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("PumpOn")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RackInf")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RackL")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.Property<string>("RackR")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RapidControlStatusId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Temperature_Actual")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.Property<string>("Temperature_Room")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.Property<bool?>("UseTemperatureControl")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Valve_Position")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Valve_Rotations")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Vial")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.Property<int?>("Volume")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RapidControlStatusId")
                        .IsUnique();

                    b.ToTable("CombinedStatuses");
                });

            modelBuilder.Entity("DataProcessor.Infrastructure.Models.DeviceStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("IndexWithinRole")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("InstrumentStatusId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModuleCategoryID")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RapidControlStatusId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InstrumentStatusId");

                    b.ToTable("DeviceStatuses");
                });

            modelBuilder.Entity("DataProcessor.Infrastructure.Models.InstrumentStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("PackageID")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("InstrumentStatuses");
                });

            modelBuilder.Entity("DataProcessor.Infrastructure.Models.RapidControlStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CombinedStatusId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DeviceStatusId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DeviceStatusId")
                        .IsUnique();

                    b.ToTable("RapidControlStatuses");
                });

            modelBuilder.Entity("DataProcessor.Infrastructure.Models.CombinedStatus", b =>
                {
                    b.HasOne("DataProcessor.Infrastructure.Models.RapidControlStatus", "RapidControlStatus")
                        .WithOne("CombinedStatus")
                        .HasForeignKey("DataProcessor.Infrastructure.Models.CombinedStatus", "RapidControlStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RapidControlStatus");
                });

            modelBuilder.Entity("DataProcessor.Infrastructure.Models.DeviceStatus", b =>
                {
                    b.HasOne("DataProcessor.Infrastructure.Models.InstrumentStatus", "InstrumentStatus")
                        .WithMany("DeviceStatuses")
                        .HasForeignKey("InstrumentStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InstrumentStatus");
                });

            modelBuilder.Entity("DataProcessor.Infrastructure.Models.RapidControlStatus", b =>
                {
                    b.HasOne("DataProcessor.Infrastructure.Models.DeviceStatus", "DeviceStatus")
                        .WithOne("RapidControlStatus")
                        .HasForeignKey("DataProcessor.Infrastructure.Models.RapidControlStatus", "DeviceStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceStatus");
                });

            modelBuilder.Entity("DataProcessor.Infrastructure.Models.DeviceStatus", b =>
                {
                    b.Navigation("RapidControlStatus")
                        .IsRequired();
                });

            modelBuilder.Entity("DataProcessor.Infrastructure.Models.InstrumentStatus", b =>
                {
                    b.Navigation("DeviceStatuses");
                });

            modelBuilder.Entity("DataProcessor.Infrastructure.Models.RapidControlStatus", b =>
                {
                    b.Navigation("CombinedStatus")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
