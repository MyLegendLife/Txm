using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Metrics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

namespace Txm.Gateway.Host
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region ×¢²áMetrics
            var isOpenMetrics = Convert.ToBoolean(_configuration["AppMetrics:IsOpen"]);
            if (isOpenMetrics)
            {
                var database = _configuration["AppMetrics:DatabaseName"];
                var connStr = _configuration["AppMetrics:ConnectionString"];
                var app = _configuration["AppMetrics:App"];
                var env = _configuration["AppMetrics:Env"];
                var username = _configuration["AppMetrics:UserName"];
                var password = _configuration["AppMetrics:Password"];

                var uri = new Uri(connStr);
                var metrics = AppMetrics.CreateDefaultBuilder().Configuration.Configure(options =>
                {
                    options.AddAppTag(app);
                    options.AddEnvTag(env);
                }).Report.ToInfluxDb(options =>
                {
                    options.InfluxDb.BaseUri = uri;
                    options.InfluxDb.Database = database;
                    options.InfluxDb.UserName = username;
                    options.InfluxDb.Password = password;
                    options.HttpPolicy.BackoffPeriod = TimeSpan.FromSeconds(30);
                    options.HttpPolicy.FailuresBeforeBackoff = 5;
                    options.HttpPolicy.Timeout = TimeSpan.FromSeconds(10);
                    options.FlushInterval = TimeSpan.FromSeconds(5);
                }).Build();

                services.AddMetrics(metrics);
                //services.AddMetricsReportScheduler();
                services.AddMetricsTrackingMiddleware();
                services.AddMetricsEndpoints();
                services.AddMetricsTrackingMiddleware(options => options.IgnoredHttpStatusCodes = new[] { 404 });
            }
            #endregion

            services.AddOcelot(new ConfigurationBuilder().AddJsonFile("ocelot.json").Build())
                .AddConsul();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var isOpenMetrics = Convert.ToBoolean(_configuration["AppMetrics:IsOpen"]);
            if (isOpenMetrics)
            {
                app.UseMetricsAllMiddleware();
                app.UseMetricsAllEndpoints();
            }

            app.UseOcelot();
        }
    }
}
