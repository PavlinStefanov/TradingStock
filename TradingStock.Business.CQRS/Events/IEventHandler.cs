using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Business.CQRS.Messages;

namespace TradingStock.Business.CQRS.Events
{
    public interface IEventHandler<T> : IHandler<T> where T : IEvent
    {
    }
}
