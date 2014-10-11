using System;

namespace CJia.iSmartMedical.Messages
{
    /// <summary>
    /// This message is sent as response message to a ScsRemoteInvokeMessage.
    /// It is used to send return value of method invocation.
    /// </summary>
    public class CJiaRemoteInvokeReturnMessage : CJiaMessage
    {
        /// <summary>
        /// Return value of remote method invocation.
        /// </summary>
        public object ReturnValue { get; set; }

        /// <summary>
        /// If any exception occured during method invocation, this field contains Exception object.
        /// If no exception occured, this field is null.
        /// </summary>
        public CJiaRemoteException RemoteException { get; set; }

        /// <summary>
        /// Represents this object as string.
        /// </summary>
        /// <returns>String representation of this object</returns>
        public override string ToString()
        {
            return string.Format("ScsRemoteInvokeReturnMessage: Returns {0}, Exception = {1}", ReturnValue, RemoteException);
        }
        /// <summary>
        /// 序列化数据
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="context"></param>
        public override void SerializeOwnedData(Serialization.SerializationWriter writer, object context)
        {
            base.SerializeOwnedData(writer, context);
            writer.WriteObject(ReturnValue);
            bool hasException = RemoteException != null;
            writer.Write(hasException);
            if (hasException)
            {
                writer.WriteOptimized(RemoteException.Message);
                writer.WriteOptimized(RemoteException.Source);
            }
        }
        /// <summary>
        /// 反序列化数据
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="context"></param>
        public override void DeserializeOwnedData(Serialization.SerializationReader reader, object context)
        {
            base.DeserializeOwnedData(reader, context);
            ReturnValue = reader.ReadObject();
            bool hasException = reader.ReadBoolean();
            if (hasException)
            {
                RemoteException = new CJiaRemoteException(reader.ReadOptimizedString());
                RemoteException.Source = reader.ReadOptimizedString();
            }
        }
    }
}
