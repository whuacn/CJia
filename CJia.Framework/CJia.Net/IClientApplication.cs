using CJia.Net.Client;

namespace CJia.Net
{
    /// <summary>
    /// Represents a service client that consumes a SCS service.
    /// </summary>
    /// <typeparam name="T">Type of service interface</typeparam>
    public interface IClientApplication<out T> : IConnectableClient where T : class
    {
        /// <summary>
        /// Reference to the service proxy to invoke remote service methods.
        /// </summary>
        T ServiceProxy { get; }

        /// <summary>
        /// Timeout value when invoking a service method.
        /// If timeout occurs before end of remote method call, an exception is thrown.
        /// Use -1 for no timeout (wait indefinite).
        /// Default value: 60000 (1 minute).
        /// </summary>
        int Timeout { get; set; }
        /// <summary>
        /// 是否允许自动Ping远程服务器以检测连接是否中断，默认30秒ping一次
        /// </summary>
        bool AllowAutoPing { get; set; }
        /// <summary>
        /// Ping间隔时间，单位ms（1000ms=1秒）
        /// </summary>
        int PingInterval { get; set; }
    }
}
