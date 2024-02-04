﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealTimeStock.DAL.Database;

#nullable disable

namespace RealTimeStock.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Price = 22.0,
                            StockSymbol = "AAPL",
                            TimeStamps = new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2291)
                        },
                        new
                        {
                            Id = 2,
                            Price = 33.0,
                            StockSymbol = "GOOGL",
                            TimeStamps = new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2304)
                        },
                        new
                        {
                            Id = 3,
                            Price = 44.0,
                            StockSymbol = "MSFT",
                            TimeStamps = new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2308)
                        },
                        new
                        {
                            Id = 4,
                            Price = 55.0,
                            StockSymbol = "AMZN",
                            TimeStamps = new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2317)
                        },
                        new
                        {
                            Id = 5,
                            Price = 66.0,
                            StockSymbol = "TSLA",
                            TimeStamps = new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2321)
                        });
                });

            modelBuilder.Entity("RealTimeStock.DAL.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("StockSymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OrderTypeId");

                    b.HasIndex("StockSymbol");

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

                    b.HasData(
                        new
                        {
                            Symbol = "AAPL",
                            Price = 22.0,
                            TimeStamps = new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2154)
                        },
                        new
                        {
                            Symbol = "GOOGL",
                            Price = 33.0,
                            TimeStamps = new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2228)
                        },
                        new
                        {
                            Symbol = "MSFT",
                            Price = 44.0,
                            TimeStamps = new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2232)
                        },
                        new
                        {
                            Symbol = "AMZN",
                            Price = 55.0,
                            TimeStamps = new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2236)
                        },
                        new
                        {
                            Symbol = "TSLA",
                            Price = 66.0,
                            TimeStamps = new DateTime(2024, 2, 4, 15, 44, 3, 788, DateTimeKind.Local).AddTicks(2239)
                        });
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
                    b.HasOne("RealTimeStock.DAL.Entity.OrderType", "OrderType")
                        .WithMany()
                        .HasForeignKey("OrderTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealTimeStock.DAL.Entity.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockSymbol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderType");

                    b.Navigation("Stock");
                });
#pragma warning restore 612, 618
        }
    }
}