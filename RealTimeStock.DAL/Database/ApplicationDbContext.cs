using Microsoft.EntityFrameworkCore;
using RealTimeStock.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeStock.DAL.Database
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderType> OrderType { get; set; }
        public DbSet<History> History { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderType>().HasData(
             new() { Id = 1, Name = "Buy" },
             new() { Id = 2, Name = "Sell" }
         );
            modelBuilder.Entity<Stock>().HasData(
            new() { Symbol = "AAPL", TimeStamps = DateTime.Now, Price = 22 },
            new() { Symbol = "GOOGL", TimeStamps = DateTime.Now, Price = 33 },
            new() { Symbol = "MSFT", TimeStamps = DateTime.Now, Price = 44 },
            new() { Symbol = "AMZN", TimeStamps = DateTime.Now, Price = 55 },
            new() { Symbol = "TSLA", TimeStamps = DateTime.Now, Price = 66 }
        );
            modelBuilder.Entity<History>().HasData(
        new() { Id = 1,StockSymbol = "AAPL", TimeStamps = DateTime.Now, Price = 22 },
        new() { Id = 2, StockSymbol = "GOOGL", TimeStamps = DateTime.Now, Price = 33 },
        new() { Id = 3, StockSymbol = "MSFT", TimeStamps = DateTime.Now, Price = 44 },
        new() { Id = 4, StockSymbol = "AMZN", TimeStamps = DateTime.Now, Price = 55 },
        new() { Id = 5, StockSymbol = "TSLA", TimeStamps = DateTime.Now, Price = 66 }
    );
        }

    }
}
