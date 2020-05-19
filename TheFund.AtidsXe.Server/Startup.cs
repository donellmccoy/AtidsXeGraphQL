using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using TheFund.AtidsXe.GraphQL.Middleware;
using TheFund.AtidsXe.GraphQL.Models;
using TheFund.AtidsXe.Server.Extensions;
using TheFund.AtidsXe.Server.Settings;

namespace TheFund.AtidsXe.Server
{
    public class Startup
    {
        #region Fields

        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructors

        public Startup(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            var configBuilder = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", false);

            _configuration = configBuilder.Build();
        }

        #endregion

        #region Methods

        public void ConfigureServices(IServiceCollection services)
        {
            var contextSettings = _configuration.GetSection<DbContextSettings>("DbContextSettings");
            var connectionStrings = _configuration.GetSection<DbConnectionStrings>("DbConnectionStrings");

            services
                .AddMemoryCache()
                .AddRepositories()
                .AddGraphQLServices()
                .AddEntityFrameworkServices()
                .AddQueryLookupServices()
                .AddDbContextServices(contextSettings, connectionStrings, _hostingEnvironment)
                .AddHttpContextAccessor()
                .Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true)
                .Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);
        }

        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment hostingEnvironment, IServiceProvider serviceProvider)
        {
            if (hostingEnvironment.IsDevelopment() || 
                hostingEnvironment.IsLocal() ||
                hostingEnvironment.IsPersonal() ||
                hostingEnvironment.IsStaging())
            {
                applicationBuilder.UseDeveloperExceptionPage();
            }
            else
            {
                applicationBuilder.UseExceptionHandler("/error");
            }

            //Todo: Find a better way of doing this
            var graphQLSettings = _configuration.GetSection<GraphQLSettings>("GraphQLSettings");
            graphQLSettings.BuildUserContext = context => new GraphQLUserContext
            {
                User = context.User
            };

            applicationBuilder.UseMiddleware<GraphQLMiddleware>(graphQLSettings);

            ConfigureGraphQLCache(serviceProvider);
        }

        //Todo: Find a better way of doing this
        private void ConfigureGraphQLCache(IServiceProvider serviceProvider)
        {
            var mappings = _configuration.GetSection<IEnumerable<GraphQLMapping>>("Queries");

            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            var cacheEntryOptions = new MemoryCacheEntryOptions();
            cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromDays(365));
            cacheEntryOptions.SetAbsoluteExpiration(TimeSpan.FromDays(365));

            memoryCache.Set("Queries", mappings, cacheEntryOptions);
        }

        #endregion
    }
}
