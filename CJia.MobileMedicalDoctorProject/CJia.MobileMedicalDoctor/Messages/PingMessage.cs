using System;

namespace CJia.MobileMedicalDoctor.Messages
{
    /// <summary>
    /// This message is used to send/receive ping messages.
    /// Ping messages is used to keep connection alive between server and client.
    /// </summary>
    public sealed class CJiaPingMessage : CJiaMessage
    {
        ///<summary>
        /// Creates a new PingMessage object.
        ///</summary>
        public CJiaPingMessage()
        {

        }

        /// <summary>
        /// Creates a new reply PingMessage object.
        /// </summary>
        /// <param name="repliedMessageId">
        /// Replied message id if this is a reply for
        /// a message.
        /// </param>
        public CJiaPingMessage(string repliedMessageId)
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
                       ? string.Format("ScsPingMessage [{0}]", MessageId)
                       : string.Format("ScsPingMessage [{0}] Replied To [{1}]", MessageId, RepliedMessageId);
        }
    }
}
