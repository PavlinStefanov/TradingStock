using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.MessageProvider.Common
{
    public interface IInterProcessBusSubscriber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IObservable<string> GetEventStream();
    }
}
