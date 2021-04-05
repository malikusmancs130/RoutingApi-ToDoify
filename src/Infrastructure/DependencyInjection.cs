using Microsoft.Extensions.DependencyInjection;
using RoutingApi.Application.Common.Interfaces;
using RoutingApi.Infrastructure.Services;

namespace RoutingApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDateTime, DateTimeService>();
            return services;
        }
    }
}