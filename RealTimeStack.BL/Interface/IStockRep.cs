
using RealTimeStock.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Interface
{
    public interface IStockRep
    {
        Task<IEnumerable<Stock>> GetAll();
        Task Update(Stock obj);

    }
}
