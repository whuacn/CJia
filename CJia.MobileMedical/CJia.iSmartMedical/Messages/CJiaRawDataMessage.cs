using System;

namespace CJia.iSmartMedical.Messages
{
    /// <summary>
    /// This message is used to send/receive a raw byte array as message data.
    /// </summary>
    public class CJiaRawDataMessage : CJiaMessage
    {
        /// <summary>
        /// Message data that is being transmitted.
        /// </summary>
        public byte[] MessageData { get; set; }

        /// <summary>
        /// Default empty constructor.
        /// </summary>
        public CJiaRawDataMessage()
        {
            
        }

        /// <summary>
        /// Creates a new ScsRawDataMessage object with MessageData property.
        /// </summary>
        /// <param name="messageData">Message data that is being transmitted</param>
        public CJiaRawDataMessage(byte[] messageData)
        {
            MessageData = messageData;
        }

                /// <summary>
        /// Creates a new reply ScsRawDataMessage object with MessageData property.
        /// </summary>
        /// <param name="messageData">Message data that is being transmitted</param>
        /// <param name="repliedMessageId">
        /// Replied message id if this is a reply for
        /// a message.
        /// </param>
        public CJiaRawDataMessage(byte[] messageData, string repliedMessageId)
            : this(messageData)
        {
            RepliedMessageId = repliedMessageId;
        }

        /// <summary>
        /// Creates a string to represents this object.
        /// </summary>
        /// <returns>A string to represents this object</returns>
        public override string ToString()
        {
            var messageLength = MessageData == null ? 0 : MessageData.Length;
            return string.IsNullOrEmpty(RepliedMessageId)
                       ? string.Format("ScsRawDataMessage [{0}]: {1} bytes", MessageId, messageLength)
                       : string.Format("ScsRawDataMessage [{0}] Replied To [{1}]: {2} bytes", MessageId, RepliedMessageId, messageLength);
        }
        /// <summary>
        /// 序列化数据
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="context"></param>
        public override void SerializeOwnedData(Serialization.SerializationWriter writer, object context)
        {
            base.SerializeOwnedData(writer, context);
            writer.Write(MessageData);
        }
        /// <summary>
        /// 反序列化数据
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="context"></param>
        public override void DeserializeOwnedData(Serialization.SerializationReader reader, object context)
        {
            base.DeserializeOwnedData(reader, context);
            MessageData = reader.ReadByteArray();
        }
    }
}
