using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.MobileMedicalDoctor.Data
{
    public class iFrequency : DataObject
    {
        public iFrequency() 
        {
            this.InitFields("FrequencyID", "FrequencyName", "FrequencyFilter", "StandingFlag", "UseFlag", "OrderSeq", "Notes");
        }

        [PrimaryKey]
        public string FrequencyID { get { return Get(); } set { Set(value); } }
        public string FrequencyName { get { return Get(); } set { Set(value); } }
        public string FrequencyFilter { get { return Get(); } set { Set(value); } }
        public string StandingFlag { get { return Get(); } set { Set(value); } }
        public string UseFlag { get { return Get(); } set { Set(value); } }
        public string OrderSeq { get { return Get(); } set { Set(value); } }
        public string Notes { get { return Get(); } set { Set(value); } }
        public override string ToString()
        {
            return FrequencyName;
        }
    }
}
