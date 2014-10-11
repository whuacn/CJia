using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.MobileMedicalDoctor.Data
{
    public class iAdvice : DataObject
    {
        public iAdvice() 
        {
            this.InitFields("AID", "AdviceID", "AdviceType", "StandingType", "AdviceCode", "AdviceName", "CommonName",
                "AdviceFilter", "Spec", "Price", "Unit", "Factory", "Notes", "DefaultDosage", "DefaultUsage", "DefaultFrequency", "DefaultPharmType");
        }

        [PrimaryKey]
        public string AID { get { return Get(); } set { Set(value); } }
        public string AdviceID { get { return Get(); } set { Set(value); } }
        public string AdviceType { get { return Get(); } set { Set(value); } }
        /// <summary>
        /// 0：临时1：长期9：长临均可
        /// </summary>
        public string StandingType { get { return Get(); } set { Set(value); } }
        public string AdviceCode { get { return Get(); } set { Set(value); } }
        public string AdviceName { get { return Get(); } set { Set(value); } }
        public string CommonName { get { return Get(); } set { Set(value); } }
        public string AdviceFilter { get { return Get(); } set { Set(value); } }
        public string Spec { get { return Get(); } set { Set(value); } }
        public string Price { get { return Get(); } set { Set(value); } }
        public string Unit { get { return Get(); } set { Set(value); } }
        public string Factory { get { return Get(); } set { Set(value); } }
        public string Notes { get { return Get(); } set { Set(value); } }
        public string DefaultDosage { get { return Get(); } set { Set(value); } }
        public string DefaultUsage { get { return Get(); } set { Set(value); } }
        public string DefaultFrequency { get { return Get(); } set { Set(value); } }
        public string DefaultPharmType { get { return Get(); } set { Set(value); } }
        public override string ToString()
        {
            return AdviceName;
        }
    }
}
