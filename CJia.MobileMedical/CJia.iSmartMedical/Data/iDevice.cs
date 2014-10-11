using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class iDevice : DataObject
    {
        public iDevice() 
        {
            this.InitFields("DeviceID", "DeviceName", "Status", "Notes", "CreateDate", "LastSaveDate");
        }

        [PrimaryKey]
        public string DeviceID { get { return Get(); } set { Set(value); } }
        public string DeviceName { get { return Get(); } set { Set(value); } }
        public string Status { get { return Get(); } set { Set(value); } }
        public string Notes { get { return Get(); } set { Set(value); } }
        public string CreateDate { get { return Get(); } set { Set(value); } }
        public string LastSaveDate { get { return Get(); } set { Set(value); } }
    }
}
