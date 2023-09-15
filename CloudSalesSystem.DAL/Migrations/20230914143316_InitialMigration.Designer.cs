﻿// <auto-generated />
using System;
using CloudSalesSystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CloudSalesSystem.DAL.Migrations
{
    [DbContext(typeof(CSSContext))]
    [Migration("20230914143316_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CloudSalesSystem.DAL.DTOs.AccountDto", b =>
                {
                    b.Property<string>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("CloudSalesSystem.DAL.DTOs.SoftwareDto", b =>
                {
                    b.Property<string>("SoftwareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountRefId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SoftwareName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SoftwareId");

                    b.HasIndex("AccountRefId");

                    b.ToTable("Software");
                });

            modelBuilder.Entity("CloudSalesSystem.DAL.DTOs.SoftwareDto", b =>
                {
                    b.HasOne("CloudSalesSystem.DAL.DTOs.AccountDto", "Account")
                        .WithMany("AccountSoftwares")
                        .HasForeignKey("AccountRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("CloudSalesSystem.DAL.DTOs.AccountDto", b =>
                {
                    b.Navigation("AccountSoftwares");
                });
#pragma warning restore 612, 618
        }
    }
}