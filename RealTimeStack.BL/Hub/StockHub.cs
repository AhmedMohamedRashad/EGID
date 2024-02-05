using Microsoft.AspNetCore.SignalR;
using RealTimeStock.BL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeStack.BL.Hub
{
    public class StockHub : Hub<IStockHub>
    {
        public async Task SendStocks(string stockUpdated)
        {
            await Clients.All.SendOffersToUser(stockUpdated);
        }

    }
}
