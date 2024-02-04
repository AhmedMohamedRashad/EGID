﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealTimeStock.DAL.Database;

#nullable disable

namespace RealTimeStock.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240203220854_FirstMig")]
    partial class FirstMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RealTimeStock.DAL.Entity.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("StockSymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TimeStamps")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StockSymbol");

                    b.ToTable("History");
                });

            modelBuilder.Entity("RealTimeStock.DAL.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("StockSymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StockSymbol");

                    b.HasIndex("TypeId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("RealTimeStock.DAL.Entity.OrderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Buy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sell"
                        });
                });

            modelBuilder.Entity("RealTimeStock.DAL.Entity.Stock", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("TimeStamps")
                        .HasColumnType("datetime2");

                    b.HasKey("Symbol");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("RealTimeStock.DAL.Entity.History", b =>
                {
                    b.HasOne("RealTimeStock.DAL.Entity.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockSymbol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("RealTimeStock.DAL.Entity.Order", b =>
                {
                    b.HasOne("RealTimeStock.DAL.Entity.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockSymbol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealTimeStock.DAL.Entity.OrderType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
