using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Infrastructure.Context;

namespace TradingStock.Infrastructure.Repositories
{
    public class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : class
    {
        private readonly TradingStockDbContext _stockDbContext;

        public CommandRepository(TradingStockDbContext stockDbContext)
        {
            _stockDbContext = stockDbContext;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(TEntity entity)
        {
            _stockDbContext.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity, Guid id)
        {
            var item = _stockDbContext.Set<TEntity>().Find(id);
            _stockDbContext.Set<TEntity>().Update(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Commit()
        {
            _stockDbContext.SaveChanges();
        }
    }
}
