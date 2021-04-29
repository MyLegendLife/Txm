using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;
using Txm.Identity.Host.Configs;

namespace Txm.Identity.Host.Extensions
{
    public static class ConsulBuilderExtension
    {
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IHostApplicationLifetime lifetime, ConsulConfig option)
        {
            var client = new ConsulClient(x => x.Address = new Uri(option.ConsulAddress));//请求注册的Consul地址
            var check = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务启动多久后注册
                Interval = TimeSpan.FromSeconds(10),//健康检查时间间隔，或者成为心跳间隔
                HTTP = option.HealthCheckAddress,//健康检查地址
                Timeout = TimeSpan.FromSeconds(5)
            };

            //Register service with consul
            var registration = new AgentServiceRegistration()
            {
                Checks = new[] { check },
                ID = Guid.NewGuid().ToString(), 
                Name = option.ServiceName, //本地服务名称
                Address = option.ServiceIP,  //本地IP
                Port = option.ServicePort,   //本地端口
                Tags = new[] { $"urlprefix-/{option.ServiceName}" } //添加urlprefix-/servicename格式的tag标签，以便Fabio识别
            };

            client.Agent.ServiceRegister(registration).Wait();//服务启动时注册，内部实现其实就是使用Consul API进行注册（HttpClient发起)
            lifetime.ApplicationStopping.Register(() =>
            {
                client.Agent.ServiceDeregister(registration.ID).Wait();//服务停止时取消注册
            });

            return app;
        }

    }
}
