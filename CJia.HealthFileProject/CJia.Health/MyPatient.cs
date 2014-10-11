using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health
{
    /// <summary>
    /// 病案查询条件
    /// </summary>
    public class MyPatient
    {
        /// <summary>
        /// 病案号
        /// </summary>
        public string RecordNO { get; set; }
        /// <summary>
        /// 病人id
        /// </summary>
        public string PatientID { get; set; }
        /// <summary>
        /// 出院开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        ///出院截止时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 出院诊断
        /// </summary>
        public string CYZD { get; set; }
        /// <summary>
        /// 治疗结果
        /// </summary>
        public string ZLJG { get; set; }
        /// <summary>
        /// 手术名称
        /// </summary>
        public string SSMC { get; set; }
        /// <summary>
        /// 院内感染
        /// </summary>
        public string YNGR { get; set; }
        /// <summary>
        /// 病理诊断
        /// </summary>
        public string BLZD { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string Provice { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 入院科室
        /// </summary>
        public string RYDept { get; set; }
        /// <summary>
        /// 入院医师
        /// </summary>
        public string RYDoctor { get; set; }
        /// <summary>
        /// 出院科室
        /// </summary>
        public string CYDept { get; set; }
        /// <summary>
        /// 出院医师
        /// </summary>
        public string CYDoctor { get; set; }
    }
}
