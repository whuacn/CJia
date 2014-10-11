using System.Text;
using CJia.Net.Communication.Messages;
using CJia.Net.Communication.Protocols.BinarySerialization;

namespace CJia.Net.Communication.Protocols.CustomProtocol
{
    /// <summary>
    /// This class is a sample custom wire protocol to use as wire protocol in SCS framework.
    /// It extends BinarySerializationProtocol.
    /// It is used just to send/receive ScsTextMessage messages.
    /// 
    /// Since BinarySerializationProtocol automatically writes message length to the beggining
    /// of the message, a message format of this class is:
    /// 
    /// [Message length (4 bytes)][UTF-8 encoded text (N bytes)]
    /// 
    /// So, total length of the message = (N + 4) bytes;
    /// </summary>
    public class TextProtocol : BinarySerializationProtocol
    {
        /// <summary>
        /// 自定义序列化消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected override byte[] SerializeMessage(ICJiaMessage message)
        {
            return Encoding.UTF8.GetBytes(((CJiaTextMessage)message).Text);
        }
        /// <summary>
        /// 自定义反序列化消息
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        protected override ICJiaMessage DeserializeMessage(byte[] bytes)
        {
            //Decode UTF8 encoded text and create a ScsTextMessage object
            using (Serialization.SerializationReader sr = new Serialization.SerializationReader(bytes))
            {
                string msg = sr.ReadOptimizedString();
                return new CJiaTextMessage(msg);
                //return new CJiaTextMessage(Encoding.UTF8.GetString(bytes));
            }
        }
    }
}
