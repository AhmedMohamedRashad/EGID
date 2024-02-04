using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeStock.DAL.Entity
{
    public class Order
    {
        [Key]
        public int Id { get; set; } 
        public int Quantity { get; set; }
        [ForeignKey("OrderTypeId")]
        public OrderType? OrderType { get; set; }
        public int OrderTypeId { get; set; }
        [ForeignKey("StockSymbol")]
        public Stock? Stock { get; set; }
        public string StockSymbol { get; set; }


    }
}
