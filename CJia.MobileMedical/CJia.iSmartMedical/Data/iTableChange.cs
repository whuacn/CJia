using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class iTableChange : DataObject
    {
        public iTableChange() 
        {
            this.InitFields("TableName", "PrimaryKey", "LastChangeDate");
        }

        [PrimaryKey]
        public string TableName { get { return Get(); } set { Set(value); } }
        public string PrimaryKey { get { return Get(); } set { Set(value); } }
        public string LastChangeDate { get { return Get(); } set { Set(value); } }
    }
}
