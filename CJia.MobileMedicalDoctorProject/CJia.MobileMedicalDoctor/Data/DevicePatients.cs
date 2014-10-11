using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.MobileMedicalDoctor.Data
{
    public class DevicePatients : DataObject
    {
        public DevicePatients() 
        {
            this.InitFields("DPID", "DeviceID", "InhosID", "SyncStatus", "LastSyncDate", "ChangeType");
        }

        [PrimaryKey]
        public string DPID { get { return Get(); } set { Set(value); } }
        public string DeviceID { get { return Get(); } set { Set(value); } }
        public string InhosID { get { return Get(); } set { Set(value); } }
        public string SyncStatus { get { return Get(); } set { Set(value); } }
        public string LastSyncDate { get { return Get(); } set { Set(value); } }
        public string ChangeType { get { return Get(); } set { Set(value); } }
    }
}
