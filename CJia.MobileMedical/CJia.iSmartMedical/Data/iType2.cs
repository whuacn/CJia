using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class iType2 : DataObject
    {
        public iType2() 
        {
            this.InitFields("AdviceTypeID2", "AdviceTypeName2", "AdviceTypeID", "Status");
        }

        [PrimaryKey]
        public string AdviceTypeID2 { get { return Get(); } set { Set(value); } }
        public string AdviceTypeName2 { get { return Get(); } set { Set(value); } }
        public string AdviceTypeID { get { return Get(); } set { Set(value); } }
        public string Status { get { return Get(); } set { Set(value); } }
    }
}
