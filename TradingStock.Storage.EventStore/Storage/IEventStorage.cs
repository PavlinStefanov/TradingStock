using EventStore.ClientAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TradingStock.Storage.EventStore.Storage
{
    public interface IEventStorage
    {
        void AppentToAggregate(Guid aggregateId, EventData eventData);

        Task<byte[]> FetchEventsByAggregateAsync(Guid aggregateId, int fromVersion);
    }
}
