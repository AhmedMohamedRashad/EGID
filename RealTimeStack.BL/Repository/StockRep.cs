
using Demo.BL.Interface;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using RealTimeStack.BL.Hub;
using RealTimeStock.DAL.Database;
using RealTimeStock.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
    public class StockRep : IStockRep
    {
        private readonly ApplicationDbContext db;
        private readonly IHubContext<StockHub, IStockHub> stockHub;

        public StockRep(ApplicationDbContext db, IHubContext<StockHub, IStockHub> _stockHub)
        {
            this.db = db;
            stockHub = _stockHub;
        }
        public async Task<IEnumerable<Stock>> GetAll()
        {
            return await db.Stock.ToListAsync();       
        }

        public async Task Update(Stock obj)
        {
            await db.History.AddAsync(new History
            {
                Price = obj.Price,
                StockSymbol = obj.Symbol,
                TimeStamps = obj.TimeStamps
            });
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
            await stockHub.Clients.All.SendStocks("Stock updated");
            
        }
    }
}
