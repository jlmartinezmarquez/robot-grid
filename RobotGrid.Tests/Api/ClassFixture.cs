﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace RobotGrid.Tests.Api
{
    public class ClassFixture : IDisposable
    {
        public readonly IConfiguration Configuration;
        public readonly TestServer Server;
        public readonly HttpClient Client;
        public readonly IMapper Mapper;

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

            Mapper = Server.Services.GetRequiredService<IMapper>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
