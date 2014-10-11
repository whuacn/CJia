using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Models
{
    public class PatientInfoInputModel : CJia.Health.Tools.Model
    {

        #region 绑定界面下拉
        /// <summary>
        /// 查询性别
        /// </summary>
        /// <returns></returns>
        public DataTable QueryGender()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectGender);
        }

        /// <summary>
        /// 查询婚姻状况
        /// </summary>
        /// <returns></returns>
        public DataTable QueryIsMarry()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectIsMarry);
        }

        /// <summary>
        /// 查询职业
        /// </summary>
        /// <returns></returns>
        public DataTable QueryJob()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectJob);
        }

        /// <summary>
        /// 查询省
        /// </summary>
        /// <returns></returns>
        public DataTable QueryProvince()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectProvince);
        }

        /// <summary>
        /// 查找市
        /// </summary>
        /// <param name="provinceId">根据省筛选市</param>
        /// <returns></returns>
        //public DataTable QueryCity(string provinceId)
        //{
        //    List<object> sqlParams = new List<object>() { provinceId };
        //    return CJia.DefaultOleDb.Query(SqlTools.SqlSelectCity , sqlParams);
        //}
        //public DataTable QueryCity()
        //{
        //    return CJia.DefaultOleDb.Query(SqlTools.SqlSelectCity);
        //}

        /// <summary>
        /// 查找民族
        /// </summary>
        /// <returns></returns>
        public DataTable QueryNation()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectNation);
        }

        /// <summary>
        /// 查找国家
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCountry()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectCountry);
        }

        /// <summary>
        /// 查找入院方式
        /// </summary>
        /// <returns></returns>
        public DataTable QueryInHospitalType()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectInHospitalType);
        }

        /// <summary>
        /// 医生所属科室
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDept()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectDept);
        }

        /// <summary>
        /// 根据科室筛选医生
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDoctor()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectDoctor);
        }
       


        /// <summary>
        /// 查询ICD编码
        /// </summary>
        /// <returns></returns>
        public DataTable QueryICDCode()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectICDCode);
        }

        /// <summary>
        /// 查询治疗结果
        /// </summary>
        /// <returns></returns>
        public DataTable QueryTreatResult()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectTreatResult);
        }

        /// <summary>
        /// 查询血型
        /// </summary>
        /// <returns></returns>
        public DataTable QueryBloodType()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectBloodType);
        }

        /// <summary>
        /// 诊断结果
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDiagnosisResult()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectDiagnosisResult);
        }

        /// <summary>
        /// 病案质量
        /// </summary>
        /// <returns></returns>
        public DataTable QueryRecordQuality()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectRecordQuality);
        }
        #endregion

        /// <summary>
        /// 插入gm_patient病人基本信息
        /// </summary>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public bool InsertPatientInfo(List<object> sqlParams)
        {
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertGmPatient, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 修改gm_patient表基本信息
        /// </summary>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public bool UpdatePatientInfo(List<object> sqlParams)
        {
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateGmPatient, sqlParams) > 0 ? true : false;
        }

        /// <summary>
        /// 根据省筛选市
        /// </summary>
        /// <param name="selectedProvincId"></param>
        /// <returns></returns>
        public DataTable QueryCityByProvince(string selectedProvincId)
        {
            List<object> sqlParams = new List<object>() { selectedProvincId };
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectCityByProvince, sqlParams);
        }

        /// <summary>
        /// 根据所输内容模糊查询省
        /// </summary>
        /// <param name="selectedProvinc"></param>
        /// <returns></returns>
        public DataTable QueryProvinceBySearch(string selectedProvincSearch)
        {
            List<object> sqlParams = new List<object>() {  "%" + selectedProvincSearch + "%" };
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectProvinceBySearch, sqlParams);
        }

        /// <summary>
        /// 市模糊查询
        /// </summary>
        /// <param name="selectCitySearch"></param>
        /// <returns></returns>
        public DataTable QueryCityBySearch(string selectCitySearch)
        {
            List<object> sqlParams = new List<object>() {  "%" + selectCitySearch + "%" };
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectCityBySearch, sqlParams);
        }

        /// <summary>
        /// ICD编码模糊查询
        /// </summary>
        /// <param name="strFuzzySearch">搜索内容</param>
        /// <returns></returns>
        public DataTable QueryICDBySearch(string strFuzzySearch)
        {
            List<object> sqlParams = new List<object>() { "%" + strFuzzySearch + "%", "%" + strFuzzySearch + "%" };
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectICDBySearch,sqlParams);
        }

        /// <summary>
        /// 民族模糊查询
        /// </summary>
        /// <param name="strFuzzySearch"></param>
        /// <returns></returns>
        public DataTable QueryNationSearch(string strFuzzySearch)
        {
            List<object> sqlParams = new List<object>() { "%" + strFuzzySearch + "%", "%" + strFuzzySearch + "%" };
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectNationBySearch, sqlParams);
        }

        /// <summary>
        /// 国家模糊查询
        /// </summary>
        /// <param name="strFuzzySearch"></param>
        /// <returns></returns>
        public DataTable QueryCountrySearch(string strFuzzySearch)
        {
            List<object> sqlParams = new List<object>() { "%" + strFuzzySearch + "%", "%" + strFuzzySearch + "%" };
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectCountryBySearch, sqlParams);
        }

        /// <summary>
        /// 部门模糊查询
        /// </summary>
        /// <param name="strFuzzySearch"></param>
        /// <returns></returns>
        public DataTable QueryDeptBySearch(string strFuzzySearch)
        {
            List<object> sqlParams = new List<object>() { "%" + strFuzzySearch + "%", "%" + strFuzzySearch + "%" };
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectDeptBySearch,sqlParams);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFuzzySearch"></param>
        /// <returns></returns>
        public DataTable QueryDoctorBySearch(string strFuzzySearch)
        {
            List<object> sqlParams = new List<object>() { "%" + strFuzzySearch + "%", "%" + strFuzzySearch + "%", "%" + strFuzzySearch + "%" };
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectDoctorBySearch, sqlParams);
        }

        /// <summary>
        /// 查询页面所输病案号是否在库中存在
        /// </summary>
        /// <param name="recordNo"></param>
        /// <param name="inHospitalTime">入院次数</param>
        /// <returns></returns>
        public DataTable QueryIsExistRecordNo(string recordNo,int inHospitalTime)
        {
            object[] sqlParams = new object[] { recordNo,inHospitalTime };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryPatientByRecordNo,sqlParams);
        }

        /// <summary>
        /// 查询聚焦ComBox2所对应值
        /// </summary>
        /// <param name="comBox2Type"></param>
        /// <returns></returns>
        public DataTable QueryKeyPressComBox2(string comBox2Type)
        {
            object[] sqlParams = new object[] { comBox2Type };
            return CJia.DefaultOleDb.Query(SqlTools.SqlQueryGmCodeByComBox2,sqlParams);
        }

        /// <summary>
        /// 根据病案号和入院次数从接口中读取病人信息
        /// </summary>
        /// <param name="recordNo">病案号</param>
        /// <param name="inHospitalTime">入院次数</param>
        /// <returns></returns>
        public DataTable QueryPatientInfoFromInterface(string recordNo,int inHospitalTime)
        {
            //object[] sqlParams = new object[] { recordNo,inHospitalTime };
            //return CJia.DefaultOleDb.Query(SqlTools.SqlSelectPatientInfoFromInterface,sqlParams);
            return null;
        }
    }
}
