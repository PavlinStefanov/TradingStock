using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Business.CQRS.Utils;

namespace TradingStock.Business.CQRS.Events
{
    public interface IEventStore
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        void Save(IEvent @event);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggreagteId"></param>
        /// <param name="fromVersion"></param>
        /// <returns></returns>
        IEnumerable<Event> Get(Guid aggreagteId, int fromVersion);
    }
}
