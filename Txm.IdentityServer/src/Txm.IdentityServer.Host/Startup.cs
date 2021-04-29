using IdentityModel;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Security.Claims;
using Consul;
using Txm.IdentityServer.Domain;
using Txm.IdentityServer.EntityFrameworkCore;
using Txm.IdentityServer.Host.Configs;
using Txm.IdentityServer.Host.Entities;
using Txm.IdentityServer.Host.Extensions;

namespace Txm.IdentityServer.Host
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
            var connectionString = _configuration.GetConnectionString("Default");

            //配置AspNetCoreIdentity
            services.AddDbContext<TxmIdentityDbContext>(u => u.UseSqlServer(connectionString));
            services.AddIdentity<TxmUser, TxmRole>(options =>
                {
                    // 密码复杂度配置
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<TxmIdentityDbContext>()
                .AddDefaultTokenProviders();
                //.AddClaimsPrincipalFactory<UserClaimsPrincipal>();

            //配置IdentityServer4
            services.AddIdentityServer()
                .AddConfigurationStore<TxmConfigurationDbContext>(options =>
                {
                    options.ConfigureDbContext = b =>
                        b.UseSqlServer(connectionString, options => options.MigrationsAssembly("Txm.IdentityServer.EntityFrameworkCore"));
                })
                .AddOperationalStore<TxmPersistedGrantDbContext>(options =>
                {
                    options.ConfigureDbContext = b =>
                        b.UseSqlServer(connectionString, options => options.MigrationsAssembly("Txm.IdentityServer.EntityFrameworkCore"));
                })
                .AddAspNetIdentity<TxmUser>()
                .AddDeveloperSigningCredential();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //初始化数据
            InitializeAuthDatabase(app);
            InitializeIdentityDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            //添加IdentityServer中间件到Pipeline
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        // 初始化数据
        private void InitializeAuthDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<TxmPersistedGrantDbContext>().Database.Migrate();
                var context = serviceScope.ServiceProvider.GetService<TxmConfigurationDbContext>();
                context.Database.Migrate();

                if (!context.Clients.Any())
                {
                    foreach (var client in Config.GetClients())
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Config.IdentityResources)
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var resource in Config.GetApiResources())
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiScopes.Any())
                {
                    foreach (var scope in Config.ApiScopes)
                    {
                        context.ApiScopes.Add(scope.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }

        //初始化数据
        private void InitializeIdentityDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TxmIdentityDbContext>();
                context.Database.Migrate();

                //用户
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<TxmUser>>();
                var user = userManager.FindByNameAsync("zhangsan").Result;
                if (user == null)
                {
                    user = new TxmUser
                    {
                        UserName = "zhangsan",
                        Email = "zhangsan@email.com"
                    };
                    
                    var result = userManager.CreateAsync(user, "123456").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    result = userManager.AddClaimsAsync(user, new[] {
                        new Claim(JwtClaimTypes.Name, "tony"),
                        new Claim(JwtClaimTypes.GivenName, "tony"),
                        new Claim(JwtClaimTypes.FamilyName, "tony"),
                        new Claim(JwtClaimTypes.Email, "tony@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://tony.com"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    }).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                }

                //角色
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<TxmRole>>();
                var role = roleManager.FindByNameAsync("admin").Result; 
                if (role == null)
                {
                    role = new TxmRole()
                    {
                        Name = "admin",
                    };

                    var result = roleManager.CreateAsync(role).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = roleManager.AddClaimAsync(role, new Claim(JwtClaimTypes.Name, "module_add")).Result;
                    result = roleManager.AddClaimAsync(role, new Claim(JwtClaimTypes.Name, "module_del")).Result;
                    result = roleManager.AddClaimAsync(role, new Claim(JwtClaimTypes.Name, "module_edit")).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                } 
                
                var dfd = userManager.AddToRoleAsync(user, "admin").Result;
            }
        }

    }
}
