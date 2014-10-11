using CJia.Net.Communication;
using CJia.Net.Communication.Messengers;
using CJia.Net.Client;
using CJia.Net.Server;

namespace CJia.Net.Service
{
    /// <summary>
    /// This class is used to create service client objects that is used in server-side.
    /// </summary>
    internal static class ServiceClientFactory
    {
        /// <summary>
        /// Creates a new service client object that is used in server-side.
        /// </summary>
        /// <param name="serverClient">Underlying server client object</param>
        /// <param name="requestReplyMessenger">RequestReplyMessenger object to send/receive messages over serverClient</param>
        /// <returns></returns>
        public static IServiceClient CreateServiceClient(IServerClient serverClient, RequestReplyMessenger<IServerClient> requestReplyMessenger)
        {
            return new ServiceClient(serverClient, requestReplyMessenger);
        }
    }
}
