using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class iDeviceTableChange : DataObject
    {
        public iDeviceTableChange() 
        {
            this.InitFields("DeviceID", "TableName", "PrimaryKey", "LastChangeDate");
        }

        [PrimaryKey]
        public string DeviceID { get { return Get(); } set { Set(value); } }
        public string TableName { get { return Get(); } set { Set(value); } }
        public string PrimaryKey { get { return Get(); } set { Set(value); } }
        public string LastChangeDate { get { return Get(); } set { Set(value); } }
    }
}
