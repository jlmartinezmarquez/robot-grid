using Microsoft.AspNetCore.Builder;

namespace RobotGrid.Api.Configuration
{
    public static class SwaggerApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Robot Grid API V1");
            });

            return app;
        }
    }
}
