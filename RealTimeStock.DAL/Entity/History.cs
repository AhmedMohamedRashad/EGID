using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeStock.DAL.Entity
{
    public class History
    {
        public int Id { get; set; }
        [ForeignKey("StockSymbol")]
        public Stock Stock { get; set; }
        public string StockSymbol { get; set; }
        public double Price { get; set; }
        public DateTime TimeStamps { get; set; }
    }
}
