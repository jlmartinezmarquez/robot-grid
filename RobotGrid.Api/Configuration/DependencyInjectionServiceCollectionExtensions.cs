using Microsoft.Extensions.DependencyInjection;
using RobotGrid.Domain;
using System.Reflection;

namespace RobotGrid.Api.Configuration
{
    public static class DependencyInjectionServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDependencyInjections(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromAssemblies(typeof(Startup).GetTypeInfo().Assembly).AddClasses().AsImplementedInterfaces().WithScopedLifetime());
            services.Scan(scan => scan.FromAssemblies(typeof(IMovement).GetTypeInfo().Assembly).AddClasses().AsImplementedInterfaces().WithScopedLifetime());
            
            return services;
        }
    }
}
