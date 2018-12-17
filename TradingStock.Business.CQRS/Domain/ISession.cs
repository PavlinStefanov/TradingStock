using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.CQRS.Domain
{
    public interface ISession
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aggregate"></param>
        void Add<T>(T aggregate) where T : AggregateRoot;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="expectedVersion"></param>
        /// <returns></returns>
        T Get<T>(Guid id, int? expectedVersion = null) where T : AggregateRoot;

        /// <summary>
        /// 
        /// </summary>
        void Commit();
    }
}
