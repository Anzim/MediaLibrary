﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MediaLibrary.Models;
using MySQL.Data.Entity.Extensions;

namespace MediaLibrary
{
    public class Startup
    {
        private readonly ILogger _logger;

        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("AppSettings");
            _logger.LogInformation($"AppSettings for connection strings file name: appsettings.{env.EnvironmentName}.json");

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
            
            services.AddSingleton(provider => Configuration);
            //services.AddScoped<IRestaurantData, InMemoryRestaurantData>();
            //services.AddRouting();
            //services.AddDbContext<Mp3EhbContext>(contextLifetime: ServiceLifetime.Scoped);
            //var connectionString = Configuration["ConnectionStrings:DataAccessMySqlProvider"];
            var connectionString = Configuration.GetConnectionString("DataAccessMySqlProvider");
            _logger.LogInformation($"DataAccessMySqlProvider connection string: {connectionString}");
            services.AddDbContext<MediaLibraryContext>(options =>
                options.UseMySQL(connectionString));
            //options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddProvider(new DbLoggerProvider());
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
