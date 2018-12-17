using System.Net;

namespace TradingStock.Storage.EventStore.EsContext
{
    public class IPEndPointFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IPEndPoint DefaultTcp()
        {
            return CreateTcpEndPoint(1113);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IPEndPoint DefaultHttp()
        {
            return CreateTcpEndPoint(2113);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        private static IPEndPoint CreateTcpEndPoint(int port)
        {
            var address = IPAddress.Parse("127.0.0.1");
            return new IPEndPoint(address, port);
        }
    }
}
