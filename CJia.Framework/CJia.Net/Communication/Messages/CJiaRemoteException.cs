using System;
using System.Runtime.Serialization;

namespace CJia.Net.Communication.Messages
{
    /// <summary>
    /// Represents a SCS Remote Exception.
    /// This exception is used to send an exception from an application to another application.
    /// </summary>
    [Serializable]
    public class CJiaRemoteException : Exception
    {
        /// <summary>
        /// Contstructor.
        /// </summary>
        public CJiaRemoteException()
        {

        }

        /// <summary>
        /// Contstructor.
        /// </summary>
        public CJiaRemoteException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
            
        }

        /// <summary>
        /// Contstructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        public CJiaRemoteException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Contstructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public CJiaRemoteException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
