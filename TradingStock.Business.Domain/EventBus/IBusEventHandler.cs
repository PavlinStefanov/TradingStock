using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.Domain.EventBus
{
    public interface IBusEventHandler
    {
        /// <summary>
        /// 
        /// </summary>
        Type HandlerType { get; }
    }

    public interface IBusEventHandler<T> : IBusEventHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        void Handle(T @event);
    }
}
