using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TradingStock.Business.CQRS.Queries
{
    public interface IQueryHandlerAsync<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<TResult> ExecuteAsync(TQuery query);
    }
}
