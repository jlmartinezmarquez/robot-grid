using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace RobotGrid.Api.Configuration
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Robot Grid",
                    Description = "Emulating robot movements on a grid UI",
                });
            });

            return services;
        }
    }
}
