using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class iCode : DataObject
    {
        public iCode() 
        {
            this.InitFields("Code", "Name", "Value", "GroupName", "Code2", "Remark", "Status");
        }

        [PrimaryKey]
        public string Code { get { return Get(); } set { Set(value); } }
        public string Name { get { return Get(); } set { Set(value); } }
        public string Value { get { return Get(); } set { Set(value); } }
        public string GroupName { get { return Get(); } set { Set(value); } }
        public string Code2 { get { return Get(); } set { Set(value); } }
        public string Remark { get { return Get(); } set { Set(value); } }
        public string Status { get { return Get(); } set { Set(value); } }

        public override string ToString()
        {
            return Name;
        }
    }
}
