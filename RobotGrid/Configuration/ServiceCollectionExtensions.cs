using Microsoft.Extensions.DependencyInjection;
using RobotGrid.Api.Mappers;
using RobotGrid.Api.Services;
using RobotGrid.Domain;
using System.Reflection;

namespace RobotGrid.Api.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDependencyInjections(this IServiceCollection services)
        {
            // TODO: Use Scrutor package here
            //services.Scan(scan => scan.FromAssemblies(typeof(Startup).GetTypeInfo().Assembly).AddClasses().AsImplementedInterfaces().WithScopedLifetime());
            //services.Scan(scan => scan.FromAssemblies(typeof(IMovement).GetTypeInfo().Assembly).AddClasses().AsImplementedInterfaces().WithScopedLifetime());

            services.AddScoped<IMovement, MovementF>();
            services.AddScoped<IMovement, MovementL>();
            services.AddScoped<IMovement, MovementR>();

            services.AddScoped<IMovementSelector, MovementSelector>();
            services.AddScoped<IGridOperations, GridOperations>();
            services.AddScoped<IRobotGridService, RobotGridService>();
            services.AddScoped<IRestMapper, RestMapper>();
            return services;
        }
    }
}
