using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.CQRS.Queries
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        TResult Execute(TQuery query);
    }
}
