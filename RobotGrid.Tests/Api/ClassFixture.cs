using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RobotGrid.Api.ClassSelectors;
using RobotGrid.Api.Mappers;
using System;
using System.Net.Http;

namespace RobotGrid.Tests.Api
{
    public class ClassFixture : IDisposable
    {
        public readonly IConfiguration Configuration;
        public readonly TestServer Server;
        public readonly HttpClient Client;
        public readonly IRestMapper RestMapper;
        public readonly IMovementSelector MovementSelector;

        public ClassFixture()
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.loc.test.json", optional: true)
            .Build();

            Server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()
                .UseEnvironment("test")
                .UseConfiguration(Configuration));

            Client = Server.CreateClient();

            RestMapper = Server.Services.GetRequiredService<IRestMapper>();
            MovementSelector = Server.Services.GetRequiredService<IMovementSelector>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
