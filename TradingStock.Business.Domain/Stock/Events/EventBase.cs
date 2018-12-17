using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Business.CQRS.Events;

namespace TradingStock.Business.Domain.Stock.Events
{
    public abstract class EventBase : IEvent
    {
        public Guid Id { get ; set ; }
        public int Version { get ; set ; }
        public DateTimeOffset TimeStamp { get ; set ; }
        public byte[] Metadata { get; set; }
    }
}
