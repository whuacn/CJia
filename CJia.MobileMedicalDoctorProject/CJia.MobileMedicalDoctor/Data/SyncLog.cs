using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.MobileMedicalDoctor.Data
{
    public class SyncLog : DataObject
    {
        public SyncLog() 
        {
            this.InitFields("LogID", "TableName", "KeyField", "KeyValue", "ChangeType", "ChangeDate");
        }

        [PrimaryKey]
        public string LogID { get { return Get(); } set { Set(value); } }
        public string TableName { get { return Get(); } set { Set(value); } }
        public string KeyField { get { return Get(); } set { Set(value); } }
        public string KeyValue { get { return Get(); } set { Set(value); } }
        public string ChangeType { get { return Get(); } set { Set(value); } }
        public string ChangeDate { get { return Get(); } set { Set(value); } }
    }
}
