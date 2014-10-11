using CJia.Net.Communication.Protocols;

namespace CJia.Net.Communication.Protocols.CustomProtocol
{
    /// <summary>
    /// 文本协议Factory
    /// </summary>
    public class TextProtocolFactory : ICJiaWireProtocolFactory
    {
        /// <summary>
        /// 创建自定义文本协议
        /// </summary>
        /// <returns></returns>
        public ICJiaWireProtocol CreateWireProtocol()
        {
            return new TextProtocol();
        }
    }
}
