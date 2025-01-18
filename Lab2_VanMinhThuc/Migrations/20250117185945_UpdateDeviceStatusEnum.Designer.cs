﻿// <auto-generated />
using System;
using Lab2_VanMinhThuc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab2_VanMinhThuc.Migrations
{
    [DbContext(typeof(DeviceDbContext))]
    [Migration("20250117185945_UpdateDeviceStatusEnum")]
    partial class UpdateDeviceStatusEnum
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab2_VanMinhThuc.Models.Category", b =>
                {
                    b.Property<int>("Category_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Category_ID"));

                    b.Property<string>("Category_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Category_ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Lab2_VanMinhThuc.Models.Device", b =>
                {
                    b.Property<string>("Device_Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Category_ID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date_Of_Entry")
                        .HasColumnType("datetime2");

                    b.Property<string>("Device_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Device_Code");

                    b.HasIndex("Category_ID");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("Lab2_VanMinhThuc.Models.DeviceUser", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_ID"));

                    b.Property<string>("User_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_Phone")
                        .HasColumnType("int");

                    b.HasKey("User_ID");

                    b.ToTable("DeviceUser");
                });

            modelBuilder.Entity("Lab2_VanMinhThuc.Models.Device", b =>
                {
                    b.HasOne("Lab2_VanMinhThuc.Models.Category", "Category")
                        .WithMany("Device")
                        .HasForeignKey("Category_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Lab2_VanMinhThuc.Models.Category", b =>
                {
                    b.Navigation("Device");
                });
#pragma warning restore 612, 618
        }
    }
}
