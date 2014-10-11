using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.MobileMedicalDoctor.Data
{
    public class CheckResult : DataObject
    {
        public CheckResult() 
        {
            this.InitFields("ApplyNo", "TechSystem", "SerialNo", "ItemCode", "ItemName", "ItemResult");
        }

        [PrimaryKey]
        public string ApplyNo { get { return Get(); } set { Set(value); } }
        public string TechSystem { get { return Get(); } set { Set(value); } }
        public string SerialNo { get { return Get(); } set { Set(value); } }
        public string ItemCode { get { return Get(); } set { Set(value); } }
        public string ItemName { get { return Get(); } set { Set(value); } }
        public string ItemResult { get { return Get(); } set { Set(value); } }
    }
}
