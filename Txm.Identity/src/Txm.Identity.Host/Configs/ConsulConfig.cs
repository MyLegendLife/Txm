namespace Txm.Identity.Host.Configs
{
    public class ConsulConfig
    {
        /// <summary>
        /// 本地服务名称
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 本地服务IP
        /// </summary>
        public string ServiceIP { get; set; }

        /// <summary>
        /// 本地服务端口
        /// </summary>
        public int ServicePort { get; set; }

        /// <summary>
        /// Consul地址
        /// </summary>
        public string ConsulAddress { get; set; }

        /// <summary>
        /// 健康检查地址
        /// </summary>
        public string HealthCheckAddress { get; set; }
    }
}
