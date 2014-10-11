using System;
namespace CJia.MobileMedicalDoctor.Messages
{
    /// <summary>
    /// Represents a message that is sent and received by server and client.
    /// </summary>
    public interface ICJiaMessage
    {
        /// <summary>
        /// Unique identified for this message. 
        /// </summary>
        string MessageId { get; }

        /// <summary>
        /// Unique identified for this message. 
        /// </summary>
        string RepliedMessageId { get; set; }

        /// <summary>
        /// Lets the implementing class store internal data directly into a SerializationWriter.
        /// </summary>
        /// <param name="writer">The SerializationWriter to use</param>
        /// <param name="context">Optional context to use as a hint as to what to store (BitVector32 is useful)</param>
        void SerializeOwnedData(Serialization.SerializationWriter writer, object context);

        /// <summary>
        /// Lets the implementing class retrieve internal data directly from a SerializationReader.
        /// </summary>
        /// <param name="reader">The SerializationReader to use</param>
        /// <param name="context">Optional context to use as a hint as to what to retrieve (BitVector32 is useful) </param>
        void DeserializeOwnedData(Serialization.SerializationReader reader, object context);
    }
}
