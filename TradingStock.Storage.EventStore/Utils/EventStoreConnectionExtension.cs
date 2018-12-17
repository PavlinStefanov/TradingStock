using EventStore.ClientAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingStock.Storage.EventStore.EsContext;

namespace TradingStock.Storage.EventStore.Utils
{
    public static class EventStoreConnectionExtension
    {
        private const int PageSize = 10;

        public static IEnumerable<T> ReadStreamEventsBackward<T>(this IEventStoreConnection connection, string streamName)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");
            var lastEventNumber = connection.GetLastEventNumber(streamName);

            return lastEventNumber == null
                ? new T[0]
                : ReadResult<T>(connection, streamName, lastEventNumber.Value);
        }

        public static T GetLastEvent<T>(this IEventStoreConnection connection, string streamName) where T : class
        {
            var lastEvent = connection.ReadEventAsync(streamName, -1, false, EventStoreCredentials.Default);
            if (lastEvent == null || lastEvent.Result.Event == null) return null;

            return lastEvent.Result.Event.Value.ParseJson<T>();
        }

        private static long? GetLastEventNumber(this IEventStoreConnection connection, string streamName)
        {
            var lastEvent = connection.ReadEventAsync(streamName, -1, false, EventStoreCredentials.Default);
            if (lastEvent == null || lastEvent.Result.Event == null)
                return null;

            return lastEvent.Result.EventNumber;
        }

        private static IEnumerable<T> ReadResult<T>(IEventStoreConnection connection, string streamName, long lastEventNumber)
        {
            var result = new List<T>();
            do
            {
                var events = connection.ReadStreamEventsBackwardsAsync(streamName, (int)lastEventNumber);
                result.AddRange(events.Result.Events.Select(e => e.ParseJson<T>()));
                lastEventNumber = events.Result.NextEventNumber;

            } while (lastEventNumber != -1);

            return result;
        }

        private static async Task<StreamEventsSlice> ReadStreamEventsBackwardsAsync(this IEventStoreConnection connection, string streamName, int lastEventNumber)
        {
            return await connection.ReadStreamEventsBackwardAsync(
                streamName,
                lastEventNumber,
                PageSize, false,
                EventStoreCredentials.Default);
        }
    }
}
