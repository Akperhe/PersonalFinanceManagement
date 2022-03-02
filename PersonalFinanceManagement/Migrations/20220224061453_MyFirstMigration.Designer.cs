﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalFinanceManagement.Configurations;

#nullable disable

namespace PersonalFinanceManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220224061453_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PersonalFinanceManagement.Data.AccountSummary", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountSummaries");

                    b.HasData(
                        new
                        {
                            Id = "0b9ce807-3402-4a9d-b7cc-c712bed8a90f",
                            AccountNo = "2119174850",
                            Address = "Sangotedo",
                            Balance = 8036844238.0,
                            DateCreated = new DateTime(2022, 2, 24, 7, 14, 53, 382, DateTimeKind.Local).AddTicks(306),
                            DateModified = new DateTime(2022, 2, 24, 7, 14, 53, 382, DateTimeKind.Local).AddTicks(307),
                            FirstName = "Akperhe",
                            LastName = "Smith"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
