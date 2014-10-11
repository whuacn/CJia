using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJia.CheckRegOrder
{
    /// <summary>
    /// 病史类
    /// </summary>
    public class PatientHistory
    {
        /// <summary>
        /// 病人id
        /// </summary>
        public int? PatientID { get; set; }
        /// <summary>
        /// 初潮年龄
        /// </summary>
        public string MensesFirstAge { get; set; }
        /// <summary>
        /// 平时月经周期
        /// </summary>
        public string Cycle { get; set; }
        /// <summary>
        /// 末次月经时间
        /// </summary>
        public DateTime? LastDate { get; set; }
        /// <summary>
        /// 绝经年龄
        /// </summary>
        public string LastAge { get; set; }
        /// <summary>
        /// 初产年龄
        /// </summary>
        public string PrimiparityAge { get; set; }
        /// <summary>
        /// 第一次性交年龄
        /// </summary>
        public string FirstSexAge { get; set; }
        /// <summary>
        /// 怀孕次数
        /// </summary>
        public string PregnancyNum { get; set; }
        /// <summary>
        /// 生育次数
        /// </summary>
        public string BirthNum { get; set; }
        /// <summary>
        /// 避孕方法
        /// </summary>
        public string Contraception { get; set; }
        /// <summary>
        /// 有无哺乳
        /// </summary>
        public string Suckle { get; set; }
        /// <summary>
        /// 宫颈炎严重程度
        /// </summary>
        public string Severity { get; set; }
        /// <summary>
        /// 宫颈炎CIN
        /// </summary>
        public string CIN { get; set; }
        /// <summary>
        /// 宫颈瘤阶段
        /// </summary>
        public string Stage { get; set; }
        /// <summary>
        /// 宫颈治疗方法
        /// </summary>
        public string TreatWay { get; set; }
        /// <summary>
        /// 宫颈治疗时间
        /// </summary>
        public DateTime? TreatDate { get; set; }
        /// <summary>
        /// 直系家属是否有肿瘤史
        /// </summary>
        public string TumourHistory { get; set; }
        /// <summary>
        /// 肿瘤部位
        /// </summary>
        public string TumourPart { get; set; }
        /// <summary>
        /// 自觉症状 白带数量
        /// </summary>
        public string LeucorrheaNum { get; set; }
        /// <summary>
        /// 自觉症状 是否溶血
        /// </summary>
        public string Hemolysis { get; set; }
        /// <summary>
        /// 自觉症状 是否腰酸
        /// </summary>
        public string Waist { get; set; }
    }
}
