using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CJia.iSmartMedical.Data;
using SQLite;

namespace CJia.iSmartMedical.Models
{
    public class ModelBase
    {
        const string ServiceName = "IDoctor";

        public async Task<object> RemoteExcute(object[] Params, [CallerMemberName] string MethodName = "")
        {
            Messages.CJiaRemoteInvokeMessage ivkMessage = new Messages.CJiaRemoteInvokeMessage();
            ivkMessage.MessageId = Guid.NewGuid().ToString();
            ivkMessage.RepliedMessageId = "";
            ivkMessage.ServiceClassName = ServiceName;
            ivkMessage.MethodName = MethodName;
            ivkMessage.Parameters = Params;
            object Result = await SocketHelper.SendMessage(ivkMessage);
            return Result;
        }

        internal void SaveSyncLog(SQLiteConnection conn, Data.SyncLog sl)
        {
            sl.LogID = Guid.NewGuid().ToString();
            sl.DeviceID = iCommon.DeviceID;
            sl.InhosID = iCommon.Patient.InhosID;
            sl.ChangeDate = iCommon.DateNow;
            conn.Insert(sl);
        }

        #region 反序列化
        /// <summary>
        /// 将byte[]反序列化DataTable
        /// </summary>
        /// <param name="ListData"></param>
        /// <returns></returns>
        public List<T> Deserialize<T>(byte[] ListData) where T : DataObject, new()
        {
            if (ListData == null) return null;
            List<T> DataList = new List<T>();
            using (Serialization.SerializationReader sr = new Serialization.SerializationReader(ListData))
            {
                Dictionary<string, int> Fields = new Dictionary<string, int>();
                BuildFieldDict(sr, Fields);
                while (sr.BytesRemaining != 0)
                {
                    T dataObject = new T();
                    dataObject.Fields = Fields;
                    dataObject.Data = sr.ReadOptimizedObjectArray();
                    DataList.Add(dataObject);
                }
            }
            return DataList;
        }
        /// <summary>
        /// 根据表结构创建数据表
        /// </summary>
        /// <param name="sr">反序列化工具</param>
        /// <returns></returns>
        void BuildFieldDict(Serialization.SerializationReader sr, Dictionary<string, int> dataFields)
        {
            dataFields.Clear();
            string colName, colType, tableName = "";
            string[] arySchema;
            int rowsCount = sr.ReadOptimizedInt32();
            int colsCount = 0;
            Dictionary<string, int> listColumn = new Dictionary<string, int>(rowsCount);
            for (int i = 0; i < rowsCount; i++)
            {
                arySchema = sr.ReadOptimizedStringArray();
                tableName = arySchema[0];
                colName = arySchema[1];
                colType = arySchema[2];

                if (!listColumn.TryGetValue(colName, out colsCount))
                {
                    listColumn.Add(colName, 1);
                }
                else
                {
                    listColumn[colName] = colsCount + 1;
                    colName = colName + "_" + colsCount.ToString();
                }

                dataFields.Add(colName, i);
            }
            listColumn.Clear();
            listColumn = null;
        }
        #endregion
    }
}
