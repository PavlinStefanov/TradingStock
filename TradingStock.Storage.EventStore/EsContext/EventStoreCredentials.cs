using EventStore.ClientAPI.SystemData;

namespace TradingStock.Storage.EventStore.EsContext
{
    public class EventStoreCredentials
    {
        /// <summary>
        /// 
        /// </summary>
        public static UserCredentials Default { get; } = new UserCredentials("admin", "changeit");
    }
}
