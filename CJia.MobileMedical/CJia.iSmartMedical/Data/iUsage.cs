using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class iUsage : DataObject
    {
        public iUsage() 
        {
            this.InitFields("UsageID", "UsageName", "UsageTypeCode", "UsageFilter", "Notes");
        }

        [PrimaryKey]
        public string UsageID { get { return Get(); } set { Set(value); } }
        public string UsageName { get { return Get(); } set { Set(value); } }
        public string UsageTypeCode { get { return Get(); } set { Set(value); } }
        public string UsageFilter { get { return Get(); } set { Set(value); } }
        public string Notes { get { return Get(); } set { Set(value); } }
        public override string ToString()
        {
            return UsageName;
        }
    }
}
