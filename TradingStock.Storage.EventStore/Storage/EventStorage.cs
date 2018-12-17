using EventStore.ClientAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TradingStock.Storage.EventStore.EsContext;

namespace TradingStock.Storage.EventStore.Storage
{
    public class EventStorage : IEventStorage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregateId"></param>
        /// <param name="eventData"></param>
        public void AppentToAggregate(Guid aggregateId, EventData eventData)
        {
            using (var connection = EventStoreConnectionFactory.Default())
            {
                connection.ConnectAsync().Wait();
                connection.AppendToStreamAsync(aggregateId.ToString(), ExpectedVersion.Any, eventData)
                    .Wait();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggregateId"></param>
        /// <param name="fromVersion"></param>
        public async Task<byte[]> FetchEventsByAggregateAsync(Guid aggregateId, int fromVersion)
        {
            using (var connection = EventStoreConnectionFactory.Default())
            {
                connection.ConnectAsync().Wait();
                var streamEvents = await connection.ReadEventAsync(aggregateId.ToString(), 0, false, EventStoreCredentials.Default);
                return streamEvents.Event.Value.Event.Data;
            }
        }

        //public byte[] EventData(Guid aggregateId, int fromVersion)
        //{
        //   var result = FetchEventsByAggregateAsync(aggregateId, fromVersion);
            
        //}
    }
}
