using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.CQRS.Events
{
    public interface IEventPublisher
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="event"></param>
        void Publish<T>(T @event) where T : IEvent;
    }
}
