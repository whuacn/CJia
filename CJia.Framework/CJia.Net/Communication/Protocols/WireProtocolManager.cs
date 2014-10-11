using CJia.Net.Communication.Protocols.BinarySerialization;

namespace CJia.Net.Communication.Protocols
{
    /// <summary>
    /// This class is used to get default protocols.
    /// </summary>
    internal static class WireProtocolManager
    {
        /// <summary>
        /// Creates a default wire protocol factory object to be used on communicating of applications.
        /// </summary>
        /// <returns>A new instance of default wire protocol</returns>
        public static ICJiaWireProtocolFactory GetDefaultWireProtocolFactory()
        {
            return new BinarySerializationProtocolFactory();
        }

        /// <summary>
        /// Creates a default wire protocol object to be used on communicating of applications.
        /// </summary>
        /// <returns>A new instance of default wire protocol</returns>
        public static ICJiaWireProtocol GetDefaultWireProtocol()
        {
            return new BinarySerializationProtocol();
        }
    }
}
