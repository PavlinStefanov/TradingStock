using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.CQRS.Utils.Dto
{
    public class EventStoreMetadata
    {
        public Guid AggregateId { get; set; }
        public string StockType { get; set; }
        public double? Up { get; set; }
        public double? Down { get; set; }
        public DateTimeOffset StockChange { get; set; }
        public int ExpectedVersion { get; set; }
    }
}
