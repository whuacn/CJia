using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.iSmartMedical.Data
{
    public class PatientFee : DataObject
    {
        public PatientFee() 
        {
            this.InitFields("InhosID", "FeeTypeCode", "FeeTypeName", "FeeSum");
        }

        [PrimaryKey]
        public string InhosID { get { return Get(); } set { Set(value); } }
        public string FeeTypeCode { get { return Get(); } set { Set(value); } }
        public string FeeTypeName { get { return Get(); } set { Set(value); } }
        public decimal FeeSum { get { return GetDecimal(); } set { Set(value); } }
    }
}
