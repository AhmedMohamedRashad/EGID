
using RealTimeStock.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Interface
{
    public interface IHistoryRep
    {
        Task<IEnumerable<History>> GetHistoryBySymbol(string StockSymbol);
        Task Create(History obj);

    }
}
