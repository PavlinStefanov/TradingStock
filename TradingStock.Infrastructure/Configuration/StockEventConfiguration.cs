using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Infrastructure.Model;

namespace TradingStock.Infrastructure.Configuration
{
    public class StockEventConfiguration : IEntityTypeConfiguration<StockEvent>
    {
        public void Configure(EntityTypeBuilder<StockEvent> builder)
        {
            builder.ToTable("StockEvents");       
        }
    }
}
