using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.CQRS.Domain
{
    public interface IRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aggregate"></param>
        /// <param name="expectedVersion"></param>
        void Save<T>(T aggregate, int? expectedVersion = null) where T : AggregateRoot;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aggregateId"></param>
        /// <returns></returns>
        T Get<T>(Guid aggregateId) where T : AggregateRoot;
    }
}
