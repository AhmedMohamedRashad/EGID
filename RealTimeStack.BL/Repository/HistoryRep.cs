
using Demo.BL.Interface;
using Microsoft.EntityFrameworkCore;
using RealTimeStock.DAL.Database;
using RealTimeStock.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
    public class HistoryRep : IHistoryRep
    {
        private readonly ApplicationDbContext db;

        public HistoryRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task Create(History obj)
        {
            await db.History.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<History>> GetHistoryBySymbol(string StockSymbol)
        {
            return await db.History.Where(x => x.StockSymbol == StockSymbol).ToListAsync();
        }
    }
}
