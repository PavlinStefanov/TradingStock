using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.CQRS
{
    public interface IDependencyResolver
    {
        T Get<T>();
        IEnumerable<T> GetAll<T>();
    }
}
