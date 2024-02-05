using RealTimeStock.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Interface
{
    public interface IOrderRep
    {
        Task<IEnumerable<Order>> GetAll(Expression<Func<Order,bool>> filter = null); 
        Task Create(Order obj);
        Task<IEnumerable<OrderType>> GetOrderTypes();

    }
}
