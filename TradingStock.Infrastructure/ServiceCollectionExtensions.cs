using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TradingStock.Infrastructure.Context;

namespace TradingStock.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContextFactory(this IServiceCollection services)
        {
            var connection = @"data source=DESKTOP-CEO4LR9;initial catalog=TrackingStock;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            services.AddDbContext<TradingStockDbContext>(
              options => options.UseSqlServer(connection, x => x.MigrationsAssembly("TradingStock.Infrastructure")
             ));
            
            services.AddTransient<ITradingStockDbContextFactory, TradingStockDbContextFactory>();

            return services;
        }
    }
}
