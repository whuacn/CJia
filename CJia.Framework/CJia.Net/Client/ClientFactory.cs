using CJia.Net.Tcp;

namespace CJia.Net.Client
{
    /// <summary>
    /// This class is used to create SCS Clients to connect to a SCS server.
    /// </summary>
    public static class ClientFactory
    {
        /// <summary>
        /// Creates a new client to connect to a server using an end point.
        /// </summary>
        /// <param name="endpoint">End point of the server to connect it</param>
        /// <returns>Created TCP client</returns>
        public static IClient CreateClient(CJiaEndPoint endpoint)
        {
            return endpoint.CreateClient();
        }
    }
}
