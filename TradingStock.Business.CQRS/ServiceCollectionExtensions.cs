using Microsoft.Extensions.DependencyInjection;
using System;
using TradingStock.Business.CQRS.Queries;

namespace TradingStock.Business.CQRS
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCqsEngine(this IServiceCollection services)
        {
            services.AddScoped<IQueryProcessor, QueryProcessor>();
            //services.AddScoped<ICommandDispatcher, CommandDispatcher>();

            return services;
        }


        public static IServiceCollection AddCqsEngine(this IServiceCollection services, Action<IServiceCollection> subRegister)
        {
            services.AddScoped<IQueryProcessor, QueryProcessor>();
            //services.AddScoped<ICommandDispatcher, CommandDispatcher>();

            subRegister(services);

            return services;
        }
    }
}
