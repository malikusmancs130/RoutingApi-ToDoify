using Microsoft.Extensions.DependencyInjection;
using RoutingApi.Application.Common.Interfaces;
using RoutingApi.Infrastructure.RestSharp.RestClient;

namespace RoutingApi.Infrastructure.RestSharp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureForRestSharp(this IServiceCollection services)
        {
            services.AddTransient<IRestSharpUtils, RestSharpUtils>();

            return services;
        }
    }
}