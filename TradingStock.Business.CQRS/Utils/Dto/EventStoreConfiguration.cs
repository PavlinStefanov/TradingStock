using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.CQRS.Utils.Dto
{
    public class EventStoreConfiguration
    {
        public EventStoreData Data { get; set; }
        public EventStoreMetadata Metadata { get; set; }
    }
}
