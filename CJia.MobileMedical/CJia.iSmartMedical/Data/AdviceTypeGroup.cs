using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class AdviceTypeGroup : DataObject
    {
        public AdviceTypeGroup()
        {
            this.InitFields("AdviceType", "GroupCount");
        }

        public string AdviceType { get { return Get(); } set { Set(value); } }
        public string GroupCount { get { return "共 " + Get() + " 条"; } set { Set(value); } }
    }
}
