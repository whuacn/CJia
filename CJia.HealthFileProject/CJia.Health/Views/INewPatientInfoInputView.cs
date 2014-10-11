using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Views
{
    public interface INewPatientInfoInputView : CJia.Health.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnInit;

        /// <summary>
        /// 保存病人基本信息事件
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnSavePatientInfo;

        /// <summary>
        /// 根据省筛选市
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnProvinceTextChanged;

        /// <summary>
        /// 焦点离开病案号时查询库中是否存在相同病案号
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnCheckIsExistSameRecordNoAndInHospitalTime;

        /// <summary>
        /// 焦点聚焦ComBox2后按下数字快捷选择键
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnKeyPressComBox2;

        #region 绑定下拉选择框
        /// <summary>
        /// 绑定性别
        /// </summary>
        /// <param name="dtGender"></param>
        void ExeBindGender(DataTable dtGender);
        
        /// <summary>
        /// 绑定省(直辖市)
        /// </summary>
        /// <param name="dtProvince"></param>
        void ExeBindProvince(DataTable dtProvince);

        /// <summary>
        /// 绑定市
        /// </summary>
        /// <param name="dtCity"></param>
        void ExeBindCity(DataTable dtCity);
         
        /// <summary>
        /// 绑定科室
        /// </summary>
        /// <param name="dtDept"></param>
        void ExeBindDept(DataTable dtDept);

        /// <summary>
        /// 入院部门
        /// </summary>
        /// <param name="dtIndeptSearch"></param>
        void ExeInDept(DataTable dtIndeptSearch);

        /// <summary>
        /// 出院部门
        /// </summary>
        /// <param name="dtOutDeptSearch"></param>
        void ExeOutDept(DataTable dtOutDeptSearch);
        
        /// <summary>
        /// 绑定ICD编码
        /// </summary>
        /// <param name="dtICDCode"></param>
        void ExeBindICDCode(DataTable dtICDCode);

        /// <summary>
        /// 绑定治疗结果
        /// </summary>
        /// <param name="dtTreatResult"></param>
        void ExeBindTreatResult(DataTable dtTreatResult);
        #endregion

        #region 模糊查询事件和绑定
        /// <summary>
        /// 省模糊查询事件
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnProviceSearch;

        /// <summary>
        /// 市模糊查询
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnCitySearch;

        /// <summary>
        /// 入院科室模糊查询
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnInHospitalDeptSearch;

        /// <summary>
        /// 出院科室模糊查询
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnOutHospitalDeptSearch;

        /// <summary>
        /// ICD编码（出院诊断1）事件
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnICDOutDia1Search;

        /// <summary>
        /// ICD编码（出院诊断2）事件
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnICDOutDia2Search;

        /// <summary>
        /// ICD编码（出院诊断3）事件
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnICDOutDia3Search;

        /// <summary>
        /// ICD编码（出院诊断4）事件
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnICDOutDia4Search;

        /// <summary>
        /// ICD编码（手术名称1）事件
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnICDSurgery1Search;

        /// <summary>
        /// ICD编码（手术名称2）事件
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnICDSurgery2Search;

        /// <summary>
        /// ICD编码（手术名称3）事件
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnICDSurgery3Search;

        /// <summary>
        /// ICD编码（手术名称4）事件
        /// </summary>
        event EventHandler<NewPatientInfoInputEventArgs> OnICDSurgery4Search;

        /// <summary>
        /// ICD编码（出院诊断1）
        /// </summary>
        /// <param name="dtICDOutDia1"></param>
        void ExeICDOutDia1(DataTable dtICDOutDia1);

        /// <summary>
        /// ICD编码（出院诊断2）
        /// </summary>
        /// <param name="dtICDOutDia2"></param>
        void ExeICDOutDia2(DataTable dtICDOutDia2);

        /// <summary>
        /// ICD编码（出院诊断3）
        /// </summary>
        /// <param name="dtICDOutDia3"></param>
        void ExeICDOutDia3(DataTable dtICDOutDia3);

        /// <summary>
        /// ICD编码（出院诊断4）
        /// </summary>
        /// <param name="dtICDOutDia4"></param>
        void ExeICDOutDia4(DataTable dtICDOutDia4);

        /// <summary>
        /// ICD编码（手术名称1）
        /// </summary>
        /// <param name="dtICDSurgery1"></param>
        void ExeICDSurgery1(DataTable dtICDSurgery1);

        /// <summary>
        /// ICD编码（手术名称2）
        /// </summary>
        /// <param name="dtICDSurgery1"></param>
        void ExeICDSurgery2(DataTable dtICDSurgery2);

        /// <summary>
        /// ICD编码（手术名称3）
        /// </summary>
        /// <param name="dtICDSurgery3"></param>
        void ExeICDSurgery3(DataTable dtICDSurgery3);

        /// <summary>
        /// ICD编码（手术名称4）
        /// </summary>
        /// <param name="dtICDSurgery4"></param>
        void ExeICDSurgery4(DataTable dtICDSurgery4);     
        #endregion
    }

    /// <summary>
    /// 参数类
    /// </summary>
    public class NewPatientInfoInputEventArgs : EventArgs
    {
        /// <summary>
        /// 是否有相同病案号+入院次数
        /// </summary>
        public bool IsReturn = false;

        /// <summary>
        /// 所选择省ID
        /// </summary>
        public string SelectedProvinceId = "";

        /// <summary>
        /// 根据科室筛选医生
        /// </summary>
        public string SelectedDeptId = "";

        /// <summary>
        /// 模糊查询所传值
        /// </summary>
        public string StrFuzzySearch = "";

        /// <summary>
        /// 控件所绑DataTable数据源
        /// </summary>
        public DataTable TableFuzzySearch = null;

        /// <summary>
        /// 根据病案号查询gm_patient信息
        /// </summary>
        public DataTable TablePatientInfoByRecordNo = null;

        /// <summary>
        /// 根据省所查询到的市
        /// </summary>
        public DataTable TableCity;

        /// <summary>
        /// 按下数字键对应内容显示下拉框
        /// </summary>
        public DataTable TableCombox2;

        /// <summary>
        /// 取得焦点所取得是哪个下拉控件（数字快捷键选择）
        /// </summary>
        public string ComBox2Type;

        /// <summary>
        /// 从接口中读取的病人信息
        /// </summary>
        public DataTable TablePatientFromInterface;

        #region 病人表基本字段
        /// <summary>
        /// 病案号
        /// </summary>
        public string RecordNo = "";

        /// <summary>
        /// 档案所存货架号
        /// </summary>
        public string ShelfNo = "";

        /// <summary>
        /// 病人ID
        /// </summary>
        public string PatientId = "";

        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName = "";

        /// <summary>
        /// 是否为特殊病案(1:是;0:不是)
        /// </summary>
        public string IsSpecial = "";

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender = "";

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? BirthDate;

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string IsMarry = "";

        /// <summary>
        /// 职业
        /// </summary>
        public string Job = "";

        /// <summary>
        /// 省
        /// </summary>
        public string Province = "";

        /// <summary>
        /// 市（县）
        /// </summary>
        public string City = "";

        /// <summary>
        /// 民族
        /// </summary>
        public string Nation = "";

        /// <summary>
        /// 国籍
        /// </summary>
        public string Country = "";

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCard = "";

        /// <summary>
        /// 入院方式
        /// </summary>
        public string InHospitalType = "";

        /// <summary>
        /// 入院次数
        /// </summary>
        public int InHospitalTime = 0;

        /// <summary>
        /// 入院日期
        /// </summary>
        public DateTime? InHospitalDate;

        /// <summary>
        /// 出院日期
        /// </summary>
        public DateTime? OutHospitalDate;

        /// <summary>
        /// 入院科室
        /// </summary>
        public string InHospitalDept = "";

        /// <summary>
        /// 出院科室
        /// </summary>
        public string OutHospitalDept = "";

        ///// <summary>
        ///// 入院医师
        ///// </summary>
        //public string InHospitalDoctor = "";

        ///// <summary>
        ///// 出院医师
        ///// </summary>
        //public string OutHospitalDoctor = "";

        /// <summary>
        /// 入院病室
        /// </summary>
        public string InHospitalRoom = "";

        /// <summary>
        /// 出院病室
        /// </summary>
        public string OutHospitalRoom = "";

        /// <summary>
        /// 药物过敏
        /// </summary>
        public string DrugAllergy = "";

        /// <summary>
        /// 血型
        /// </summary>
        public string BloodType = "";

        /// <summary>
        /// ICD编码(出院诊断1)
        /// </summary>
        public string ICDOutDia1 = "";

        /// <summary>
        /// 出院诊断1
        /// </summary>
        public string OutDiaName1 = "";

        /// <summary>
        /// ICD编码(出院诊断2)
        /// </summary>
        public string ICDOutDia2 = "";

        /// <summary>
        /// 出院诊断2
        /// </summary>
        public string OutDiaName2 = "";

        /// <summary>
        /// ICD编码(出院诊断3)
        /// </summary>
        public string ICDOutDia3 = "";

        /// <summary>
        /// 出院诊断3
        /// </summary>
        public string OutDiaName3 = "";

        /// <summary>
        /// ICD编码(出院诊断4)
        /// </summary>
        public string ICDOutDia4 = "";

        /// <summary>
        /// 出院诊断4
        /// </summary>
        public string OutDiaName4 = "";

        /// <summary>
        /// ICD编码(手术名称1)
        /// </summary>
        public string ICDSurgery1 = "";

        /// <summary>
        /// 手术名称1
        /// </summary>
        public string SurgeryName1 = "";

        /// <summary>
        /// ICD编码(手术名称2)
        /// </summary>
        public string ICDSurgery2 = "";

        /// <summary>
        /// 手术名称2
        /// </summary>
        public string SurgeryName2 = "";

        /// <summary>
        /// ICD编码(手术名称3)
        /// </summary>
        public string ICDSurgery3 = "";

        /// <summary>
        /// 手术名称3
        /// </summary>
        public string SurgeryName3 = "";

        /// <summary>
        /// ICD编码(手术名称4)
        /// </summary>
        public string ICDSurgery4 = "";

        /// <summary>
        /// 手术名称4
        /// </summary>
        public string SurgeryName4 = "";

        /// <summary>
        /// 治疗结果1
        /// </summary>
        public string TreatResult1 = "";

        /// <summary>
        /// 治疗结果2
        /// </summary>
        public string TreatResult2 = "";

        /// <summary>
        /// 治疗结果3
        /// </summary>
        public string TreatResult3 = "";

        /// <summary>
        /// 治疗结果4
        /// </summary>
        public string TreatResult4 = "";

        /// <summary>
        /// ICD编码(病理诊断1)
        /// </summary>
        public string ICDBLZD1 = "";

        /// <summary>
        /// 病理诊断1
        /// </summary>
        public string BLZDName1 = "";

        /// <summary>
        /// ICD编码(病理诊断2)
        /// </summary>
        public string ICDBLZD2 = "";

        /// <summary>
        /// 病理诊断2
        /// </summary>
        public string BLZDName2 = "";

        /// <summary>
        /// ICD编码(院内感染1)
        /// </summary>
        public string ICDYNGR1 = "";

        /// <summary>
        /// 院内感染1
        /// </summary>
        public string YNGRName1 = "";

        /// <summary>
        /// ICD编码(院内感染2)
        /// </summary>
        public string ICDYNGR2 = "";

        /// <summary>
        /// 院内感染2
        /// </summary>
        public string YNGRName2 = "";

        /// <summary>
        /// 门诊诊断与出院诊断
        /// </summary>
        public string OutPatientOutDia = "";

        /// <summary>
        /// 入院诊断与出院诊断
        /// </summary>
        public string InOutHospitalDia = "";

        /// <summary>
        /// 术前诊断与术后诊断
        /// </summary>
        public string BeforeAfterSurgeryDia = "";

        /// <summary>
        /// 放射诊断与术后诊断
        /// </summary>
        public string RadiationAfterDia = "";

        /// <summary>
        /// 临床诊断与病理诊断
        /// </summary>
        public string ClinicalPathologyDia = "";

        /// <summary>
        /// 病人年龄
        /// </summary>
        public string PatientAge = "";

        /// <summary>
        /// 病人户口所在地址
        /// </summary>
        public string PatientAddress = "";

        /// <summary>
        /// 科主任
        /// </summary>
        public string DeptDirector = "";

        /// <summary>
        /// 主（副）任医师
        /// </summary>
        public string DeptDoctor = "";

        /// <summary>
        /// 主治医师
        /// </summary>
        public string MainDoctor = "";

        /// <summary>
        /// 住院医师
        /// </summary>
        public string InHospitalDoctor = "";

        /// <summary>
        /// 进修医师
        /// </summary>
        public string AdvanceStudyDoctor = "";

        /// <summary>
        /// 研究生实习医师
        /// </summary>
        public string GraduatePracticeDoctor = "";

        /// <summary>
        /// 实习医师
        /// </summary>
        public string PracticeDoctor = "";

        /// <summary>
        /// 病案质量
        /// </summary>
        public string RecordQuality = "";

        /// <summary>
        /// 质控医师
        /// </summary>
        public string QCDoctor = "";

        /// <summary>
        /// 质控护士
        /// </summary>
        public string QCNurse = "";

        /// <summary>
        /// 手术操作日期1
        /// </summary>
        public DateTime? SurgeryDate1;

        /// <summary>
        /// 手术操作日期2
        /// </summary>
        public DateTime? SurgeryDate2;

        /// <summary>
        /// 手术操作日期3
        /// </summary>
        public DateTime? SurgeryDate3;

        /// <summary>
        /// 手术操作日期4
        /// </summary>
        public DateTime? SurgeryDate4;
        #endregion
    }
}
