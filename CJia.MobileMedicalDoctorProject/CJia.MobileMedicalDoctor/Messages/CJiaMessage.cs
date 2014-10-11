using System;

namespace CJia.MobileMedicalDoctor.Messages
{
    /// <summary>
    /// Represents a message that is sent and received by server and client.
    /// This is the base class for all messages.
    /// </summary>
    public class CJiaMessage : ICJiaMessage
    {
        /// <summary>
        /// Unique identified for this message.
        /// Default value: New GUID.
        /// Do not change if you do not want to do low level changes
        /// such as custom wire protocols.
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// This property is used to indicate that this is
        /// a Reply message to a message.
        /// It may be null if this is not a reply message.
        /// </summary>
        public string RepliedMessageId { get; set; }

        /// <summary>
        /// Creates a new ScsMessage.
        /// </summary>
        public CJiaMessage()
        {
            MessageId = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Creates a new reply ScsMessage.
        /// </summary>
        /// <param name="repliedMessageId">
        /// Replied message id if this is a reply for
        /// a message.
        /// </param>
        public CJiaMessage(string repliedMessageId)
            : this()
        {
            RepliedMessageId = repliedMessageId;
        }

        /// <summary>
        /// Creates a string to represents this object.
        /// </summary>
        /// <returns>A string to represents this object</returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(RepliedMessageId)
                       ? string.Format("ScsMessage [{0}]", MessageId)
                       : string.Format("ScsMessage [{0}] Replied To [{1}]", MessageId, RepliedMessageId);
        }

        /// <summary>
        /// 序列化消息体数据
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="context"></param>
        public virtual void SerializeOwnedData(Serialization.SerializationWriter writer, object context)
        {
            string MsgTypeName = this.GetType().Name;
            writer.WriteOptimized(MsgTypeName);//用于在外面根据类别创建实例
            writer.WriteOptimized(this.MessageId);
            writer.WriteOptimized(this.RepliedMessageId);
        }
        /// <summary>
        /// 反序列化消息体
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="context"></param>
        public virtual void DeserializeOwnedData(Serialization.SerializationReader reader, object context)
        {
            MessageId = reader.ReadOptimizedString();
            RepliedMessageId = reader.ReadOptimizedString();
        }
    }
}
