using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeStock.BL.Entity
{
    public class StockVM
    {
        public string Symbol { get; set; }
        public double Price { get; set; }
        public DateTime TimeStamps { get; set; }
    }
}
