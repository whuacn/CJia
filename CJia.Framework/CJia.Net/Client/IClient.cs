using CJia.Net.Communication;
using CJia.Net.Communication.Messengers;

namespace CJia.Net.Client
{
    /// <summary>
    /// Represents a client to connect to server.
    /// </summary>
    public interface IClient : IMessenger, IConnectableClient
    {
        //Does not define any additional member
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
