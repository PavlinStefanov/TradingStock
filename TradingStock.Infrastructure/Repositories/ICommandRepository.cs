using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Infrastructure.Repositories
{
    public interface ICommandRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity, Guid id);

        /// <summary>
        /// 
        /// </summary>
        void Commit();
    }
}
