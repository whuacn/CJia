using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class iDept : DataObject
    {
        public iDept() 
        {
            this.InitFields("DeptID", "DeptName", "DeptFlag", "Status", "CreateDate");
        }

        [PrimaryKey]
        public string DeptID { get { return Get(); } set { Set(value); } }
        public string DeptName { get { return Get(); } set { Set(value); } }
        public string DeptFlag { get { return Get(); } set { Set(value); } }
        public string Status { get { return Get(); } set { Set(value); } }
        public string CreateDate { get { return Get(); } set { Set(value); } }
    }
}
