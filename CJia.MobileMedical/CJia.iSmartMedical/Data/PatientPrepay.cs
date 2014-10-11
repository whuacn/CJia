using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class PatientPrepay : DataObject
    {
        public PatientPrepay() 
        {
            this.InitFields("InhosID", "Prepay", "PayDate", "Status", "BalanceDate");
        }

        [PrimaryKey]
        public string InhosID { get { return Get(); } set { Set(value); } }
        public decimal Prepay { get { return GetDecimal(); } set { Set(value); } }
        public string PayDate { get { return Get(); } set { Set(value); } }
        public string Status { get { return Get(); } set { Set(value); } }
        public string BalanceDate { get { return Get(); } set { Set(value); } }
    }
}
