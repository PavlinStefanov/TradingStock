using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Business.CQRS.Messages;

namespace TradingStock.Business.CQRS.Events
{
    public interface IEvent : IMessage
    {
        Guid Id { get; set; }
        int Version { get; set; }
        DateTimeOffset TimeStamp { get; set; }
        byte[] Metadata { get; set; }
    }
}
