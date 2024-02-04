using Demo.BL.Interface;
using Microsoft.EntityFrameworkCore;
using RealTimeStock.DAL.Database;
using RealTimeStock.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
    public class OrderTypeRep : IOrderTypeRep
    {
        private readonly ApplicationDbContext db;

        public OrderTypeRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<OrderType>> GetAll()
        {
            return await db.OrderType.ToListAsync();
        }
    }
}
