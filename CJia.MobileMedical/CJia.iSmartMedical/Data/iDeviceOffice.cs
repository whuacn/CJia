using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class iDeviceOffice : DataObject
    {
        public iDeviceOffice() 
        {
            this.InitFields("DOID", "DeviceID", "OfficeID", "OfficeName", "CreateDate", "LastSaveDate");
        }

        [PrimaryKey]
        public string DOID { get { return Get(); } set { Set(value); } }
        public string DeviceID { get { return Get(); } set { Set(value); } }
        public string OfficeID { get { return Get(); } set { Set(value); } }
        public string OfficeName { get { return Get(); } set { Set(value); } }
        public string CreateDate { get { return Get(); } set { Set(value); } }
        public string LastSaveDate { get { return Get(); } set { Set(value); } }
    }
}
