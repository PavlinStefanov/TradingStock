using Microsoft.EntityFrameworkCore;
using System;
using TradingStock.Infrastructure.Model;

namespace TradingStock.Infrastructure.Context
{
    public interface ITradingStockDbContext : IDisposable
    {
        #region Entity Sets
        DbSet<Stock> Stocks { get; set; }
        #endregion

        void SaveChanges();
    }
}
