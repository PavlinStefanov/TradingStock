using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Infrastructure.Repositories
{
    public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : class
    {
    }
}
