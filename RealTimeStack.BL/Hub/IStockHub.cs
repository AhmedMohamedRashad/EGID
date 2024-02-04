using RealTimeStock.BL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeStack.BL.Hub
{
    public interface IStockHub
    {
        Task SendStocks(string stocks);
    }
}
