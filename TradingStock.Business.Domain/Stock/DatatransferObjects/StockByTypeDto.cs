using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.Domain.Stock.DatatransferObjects
{
    public class StockByTypeDto
    {
        public Guid ID { get; set; }
        public string StockType { get; set; }
        public double? Up { get; set; }
        public double? Down { get; set; }
        public DateTime StockChange { get; set; }
    }
}
