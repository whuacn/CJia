using CJia.Net.Communication.Channels;
using CJia.Net.Communication.Channels.Tcp;
using CJia.Net.Tcp;
using System.Net;

namespace CJia.Net.Tcp
{
    /// <summary>
    /// This class is used to communicate with server over TCP/IP protocol.
    /// </summary>
    internal class CJiaTcpClient : Client.ClientBase
    {
        /// <summary>
        /// The endpoint address of the server.
        /// </summary>
        private readonly CJiaEndPoint _serverEndPoint;

        /// <summary>
        /// Creates a new ScsTcpClient object.
        /// </summary>
        /// <param name="serverEndPoint">The endpoint address to connect to the server</param>
        public CJiaTcpClient(CJiaEndPoint serverEndPoint)
        {
            _serverEndPoint = serverEndPoint;
        }

        /// <summary>
        /// Creates a communication channel using ServerIpAddress and ServerPort.
        /// </summary>
        /// <returns>Ready communication channel to communicate</returns>
        protected override ICommunicationChannel CreateCommunicationChannel()
        {
            return new TcpCommunicationChannel(
                TcpHelper.ConnectToServer(
                    new IPEndPoint(IPAddress.Parse(_serverEndPoint.IpAddress), _serverEndPoint.TcpPort),
                    ConnectTimeout
                    ));
        }
    }
}
