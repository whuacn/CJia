using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class iIllfieldDept : DataObject
    {
        public iIllfieldDept() 
        {
            this.InitFields("IllfieldID", "DeptID");
        }

        [PrimaryKey]
        public string IllfieldID { get { return Get(); } set { Set(value); } }
        public string DeptID { get { return Get(); } set { Set(value); } }
    }
}
