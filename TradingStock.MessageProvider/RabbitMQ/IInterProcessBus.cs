using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.MessageProvider.RabbitMQ
{
    public interface IInterProcessBus
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void SendMessage(string message);
    }
}
