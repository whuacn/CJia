using CJia.Net.Tcp;
using CJia.Net.Client;

namespace CJia.Net.Server
{
    /// <summary>
    /// This class is used to create SCS servers.
    /// </summary>
    public static class ServerFactory
    {
        /// <summary>
        /// Creates a new SCS Server using an EndPoint.
        /// </summary>
        /// <param name="endPoint">Endpoint that represents address of the server</param>
        /// <returns>Created TCP server</returns>
        public static IServer CreateServer(CJiaEndPoint endPoint)
        {
            return endPoint.CreateServer();
        }
    }
}
