using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Txm.Identity.Host.Configs;
using Txm.Identity.Host.Extensions;

namespace Txm.Identity.Host
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(_configuration["AuthServer:Scheme"])
                .AddJwtBearer(options =>
                {
                    options.Authority = _configuration["AuthServer:Authority"];
                    options.Audience = _configuration["AuthServer:Audience"];
                    options.RequireHttpsMetadata = false;
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Policy1", builder => { builder.RequireScope("default1"); });
                options.AddPolicy("Policy2", builder => { builder.RequireScope("default2"); });
            });

            services.AddControllers(
                opt =>
                {
                    // 统一设置路由前缀
                    opt.UseCentralRoutePrefix(new RouteAttribute(_configuration["Prefix"]));
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            #region Consul 服务注册

            var consulOption = _configuration.GetSection("Consul").Get<ConsulConfig>();

            app.RegisterConsul(lifetime, consulOption);

            #endregion

            //身份验证
            app.UseAuthentication();

            //授权
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
