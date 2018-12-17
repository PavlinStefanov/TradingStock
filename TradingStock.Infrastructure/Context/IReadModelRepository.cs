using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Infrastructure.Context
{
    public interface IReadModelRepository
    {
        void Insert(object item);
    }
}
