using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class SyncLog : DataObject
    {
        public SyncLog()
        {
            this.InitFields("LogID", "DeviceID", "InhosID", "TableName", "KeyField", "KeyValue", "ChangeType", "ChangeDate");
        }

        [PrimaryKey]
        public string LogID { get { return Get(); } set { Set(value); } }
        public string DeviceID { get { return Get(); } set { Set(value); } }
        public string InhosID { get { return Get(); } set { Set(value); } }
        public string TableName { get { return Get(); } set { Set(value); } }
        public string KeyField { get { return Get(); } set { Set(value); } }
        public string KeyValue { get { return Get(); } set { Set(value); } }
        public string ChangeType { get { return Get(); } set { Set(value); } }
        public string ChangeDate { get { return Get(); } set { Set(value); } }
    }
}
