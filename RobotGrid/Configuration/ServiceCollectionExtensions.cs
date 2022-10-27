using Microsoft.Extensions.DependencyInjection;
using RobotGrid.Api.Mappers;
using RobotGrid.Domain;

namespace RobotGrid.Api.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDependencyInjections(this IServiceCollection services)
        {
            // TODO: Use Scrutor package here
            services.AddScoped<IMovement, Movement>();  
            services.AddScoped<IApiDomainMapper, ApiDomainMapper>();
            return services;
        }
    }
}
