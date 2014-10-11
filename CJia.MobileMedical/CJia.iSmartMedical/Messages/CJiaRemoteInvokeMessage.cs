using System;

namespace CJia.iSmartMedical.Messages
{
    /// <summary>
    /// This message is sent to invoke a method of a remote application.
    /// </summary>
    public class CJiaRemoteInvokeMessage : CJiaMessage
    {
        /// <summary>
        /// Name of the remove service class.
        /// </summary>
        public string ServiceClassName { get; set; }

        /// <summary>
        /// Method of remote application to invoke.
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// Parameters of method.
        /// </summary>
        public object[] Parameters { get; set; }

        /// <summary>
        /// Represents this object as string.
        /// </summary>
        /// <returns>String representation of this object</returns>
        public override string ToString()
        {
            return string.Format("ScsRemoteInvokeMessage: {0}.{1}(...)", ServiceClassName, MethodName);
        }
        /// <summary>
        /// 序列化数据
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="context"></param>
        public override void SerializeOwnedData(Serialization.SerializationWriter writer, object context)
        {
            base.SerializeOwnedData(writer, context);
            writer.WriteOptimized(ServiceClassName);
            writer.WriteOptimized(MethodName);
            writer.WriteOptimized(Parameters);
        }
        /// <summary>
        /// 反序列化数据
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="context"></param>
        public override void DeserializeOwnedData(Serialization.SerializationReader reader, object context)
        {
            base.DeserializeOwnedData(reader, context);
            ServiceClassName = reader.ReadOptimizedString();
            MethodName = reader.ReadOptimizedString();
            Parameters = reader.ReadOptimizedObjectArray();
        }
    }
}
