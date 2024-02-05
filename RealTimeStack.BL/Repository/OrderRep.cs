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
    public class OrderRep : IOrderRep
    {
        private readonly ApplicationDbContext db;

        public OrderRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task Create(Order obj)
        {
            await db.Order.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAll(Expression<Func<Order, bool>> filter = null)
        {
            if (filter == null)//return all
                return await db.Order.Include("OrderType").Include("Stock").ToListAsync();
            else
                return await db.Order.Include("OrderType").Include("Stock").Where(filter).ToListAsync();
        }
        
        public async Task<IEnumerable<OrderType>> GetOrderTypes()
        {
                return await db.OrderType.ToListAsync();
        }
    }
}
