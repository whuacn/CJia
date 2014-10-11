﻿//***************************************************
// 文件名（File Name）:      CheckAdviceModel.cs（审方Model层）
//
// 数据表（Tables）:         st_check_detail
// 视图(Views)               check_advice_view ,hm_patient_view
//
// 作者（Author）:           郭婷
//
// 日期（Create Date）:     2013.1.21
//***************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Models
{
    /// <summary>
    /// 审方Model层
    /// </summary>
    public class CheckAdviceModel : Tools.Model
    {
        /// <summary>
        /// 获取全部可进配置中心的病区
        /// </summary>
        /// <returns></returns>
        public DataTable GetOffice()
        {
            DataTable data = CJia.DefaultOleDb.Query(SqlTools.SqlSelectOffice);
            if (data != null && data.Rows.Count > 0)
            {
                return data;
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// 获取医嘱
        /// </summary>
        /// <param name="beginListDate"></param>
        /// <param name="endListDate"></param>
        /// <param name="officeId"></param>
        /// <param name="isValidCheck"></param>
        /// <param name="isAllCheck"></param>
        /// <param name="isNoCheck"></param>
        /// <param name="isYesCheck"></param>
        /// <param name="isTypeHLY"></param>
        /// <param name="isTypeKSS"></param>
        /// <param name="isTypeSSD"></param>
        /// <param name="isTypePTY"></param>
        /// <param name="checkPivasStatus"></param>
        /// <returns></returns>
        public DataTable GetAdviceData(DateTime beginListDate, DateTime endListDate, string officeId,bool isValidCheck,bool isAllCheck,bool isNoCheck,bool isYesCheck,bool isTypeHLY,bool isTypeKSS,bool isTypeSSD,bool isTypePTY,int checkPivasStatus)
        {
            //定义Sql语句
            string SqlSelectAdvice = SqlTools.SqlSelectAdvice;
            if (officeId == "0")          //全部病区
            {
                SqlSelectAdvice = string.Format(SqlTools.SqlSelectAdvice, "0 = ? ");
            }
            else if (officeId != "0")     //某一病区
            {
                SqlSelectAdvice = string.Format(SqlTools.SqlSelectAdvice, "cav.PATIENT_ILLFILED_CODE= ?  ");
            }
            if (isAllCheck)//所有
            {
                SqlSelectAdvice = SqlSelectAdvice + " and cav.check_pivas_status in(1000101,1000102) ";
            }
            else if (isValidCheck)//无效
            {
                SqlSelectAdvice = SqlSelectAdvice + " and cav.check_pivas_status in(1000104,1000103)";
            }
            else if (isYesCheck || isNoCheck)//已审 未审
            {
                SqlSelectAdvice = SqlSelectAdvice + " and cav.check_pivas_status = "+ checkPivasStatus;
            }
            string type = "";
            if (isTypeHLY) //化疗药
            {
                type = type + 1000201+",";
            }
            if (isTypeKSS)//抗生素
            {
                type = type + 1000202 + ",";
            }
            if (isTypeSSD)//三升袋
            {
                type = type + 1000203 + ",";
            }
            if (isTypePTY)
            {
                type = type + 1000204+",";
            }
            if (type == "") 
                return null;
            else
            {
                type = type.Substring(0, type.Length - 1);
                SqlSelectAdvice = SqlSelectAdvice + " and cav.GROUP_PHARM_TYPE in (" + type + ")";
                object[] sqlParams = new object[] { beginListDate, endListDate, officeId };
                DataTable dtResult = CJia.DefaultOleDb.Query(SqlSelectAdvice, sqlParams);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    return dtResult;
                }
                else
                {
                    return null;

                }
            }           
        }      
        
        /// <summary>
        /// 根据医嘱组编号查询审核明细表
        /// </summary>
        /// <param name="groupIndex"></param>
        /// <returns></returns>
        public DataTable GetCheckDetailDataByGroupIndex(string groupIndex)
        {
            List<object> objects = new List<object>();
            objects.Add(groupIndex);
            DataTable dtResult = CJia.DefaultOleDb.Query(Models.SqlTools.SqlSelectCheckDetailByGroupIndex, objects);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得CheckSeq值
        /// </summary>
        /// <returns>返回bool类型</returns>
        public int GetCheckSeq()
        {
            int seq = int.Parse(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlGetCheckSeq));
            return seq;
        }

        /// <summary>
        /// 添加检查表
        /// </summary>
        public void AddCheck(string transID,int checkId,long userId, string userCode, string userName, string deptId, string deptName,long createBy)
        {
            object[] sqlParams = new object[] {checkId, userId, userCode, userName, deptId, deptName, createBy };
            CJia.DefaultOleDb.Execute(transID, SqlTools.SqlInsertCheck, sqlParams);
        }
        
        /// <summary>
        /// 获得CheckDetailSeq值
        /// </summary>
        /// <returns>返回bool类型</returns>
        public int GetCheckDetailSeq()
        {
            int seq = int.Parse(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlGetCheckDetailSeq));
            return seq;
        }
        
        /// <summary>
        /// 添加检查明细表
        /// </summary>
        /// <returns>返回bool类型</returns>
        public void AddCheckDetail(string transID,int checkSeq,string groupIndex,int originalPivasStatus,int checkPivasStatus,string originalPivasBatchNo, string checkPivasBatchNo, long createBy, string cancelReason)
        {
            object[] sqlParams = new object[] { checkSeq, groupIndex,originalPivasStatus, checkPivasStatus,originalPivasBatchNo, checkPivasBatchNo, createBy, cancelReason };
            CJia.DefaultOleDb.Execute(transID, SqlTools.SqlInsertCheckDetail, sqlParams);
        }

        /// <summary>
        /// 批量查询审核明细表中的未审医嘱
        /// </summary>
        /// <returns></returns>
        public DataTable GetCheckDetail(DateTime beginDate, DateTime endDate, string officeId)
        {
            string sqlCheckDetail = SqlTools.SqlCheckDetail;
            if (officeId == "0")          //全部病区
            {
                sqlCheckDetail = string.Format(SqlTools.SqlCheckDetail, "0 = ? ");
            }
            else if (officeId != "0")     //某一病区
            {
                sqlCheckDetail = string.Format(SqlTools.SqlCheckDetail, "hav.PATIENT_ILLFILED_CODE= ?  ");
            }
            object[] sqlParams = new object[] { beginDate, endDate, officeId };
            DataTable dtResult = CJia.DefaultOleDb.Query(sqlCheckDetail, sqlParams);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 批量查询审核明细表中的已审医嘱
        /// </summary>
        /// <returns></returns>
        public DataTable GetYesCheckDetail(DateTime beginDate, DateTime endDate, string officeId)
        {
            string sqlYesCheckDetail = SqlTools.SqlYesCheckDetail;
            if (officeId == "0")          //全部病区
            {
                sqlYesCheckDetail = string.Format(SqlTools.SqlYesCheckDetail, "0 = ? ");
            }
            else if (officeId != "0")     //某一病区
            {
                sqlYesCheckDetail = string.Format(SqlTools.SqlYesCheckDetail, "hav.PATIENT_ILLFILED_CODE= ?  ");
            }
            object[] sqlParams = new object[] { beginDate, endDate, officeId };
            DataTable dtResult = CJia.DefaultOleDb.Query(sqlYesCheckDetail, sqlParams);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询需要批量插入的数据
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="officeId"></param>
        /// <returns></returns>
        public DataTable GetBatchData(DateTime beginDate, DateTime endDate, string officeId)
        {
            string sqlBatchData = SqlTools.SqlBatchData;
            if (officeId == "0")          //全部病区
            {
                sqlBatchData = string.Format(SqlTools.SqlBatchData, "0 = ? ");
            }
            else if (officeId != "0")     //某一病区
            {
                sqlBatchData = string.Format(SqlTools.SqlBatchData, "hav.PATIENT_ILLFILED_CODE= ?  ");
            }
            object[] sqlParams = new object[] {beginDate, endDate, officeId };
            DataTable dtResult = CJia.DefaultOleDb.Query(sqlBatchData, sqlParams);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
       
        /// <summary>
        /// 批量插入审核明细
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="checkId"></param>
        /// <param name="createBy"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="officeId"></param>
        /// <param name="checkPivasStatus"></param>
        /// <returns></returns>
        public void BatchAddCheckDetail(string transID, long checkId,int checkPivasStatus, long createBy, DateTime beginDate, DateTime endDate,string officeId)
        {
            string sqlBatchInsertCheckDetail = SqlTools.SqlBatchInsertCheckDetail;
            if (officeId == "0")          //全部病区
            {
                sqlBatchInsertCheckDetail = string.Format(SqlTools.SqlBatchInsertCheckDetail, "0 = ? ");
            }
            else if (officeId != "0")     //某一病区
            {
                sqlBatchInsertCheckDetail = string.Format(SqlTools.SqlBatchInsertCheckDetail, "hav.PATIENT_ILLFILED_CODE= ?  ");
            }
            object[] sqlParams = new object[] { checkId,checkPivasStatus, createBy, beginDate, endDate, officeId};
            CJia.DefaultOleDb.Execute(transID, sqlBatchInsertCheckDetail, sqlParams);
        }
        
        /// <summary>
        /// 根据组号查询审核明细ID
        /// </summary>
        /// <param name="groupIndex"></param>
        /// <returns></returns>
        public int GetDetailIdByGroupIndex(string groupIndex)
        {
            object[] sqlParams = new object[] { groupIndex };
            return int.Parse(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlSelectDetailIdByGroupIndex, sqlParams));         
        }

        /// <summary>
        /// 根据组号将审核明细表的数据置为无效
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="updateBy"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="officeId"></param>
        /// <param name="groupIndexs"></param>
        public void ModifyCheckDetail(string transID, long updateBy, DateTime beginDate, DateTime endDate, string officeId, List<string> groupIndexs)
        {
            string sqlUpdateCheckDetail = CJia.PIVAS.Models.SqlTools.SqlUpdateCheckDetailToValid;
            if (officeId == "0")          //全部病区
            {
                sqlUpdateCheckDetail = string.Format(SqlTools.SqlUpdateCheckDetailToValid, "0 = ? ");
            }
            else if (officeId != "0")     //某一病区
            {
                sqlUpdateCheckDetail = string.Format(SqlTools.SqlUpdateCheckDetailToValid, "hav.PATIENT_ILLFILED_CODE= ?  ");
            }
            StringBuilder str = new StringBuilder("");
            if (groupIndexs != null && groupIndexs.Count != 0)
            {
                str.Append("and scd.group_index in (");
                foreach (string groupIndex in groupIndexs)
                {
                    str.Append( "'" + groupIndex.ToString() + "'");
                    str.Append(",");
                }
                str.Remove(str.Length - 1, 1);
                str.Append(")");
            }
            sqlUpdateCheckDetail = sqlUpdateCheckDetail + str.ToString();
            object[] sqlParams = new object[] { updateBy, beginDate, endDate, officeId };
            CJia.DefaultOleDb.Execute(transID, sqlUpdateCheckDetail, sqlParams);
        }
        
        /// <summary>
        /// 根据明细ID将审核明细数据置为无效
        /// </summary>
        /// <returns></returns>
        public void ModifyCheckDetailValid(string transID,long updateBy, int detailId)
        {
            object[] sqlParams = new object[] { updateBy,detailId};
            CJia.DefaultOleDb.Execute(transID, SqlTools.SqlUpdateCheckDetailValid, sqlParams);
        }
        
        /// <summary>
        /// 批量将审核明细数据置为无效
        /// </summary>
        /// <param name="transID"></param>
        /// <param name="updateBy"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="officeId"></param>
        /// <returns></returns>
        public bool BatchModifyCheckDetailValid(string transID, long updateBy, DateTime beginDate, DateTime endDate, string officeId)
        {
            string sqlBatchUpdateCheckDetailValid = SqlTools.SqlBatchUpdateCheckDetailValid;
            if (officeId == "0")          //全部病区
            {
                sqlBatchUpdateCheckDetailValid = string.Format(SqlTools.SqlBatchUpdateCheckDetailValid, "0 = ? ");
            }
            else if (officeId != "0")     //某一病区
            {
                sqlBatchUpdateCheckDetailValid = string.Format(SqlTools.SqlBatchUpdateCheckDetailValid, "hav.PATIENT_ILLFILED_CODE= ?  ");
            }
            object[] sqlParams = new object[] { updateBy, beginDate, endDate ,officeId};
            bool isSuccess = CJia.DefaultOleDb.Execute(transID, sqlBatchUpdateCheckDetailValid, sqlParams) > 0 ? true : false;
            return isSuccess;
        }
        
        /// <summary>
        /// 修改审核明细表
        /// </summary>
        /// <returns>返回bool类型</returns>
        public void ModifyCheckDetail(string transID,int checkSeq, int originalPivasStatus, int checkPivasStatus, string originalPivasBatchNo, string checkPivasBatchNo,long updateBy, string cancelReason, int detailId)
        {
            object[] sqlParams = new object[] { checkSeq, originalPivasStatus, checkPivasStatus, originalPivasBatchNo, checkPivasBatchNo, updateBy, cancelReason, detailId };
            CJia.DefaultOleDb.Execute(transID,SqlTools.SqlUpdateCheckDetail, sqlParams);
        }
        
        /// <summary>
        /// 根据住院号查询病人信息
        /// </summary>
        /// <param name="inhosId">住院号</param>
        /// <returns></returns>
        public DataTable GetPatientDataByInhosId(string inhosId)
        {
            List<object> objects = new List<object>();
            objects.Add(inhosId);
            DataTable dtResult = CJia.DefaultOleDb.Query(Models.SqlTools.SqlSelectPatientByInhosId, objects);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// 根据住院号查询病人病史信息（医嘱）
        /// </summary>
        /// <param name="inhosId">住院号</param>
        /// <returns></returns>
        public DataTable GetPatientHistoryDataByInhosId(string inhosId)
        {
            List<object> objects = new List<object>();
            objects.Add(inhosId);
            DataTable dtResult = CJia.DefaultOleDb.Query(Models.SqlTools.SqlSelectPatientHistoryByInhosId, objects);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询配置中心没有的药品
        /// </summary>
        /// <returns></returns>
        public DataTable GetPharmNotInPivas()
        {
            DataTable dtResult = CJia.DefaultOleDb.Query(Models.SqlTools.SqlSelectPharmNotInPivas);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除固定瓶贴
        /// </summary>
        /// <param name="tranID"></param>
        /// <param name="groupIndexs"></param>
        public void DeleteCommonLabel(string tranID, List<string> groupIndexs)
        {
            StringBuilder str = new StringBuilder("");
            if (groupIndexs != null && groupIndexs.Count != 0)
            {
                str.Append("where scd.group_index in (");
                foreach (string groupIndex in groupIndexs)
                {
                    str.Append("'" + groupIndex.ToString() + "'");
                    str.Append(",");
                }
                str.Remove(str.Length - 1, 1);
                str.Append(")");
            }
            string sql = CJia.PIVAS.Models.SqlTools.SqlDeleteCommonLabel;
            sql = string.Format(sql, str.ToString());
            CJia.DefaultOleDb.Execute(tranID, sql);
        }

        /// <summary>
        /// 插入固定瓶贴
        /// </summary>
        /// <param name="tranID"></param>
        /// <param name="groupIndexs"></param>
        /// <param name="userId"></param>
        public void InsertCommonLabel(string tranID, List<string> groupIndexs, long userId)
        {
            if (groupIndexs != null && groupIndexs.Count != 0)
            {
                foreach (string groupIndex in groupIndexs)
                {
                    object[] sqlParams = new object[] { userId, groupIndex, groupIndex };
                    CJia.DefaultOleDb.Execute(tranID, CJia.PIVAS.Models.SqlTools.SqlInsertCommonLabel, sqlParams);
                }
            }
        }

        /// <summary>
        /// 插入瓶贴详情信息
        /// </summary>
        /// <param name="tranID"></param>
        /// <param name="groupIndexs"></param>
        public void InsertLabelDetail(string tranID, List<string> groupIndexs)
        {
            if(groupIndexs != null && groupIndexs.Count != 0)
            {
                foreach(string groupIndex in groupIndexs)
                {
                    object[] sqlParams = new object[] {  groupIndex, groupIndex };
                    CJia.DefaultOleDb.Execute(tranID, CJia.PIVAS.Models.SqlTools.SqlInsertLabelDetail, sqlParams);
                }
            }
        }
    }
}
