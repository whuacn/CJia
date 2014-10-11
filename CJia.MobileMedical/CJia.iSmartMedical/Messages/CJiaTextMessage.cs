using System;

namespace CJia.iSmartMedical.Messages
{
    /// <summary>
    /// This message is used to send/receive a text as message data.
    /// </summary>
    public class CJiaTextMessage : CJiaMessage
    {
        /// <summary>
        /// Message text that is being transmitted.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Creates a new ScsTextMessage object.
        /// </summary>
        public CJiaTextMessage()
        {
            
        }

        /// <summary>
        /// Creates a new ScsTextMessage object with Text property.
        /// </summary>
        /// <param name="text">Message text that is being transmitted</param>
        public CJiaTextMessage(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Creates a new reply ScsTextMessage object with Text property.
        /// </summary>
        /// <param name="text">Message text that is being transmitted</param>
        /// <param name="repliedMessageId">
        /// Replied message id if this is a reply for
        /// a message.
        /// </param>
        public CJiaTextMessage(string text, string repliedMessageId)
            : this(text)
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
                       ? string.Format("ScsTextMessage [{0}]: {1}", MessageId, Text)
                       : string.Format("ScsTextMessage [{0}] Replied To [{1}]: {2}", MessageId, RepliedMessageId, Text);
        }
        /// <summary>
        /// 序列化数据
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="context"></param>
        public override void SerializeOwnedData(Serialization.SerializationWriter writer, object context)
        {
            base.SerializeOwnedData(writer, context);
            writer.WriteOptimized(Text);
        }
        /// <summary>
        /// 反序列化数据
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="context"></param>
        public override void DeserializeOwnedData(Serialization.SerializationReader reader, object context)
        {
            base.DeserializeOwnedData(reader, context);
            Text = reader.ReadOptimizedString();
        }
    }
}
