using EventStore.ClientAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Storage.EventStore.EsContext
{
    public static class EventStoreConnectionFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEventStoreConnection Default()
        {
            try
            {
                return EventStoreConnection.Create(IPEndPointFactory.DefaultTcp());
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to create connection for EventStore.", ex);
            }
        }
    }
}
