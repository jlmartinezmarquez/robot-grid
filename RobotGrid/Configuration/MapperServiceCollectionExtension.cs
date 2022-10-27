using Microsoft.Extensions.DependencyInjection;

namespace RobotGrid.Api.Configuration
{
    public static class MapperServiceCollectionExtension
    {
        public static IServiceCollection ConfigureMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile));
            return services;
        }
    }
}
