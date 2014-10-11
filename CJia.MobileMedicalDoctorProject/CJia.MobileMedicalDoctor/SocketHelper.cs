using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace CJia.MobileMedicalDoctor
{
    public static class SocketHelper
    {
        const uint MsgHeaderLength = 4;
        static SocketHelper()
        {

        }
        static StreamSocket clientSocket = new StreamSocket();

        static bool hasConnected = false;

        /// <summary>
        /// 连接服务器
        /// </summary>
        public static async Task<bool> ConnectServer()
        {
            if (hasConnected) return true;
            clientSocket = new StreamSocket();
            clientSocket.Control.KeepAlive = true;
            await clientSocket.ConnectAsync(new HostName("yy-PC"), "10920");
            hasConnected = true;
            return true;
        }
        static DataWriter _Writer = null;
        static DataWriter Writer
        {
            get
            {
                if (_Writer != null) return _Writer;
                _Writer = new DataWriter(clientSocket.OutputStream);
                return _Writer;
            }
        }
        static DataReader _Reader = null;
        static DataReader Reader
        {
            get
            {
                if (_Reader != null) return _Reader;
                _Reader = new DataReader(clientSocket.InputStream);
                return _Reader;
            }
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="Msg"></param>
        public static async Task<object> SendMessage(Messages.ICJiaMessage Msg)
        {
            try
            {
                await ConnectServer();
                byte[] byteMsg = SerializationMessage(Msg);
                byte[] byteSend = PrepareSendData(byteMsg);
                Writer.WriteBytes(byteSend);
                //发送消息
                await Writer.StoreAsync();
                //等待返回值
                var ResponseMsg = await WaitResponseMessage();
                if (ResponseMsg.RemoteException != null)
                    throw ResponseMsg.RemoteException;
                return ResponseMsg.ReturnValue;
            }
            catch (Exception ex)
            {
                SocketErrorStatus ses = SocketError.GetStatus(ex.HResult);
                if (ses != SocketErrorStatus.Unknown)
                {
                    CloseConnection();
                }
                //SocketError.GetStatus(ex.HResult).ToString()
                MessageDialog msgDialog = new MessageDialog(ex.Message);
                msgDialog.ShowAsync();
                return null;
            }
        }

        static void CloseConnection()
        {
            hasConnected = false;
            clientSocket.Dispose();
            _Writer.DetachStream();
            _Writer.Dispose();
            _Reader.DetachStream();
            _Reader.Dispose();
            _Writer = null;
            _Reader = null;
        }

        async static Task<Messages.CJiaRemoteInvokeReturnMessage> WaitResponseMessage()
        {
            while (true)
            {
                // 读取4字节的消息头
                uint sizeFieldCount = await Reader.LoadAsync(MsgHeaderLength);
                if (sizeFieldCount != MsgHeaderLength)
                {//读取所有数据前连接关闭了
                    CloseConnection();
                    throw new Exception("连接中断，等待返回数据异常");
                }
                // Read the string.
                uint stringLength = Reader.ReadUInt32();
                uint actualStringLength = await Reader.LoadAsync(stringLength);
                if (stringLength != actualStringLength)
                {
                    //读取所有数据前连接关闭了
                    return null;
                }
                byte[] dataMsg = new byte[actualStringLength];
                Reader.ReadBytes(dataMsg);
                using (Serialization.SerializationReader sr = new Serialization.SerializationReader(dataMsg))
                {
                    string msgTypeName = sr.ReadOptimizedString();
                    if (msgTypeName != "CJiaRemoteInvokeReturnMessage")
                        throw new Exception("返回消息类型异常。");
                    Messages.CJiaRemoteInvokeReturnMessage ivkMsg = new Messages.CJiaRemoteInvokeReturnMessage();
                    ivkMsg.DeserializeOwnedData(sr, null);
                    return ivkMsg;
                }
            }
        }

        static byte[] PrepareSendData(byte[] byteMsg)
        {
            int msgLength = byteMsg.Length;
            var byteSend = new byte[msgLength + 4];
            WriteInt32(byteSend, 0, msgLength);
            Array.Copy(byteMsg, 0, byteSend, 4, msgLength);
            return byteSend;
        }

        static byte[] SerializationMessage(Messages.ICJiaMessage Msg)
        {
            using (Serialization.SerializationWriter sw = new Serialization.SerializationWriter())
            {
                Msg.SerializeOwnedData(sw, null);
                return sw.ToArray();
            }
        }

        /// <summary>
        /// Writes a int value to a byte array from a starting index.
        /// </summary>
        /// <param name="buffer">Byte array to write int value</param>
        /// <param name="startIndex">Start index of byte array to write</param>
        /// <param name="number">An integer value to write</param>
        private static void WriteInt32(byte[] buffer, int startIndex, int number)
        {
            buffer[startIndex] = (byte)((number >> 24) & 0xFF);
            buffer[startIndex + 1] = (byte)((number >> 16) & 0xFF);
            buffer[startIndex + 2] = (byte)((number >> 8) & 0xFF);
            buffer[startIndex + 3] = (byte)((number) & 0xFF);
        }

        /// <summary>
        /// Deserializes and returns a serialized integer.
        /// </summary>
        /// <returns>Deserialized integer</returns>
        private static int ReadInt32(Stream stream)
        {
            var buffer = ReadByteArray(stream, 4);
            return ((buffer[0] << 24) |
                    (buffer[1] << 16) |
                    (buffer[2] << 8) |
                    (buffer[3])
                   );
        }

        /// <summary>
        /// Reads a byte array with specified length.
        /// </summary>
        /// <param name="stream">Stream to read from</param>
        /// <param name="length">Length of the byte array to read</param>
        /// <returns>Read byte array</returns>
        /// <exception cref="EndOfStreamException">Throws EndOfStreamException if can not read from stream.</exception>
        private static byte[] ReadByteArray(Stream stream, int length)
        {
            var buffer = new byte[length];
            var totalRead = 0;
            while (totalRead < length)
            {
                var read = stream.Read(buffer, totalRead, length - totalRead);
                if (read <= 0)
                {
                    throw new EndOfStreamException("Can not read from stream! Input stream is closed.");
                }

                totalRead += read;
            }

            return buffer;
        }
    }
}
