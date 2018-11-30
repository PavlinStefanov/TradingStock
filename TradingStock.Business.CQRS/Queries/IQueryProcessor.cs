using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TradingStock.Business.CQRS.Queries
{
    public interface IQueryProcessor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        TResult Process<TResult>(IQuery<TResult> query);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query);
    }
}
