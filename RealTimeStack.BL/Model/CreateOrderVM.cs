using RealTimeStock.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeStock.BL.Entity
{
    public class CreateOrderVM
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderTypeId { get; set; }
        public string StockSymbol { get; set; }



    }
}
