//***************************************************
// 文件名（File Name）:      CancelApplyModel.cs
//
// 表（Tables）:            ST_PIVAS_LABEL_CANCEL_APPLY（配制中心瓶贴撤销申请记录表），
//                          ST_PIVAS_LABEL（配制中心瓶贴表）,
//                          ST_PIVAS_LABEL_DETAIL（配制中心瓶贴明细表）,
//                          ST_PIVAS_LABEL_CANCEL_RCP（配制中心瓶贴撤销单）
//                          SR_PIVAS_SET（病区表）
//
// 视图（Views）:           HM_PATIENT_VIEW(His数据库病人视图)
//                          CANCEL_APPLY_COMMON_VIEW（退药申请界面公共查询视图）
// 
// 作者（Author）:           曾翠玲
//
// 日期（Create Date）:     2013.1.22
// 
// 修改记录（Revision History）：
//               R1：
//                   修改作者：
//                   修改日期：
//                   修改理由：
//
//***************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Models
{
    /// <summary>
    /// 退药处理数据层
    /// </summary>
    public class CancelApplyModel:Tools.Model
    {
        /// <summary>
        /// 查询申请退药列表信息，绑定GridControl
        /// </summary>
        /// <param name="queryDate">查询日期</param>
        /// <param name="queryExeStatus">所选冲药状态</param>
        /// <param name="queryIllFieldId">所选择病区</param>
        /// <returns>申退医嘱</returns>
        public DataTable QueryGridByCancelApply(string queryDate, string queryExeStatus, string queryIllFieldId)
        {
            string queryStr = string.Format(SqlTools.SqlSelectCancelApply, queryDate, queryExeStatus, queryIllFieldId);
            return CJia.DefaultOleDb.Query(queryStr);
        }

        /// <summary>
        /// 病区查询，绑定病区筛选条件
        /// </summary>
        /// <returns>病区Id，病区Name</returns>
        public DataTable QueryOfficeName()
        {
            return CJia.DefaultOleDb.Query(SqlTools.SqlSelectOfficeName);
        }

        /// <summary>
        /// 取得退药表下一个Sequence
        /// </summary>
        /// <returns>退药表Sequence</returns>
        public long QueryNextCancelRCPId()
        {
            return long.Parse(CJia.DefaultOleDb.QueryScalar(SqlTools.SqlSelectNextCancelRCPId));
        }

        /// <summary>
        /// 同意退药时插入退药表
        /// </summary>
        /// <param name="cancelRCPSeq">退药单号</param>
        /// <param name="userId">退药审核人ID</param>
        /// <param name="userCode">退药审核人代码</param>
        /// <param name="userName">退药审核人名称</param>
        /// <param name="deptId">退药审核人部门ID</param>
        /// <param name="deptName">退药审核人部门名称</param>
        /// <returns>true：插入成功； false：插入失败</returns>
        public bool InsertCancelRCP(long cancelRCPSeq,long userId, string userCode, string userName, string deptId, string deptName)
        {
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                bool isSuccess = false;
                List<object> sqlParams = new List<object>();
                sqlParams.Add(cancelRCPSeq);
                sqlParams.Add(userId);
                sqlParams.Add(userCode);
                sqlParams.Add(userName);
                sqlParams.Add(deptId);
                sqlParams.Add(deptName);
                sqlParams.Add(userId);
                sqlParams.Add(userId);
                //sqlParams.Add(201301310001);
                //sqlParams.Add(1000000001);
                //sqlParams.Add("huyang");
                //sqlParams.Add("胡洋");
                //sqlParams.Add("1000000289");
                //sqlParams.Add("急诊输液室");
                //sqlParams.Add(1000000001);
                //sqlParams.Add(1000000001);
                isSuccess = CJia.DefaultOleDb.Execute(trans.ID,SqlTools.SqlInsertCancelRCP, sqlParams) > 0 ? true : false;
                trans.Complete();
                return isSuccess;
            }
        }

        /// <summary>
        /// 同意退药修改瓶贴表瓶贴状态
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="group_index">瓶贴所属组号</param>
        /// <returns></returns>
        public bool UpdatePivasLabelStatus(long userId, string group_index)
        {
            bool isSuccess = false;
            string group = string.Format(SqlTools.SqlUpdatePivasLabelStatus,group_index);
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                object[] sqlParams = new object[] { userId };
                isSuccess = CJia.DefaultOleDb.Execute(trans.ID, group, sqlParams) > 0 ? true : false;
                trans.Complete();
            }
            return isSuccess;
        }

        /// <summary>
        /// 同意退药时修改退药申请表瓶贴状态、瓶贴单号
        /// </summary>
        /// <param name="cancelRCPId">新生成退药单号</param>
        /// <param name="userName">用户名称</param>
        /// <param name="group_index">所选瓶贴所属组号</param>
        /// <returns></returns>
        public bool UpdateCancelApplyByAgree(long cancelRCPId, long userId, string group_index)
        {
            string group = string.Format(SqlTools.SqlUpdateCancelApply, group_index);
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                bool isSuccess = false;
                object[] sqlParams = new object[] { cancelRCPId, userId };
                isSuccess = CJia.DefaultOleDb.Execute(trans.ID, group, sqlParams) > 0 ? true : false;
                trans.Complete();
                return isSuccess;
            }
        }

        /// <summary>
        /// 拒绝退药时根据界面所选group_index修改退药表
        /// </summary>
        /// <param name="userId">用户名称</param>
        /// <param name="group_index"></param>
        /// <returns></returns>
        public bool UpdateCancelApplyByRefuse(long refuseRCPId, long userId, string group_index)
        {
            string group = string.Format(SqlTools.SqlUpdateRefuseApply, group_index);
            using (CJia.Transaction trans = new CJia.Transaction(CJia.DefaultOleDb.DefaultAdapter))
            {
                bool isSuccess = false;
                object[] sqlParams = new object[] { refuseRCPId,userId };
                isSuccess = CJia.DefaultOleDb.Execute(trans.ID, group, sqlParams) > 0 ? true : false;
                trans.Complete();
                return isSuccess;
            }
        }

        /// <summary>
        /// 打印所勾选的瓶贴药品
        /// </summary>
        /// <param name="group_index"></param>
        /// <returns></returns>
        public DataTable QueryPrintApplyCancelPharm(string group_index)
        {
            string group = string.Format(SqlTools.SqlSelectPrintApplyCancelPharm, group_index);
            return CJia.DefaultOleDb.Query(group);
        }

        /// <summary>
        /// 调用存储过程插负费用
        /// </summary>
        public void InsertNativeFeeCallPro()
        {

        }
    }
}
