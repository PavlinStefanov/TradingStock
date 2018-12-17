using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.CQRS.Domain
{
    internal class AggregateFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreateAggregate<T>()
        {
            try
            {
                return (T)Activator.CreateInstance(typeof(T), true);
            }
            catch (Exception ex)
            {
                throw new Exception($"Missing parameters for {typeof(T)}.", ex);
            }
        }
    }
}
