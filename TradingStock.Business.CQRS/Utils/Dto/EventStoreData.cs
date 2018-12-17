using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.CQRS.Utils.Dto
{
    public class EventStoreData
    {
        public Guid EventId { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
