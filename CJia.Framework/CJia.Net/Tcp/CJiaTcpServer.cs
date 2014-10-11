using CJia.Net.Communication.Channels;
using CJia.Net.Communication.Channels.Tcp;
using CJia.Net.Tcp;
using CJia.Net.Server;

namespace CJia.Net.Tcp
{
    /// <summary>
    /// This class is used to create a TCP server.
    /// </summary>
    internal class CJiaTcpServer : ServerBase
    {
        /// <summary>
        /// The endpoint address of the server to listen incoming connections.
        /// </summary>
        private readonly CJiaEndPoint _endPoint;

        /// <summary>
        /// Creates a new ScsTcpServer object.
        /// </summary>
        /// <param name="endPoint">The endpoint address of the server to listen incoming connections</param>
        public CJiaTcpServer(CJiaEndPoint endPoint)
        {
            _endPoint = endPoint;
        }

        /// <summary>
        /// Creates a TCP connection listener.
        /// </summary>
        /// <returns>Created listener object</returns>
        protected override IConnectionListener CreateConnectionListener()
        {
            return new TcpConnectionListener(_endPoint);
        }
    }
}
