using RealTimeStock.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeStock.BL.Entity
{
    public class HistoryVM
    {
        public int Id { get; set; }
        [ForeignKey("StockSymbol")]
        public StockVM? Stock { get; set; }
        public string StockSymbol { get; set; }
        public double Price { get; set; }
        public DateTime TimeStamps { get; set; }
    }
}
