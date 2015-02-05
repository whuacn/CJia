using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.Label
{
    /// <summary>
    /// 查询瓶贴Model层
    /// </summary>
    public class QueryPrintLabelModel : CJia.PIVAS.Tools.Model
    {


        /// <summary>
        /// 查询所有病区
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllIffield()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllIffield);
            return result;
        }

        /// <summary>
        /// 查询所有批次
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllBatch()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllBacthLabel);
            return result;
        }


        /// <summary>
        /// 根据摆药单获取摆药单下的瓶贴详情
        /// </summary>
        /// <param name="ArrangeIds">摆药单id列表</param>
        /// <param name="PharmTypes">病区列表</param>
        /// <param name="Bacths">批次列表</param>
        /// <param name="Bens">床位列表</param>
        /// <param name="OrderBy">排序列表</param>
        /// <returns>瓶贴详情</returns>
        public DataTable QueryLabelDetail(int grOrDr, int selectDate, string illfieldID, string batchID, string print, string longTemporary, bool userCheckData, DateTime checkDataStart, DateTime checkDataEnd)
        {
            string newSql = CJia.PIVAS.Models.Label.SqlTools.SqlNewQueryLabelDetail;
            string illfieldStr = " and t.illfield_id in (" + illfieldID + ")  ";
            string batchStr = " and  t.batch_id in (" + batchID + ") ";

            string checkDataStr = "";
            if (userCheckData)
            {
                checkDataStr = "  and scd.check_date between ? and ?  ";
            }
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            if (grOrDr == 0)
            {
                if (selectDate == 0)
                {
                    str1 = "st_new_jin_pivas_label_view";
                    str2 = "sysdate";
                    str3 = "sysdate";
                    str4 = "nspl.list_doctor_date between trunc(sysdate) and trunc(sysdate + 1) ";
                }
            }
            else
            {
                if (selectDate == 0)
                {
                    str1 = "st_old_jin_pivas_label_view";
                    str2 = "sysdate";
                    str3 = "sysdate";
                    str4 = "nspl.list_doctor_date < trunc(sysdate) ";
                }
                else
                {
                    str1 = "st_old_ming_pivas_label_view";
                    str2 = "sysdate + 1";
                    str3 = "sysdate + 1";
                    str4 = "nspl.list_doctor_date < trunc(sysdate + 1) ";
                }
            }
            string printStr = " 1 = 1";
            if (print == "1")
            {
                printStr = " fn_is_print(t.group_index) = '1' ";
            }
            if (print == "0")
            {
                printStr = " fn_is_print(t.group_index) = '0' ";
            }
            if (print == "10")
            {
                printStr = " 1 =  1 ";
            }

            newSql = string.Format(newSql, str1, str2, str3, str4, printStr, illfieldStr, batchStr, checkDataStr);
            object[] parms;
            if (userCheckData)
            {
                parms = new object[] { longTemporary, checkDataStart, checkDataEnd };
            }
            else
            {
                parms = new object[] { longTemporary };
            }
            DataTable result = CJia.DefaultOleDb.Query(newSql, parms);
            return result;
        }

        ///// <summary>
        ///// 插入瓶贴
        ///// </summary>
        ///// <param name="illfieldID"></param>
        ///// <param name="batchID"></param>
        ///// <param name="print"></param>
        //public void InserLabel(string illfieldID, string batchID, string print)
        //{
        //    CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlNewDeleteTempLabel);

        //    string newSql = CJia.PIVAS.Models.Label.SqlTools.SqlNewInsertTempLabel;
        //    string illfieldStr = "";
        //    if(illfieldID != "0")
        //    {
        //        illfieldStr = " and stplv.illfield_id = '" + illfieldID + "'  ";
        //    }
        //    string batchStr = "";
        //    if(batchID != "0")
        //    {
        //        batchStr = " and  stplv.batch_id = " + batchID;
        //    }
        //    newSql = string.Format(newSql, illfieldStr, batchStr);
        //    object[] parms = new object[] { print };
        //    CJia.DefaultOleDb.Execute(newSql, parms);


        //    parms = new object[] { CJia.PIVAS.User.UserId };
        //    CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlNewInsertLabel, parms);

        //    CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlNewDeleteTempLabel);


        //}

        /// <summary>
        /// 插入瓶贴
        /// </summary>
        /// <param name="illfieldID"></param>
        /// <param name="batchID"></param>
        /// <param name="print"></param>
        public DataTable InserLabel(int selectDate, int grOrDr, DataTable groupIndexBatchId)
        {
            object[] parms;
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlNewDeleteTempLabel);

            string sql = CJia.PIVAS.Models.Label.SqlTools.SqlNewInsertTempLabel;

            if (grOrDr == 0)
            {
                if (selectDate == 0)
                {
                    sql = string.Format(sql, "st_new_jin_pivas_label_view");
                }
            }
            else
            {
                if (selectDate == 0)
                {
                    sql = string.Format(sql, "st_old_jin_pivas_label_view");
                }
                else
                {
                    sql = string.Format(sql, "st_old_ming_pivas_label_view");
                }
            }
            //if(selectDate == 0)
            //{
            //    sql = string.Format(sql, "st_old_temp_pivas_label_view");
            //}
            //else
            //{
            //    sql = string.Format(sql, "st_temp_pivas_label_view");                
            //}
            if (groupIndexBatchId != null && groupIndexBatchId.Rows != null && groupIndexBatchId.Rows.Count > 0)
            {
                foreach (DataRow row in groupIndexBatchId.Rows)
                {
                    parms = new object[] { row["GROUP_INDEX"].ToString(), row["BATCH_ID"].ToString() };
                    CJia.DefaultOleDb.Execute(sql, parms);
                }
            }

            parms = new object[] { CJia.PIVAS.User.UserId };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlNewInsertLabel, parms);

            //DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlNewQueryLabel);
            DataTable result = null;

            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlNewDeleteTempLabel);

            return result;
        }

        /// <summary>
        /// 查询未打印的瓶贴
        /// </summary>
        /// <param name="illfieldID"></param>
        /// <param name="batchID"></param>
        /// <param name="print"></param>
        public DataTable QueryGenLabel(int selectDate, int grOrDr, string illfieldID, string batchID, string print, bool userCheckData, DateTime checkDataStart, DateTime checkDataEnd)
        {
            string newSql = CJia.PIVAS.Models.Label.SqlTools.SqlNewQueryGenLabel;
            string illfieldStr = " and spl.illfield_id in (" + illfieldID + ")  ";

            string batchStr = " and  spl.batch_id in (" + batchID + ") ";

            string checkDataStr = "";
            if (userCheckData)
            {
                checkDataStr = " and sc.check_date between ? and  ?  ";
            }

            string str1 = "";
            string str2 = "";
            string str3 = "";
            //if(selectDate == 0)
            //{
            //    str1 = "sysdate";
            //    str2 = "sysdate";
            //}
            //else
            //{
            //    str1 = "sysdate + 1";
            //    str2 = "sysdate + 1";
            //}

            string printStr = "";
            if (print == "10")
            {
                printStr = " and 1 = 1 ";
            }
            else
            {
                printStr = " and fn_is_print(spl.group_index) = '" + print + "' ";
            }

            if (grOrDr == 0)
            {
                if (selectDate == 0)
                {
                    str1 = "sysdate";
                    str2 = "sysdate";
                    str3 = "spl.list_doctor_date between trunc(sysdate) and trunc(sysdate + 1) ";
                }
            }
            else
            {
                if (selectDate == 0)
                {
                    str1 = "sysdate";
                    str2 = "sysdate";
                    str3 = "spl.list_doctor_date < trunc(sysdate) ";
                }
                else
                {
                    str1 = "sysdate + 1";
                    str2 = "sysdate + 1";
                    str3 = "spl.list_doctor_date < trunc(sysdate + 1) ";
                }
            }

            newSql = string.Format(newSql, str1, str2, str3, printStr, illfieldStr, batchStr, checkDataStr);
            object[] parms;
            if (userCheckData)
            {
                parms = new object[] { checkDataStart, checkDataEnd };
            }
            else
            {
                parms = new object[] { };
            }
            DataTable reuslt = CJia.DefaultOleDb.Query(newSql, parms);
            return reuslt;
        }


        /// <summary>
        /// 获取某天的摆药单汇总
        /// </summary>
        /// <param name="dayDate">每天时间</param>
        /// <returns>摆药单汇总</returns>
        public DataTable QueryArrangeCollect(DateTime dayDate)
        {
            object[] paramers = new object[] { dayDate };
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryArrangeCollect, paramers);
            return result;
        }

        /// <summary>
        /// 获取该这些摆药单下的所有瓶贴
        /// </summary>
        /// <param name="ArrangeIds"></param>
        /// <returns></returns>
        public DataTable QuseryIffieldBed(List<object> ArrangeIds)
        {
            StringBuilder arrangeIds = this.GetArrangeIdsStr(ArrangeIds);
            StringBuilder pharmTypes = new StringBuilder("1 = 1");
            StringBuilder bacths = new StringBuilder("1 = 1");
            StringBuilder bens = new StringBuilder("1 = 1");
            StringBuilder orderBy = new StringBuilder("");

            string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryLabelDetailByArrangeId
                , arrangeIds.ToString()
                , pharmTypes.ToString()
                , bacths.ToString()
                , bens.ToString()
                , orderBy.ToString());
            return CJia.DefaultOleDb.Query(sql);
        }


        /// <summary>
        /// 根据摆药单获取摆药单下的瓶贴详情
        /// </summary>
        /// <param name="ArrangeIds">摆药单id列表</param>
        /// <param name="PharmTypes">病区列表</param>
        /// <param name="Bacths">批次列表</param>
        /// <param name="Bens">床位列表</param>
        /// <param name="OrderBy">排序列表</param>
        /// <returns>瓶贴详情</returns>
        public DataTable QueryLabelDetailInfoByArrangeId(List<object> ArrangeIds, List<object> PharmTypes, List<object> Bacths, List<object> Bens, List<object> OrderBy)
        {
            string sql = this.CreateQueryLabelDetailInfoSql(ArrangeIds, PharmTypes, Bacths, Bens, OrderBy);
            DataTable result = CJia.DefaultOleDb.Query(sql);
            return result;
        }

        /// <summary>
        /// 查询所有病房所有批次的瓶贴汇总信息
        /// </summary>
        /// <param name="ArrangeIds">摆药单id列表</param>
        /// <param name="PharmTypes">病区列表</param>
        /// <param name="Bacths">批次列表</param>
        /// <param name="Bens">床位列表</param>
        /// <param name="OrderBy">排序列表</param>
        /// <returns>瓶贴汇总信息</returns>
        public DataTable QueryAllIllfieldBacthLabelCollectByArrangeId(List<object> ArrangeIds, List<object> PharmTypes, List<object> Bacths, List<object> Bens, List<object> OrderBy)
        {
            string sql1 = this.CreateQueryLabelDetailSql(ArrangeIds, PharmTypes, Bacths, Bens, OrderBy);
            string sql2 = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryAllIllfieldBacthLabelCollect, sql1);
            DataTable result = CJia.DefaultOleDb.Query(sql2);
            return result;
        }

        /// <summary>
        /// 查询药品汇总信息
        /// </summary>
        /// </summary>
        /// <param name="ArrangeIds">摆药单id列表</param>
        /// <param name="PharmTypes">病区列表</param>
        /// <param name="Bacths">批次列表</param>
        /// <param name="Bens">床位列表</param>
        /// <param name="OrderBy">排序列表</param>
        /// <returns>药品汇总信息</returns>
        public DataTable QueryPharmCollect(string illfieldID, string batchID, string print)
        {
            //string newSql = CJia.PIVAS.Models.Label.SqlTools.SqlNewQueryLabelDetail;
            //string illfieldStr = "";
            //if(illfieldID != "0")
            //{
            //    illfieldStr = " and t.illfield_id = '" + illfieldID + "'  ";
            //}
            //string batchStr = "";
            //if(batchID != "0")
            //{
            //    batchStr = " and  t.batch_id = " + batchID;
            //}
            //newSql = string.Format(newSql, illfieldStr, batchStr);
            //object[] parms = new object[] { print };
            //DataTable result = CJia.DefaultOleDb.Query(newSql, parms);
            //return result;
            return null;
        }

        /// <summary>
        /// 根据摆药单获取白药单下的瓶贴汇总信息
        /// </summary>
        /// <param name="ArrangeIds">摆药单id列表</param>
        /// <param name="PharmTypes">病区列表</param>
        /// <param name="Bacths">批次列表</param>
        /// <param name="Bens">床位列表</param>
        /// <returns>瓶贴汇总信息</returns>
        public DataTable QueryLabelCollectByArrangeId(List<object> ArrangeIds, List<object> PharmTypes, List<object> Bacths, List<object> Bens)
        {
            StringBuilder arrangeIds = this.GetArrangeIdsStr(ArrangeIds);
            StringBuilder pharmTypes = this.GetPharmTypesStr(PharmTypes);
            StringBuilder bacths = this.GetBacthsStr(Bacths);
            StringBuilder bens = this.GetBensStr(Bens);

            string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryLabelCollectByArrangeId
                , arrangeIds.ToString()
                , pharmTypes.ToString()
                , bacths.ToString()
                , bens.ToString());
            DataTable result = CJia.DefaultOleDb.Query(sql);
            return result;
        }

        /// <summary>
        /// 查询所有的药品类型
        /// </summary>
        /// <returns>药品类型</returns>
        public DataTable QueryAllPharmType()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryAllPharmType);
            return result;
        }

        /// <summary>
        /// 查询所有的批次
        /// </summary>
        /// <returns>批次</returns>
        public DataTable QueryAllBacth()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryAllBacth);
            return result;
        }

        /// <summary>
        /// 瓶贴作废
        /// </summary>
        /// <param name="labelId">瓶贴id</param>
        /// <param name="UserId">用户id</param>
        public void DeleteLabel(string labelId, long UserId)
        {
            object[] paramers = new object[] { UserId, labelId };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlDeletePrintLable, paramers);
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlDeleteLabel, paramers);
        }

        #region 补助方法

        /// <summary>
        /// 生成过滤用sql语句
        /// </summary>
        /// <param name="ArrangeIds">摆药单id列表</param>
        /// <param name="PharmTypes">病区列表</param>
        /// <param name="Bacths">批次列表</param>
        /// <param name="Bens">床位列表</param>
        /// <param name="OrderBy">排序列表</param>
        /// <returns>sql语句</returns>
        private string CreateQueryLabelDetailSql(List<object> ArrangeIds, List<object> PharmTypes, List<object> Bacths, List<object> Bens, List<object> OrderBy)
        {
            StringBuilder arrangeIds = this.GetArrangeIdsStr(ArrangeIds);
            StringBuilder pharmTypes = this.GetPharmTypesStr(PharmTypes);
            StringBuilder bacths = this.GetBacthsStr(Bacths);
            StringBuilder bens = this.GetBensStr(Bens);
            StringBuilder orderBy = this.GetOrderByStr(OrderBy);

            string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryLabelDetailByArrangeId
                , arrangeIds.ToString()
                , pharmTypes.ToString()
                , bacths.ToString()
                , bens.ToString()
                , orderBy.ToString());
            return sql;
        }

        /// <summary>
        /// 生成过滤用sql语句
        /// </summary>
        /// <param name="ArrangeIds">摆药单id列表</param>
        /// <param name="PharmTypes">病区列表</param>
        /// <param name="Bacths">批次列表</param>
        /// <param name="Bens">床位列表</param>
        /// <param name="OrderBy">排序列表</param>
        /// <returns>sql语句</returns>
        private string CreateQueryLabelDetailInfoSql(List<object> ArrangeIds, List<object> PharmTypes, List<object> Bacths, List<object> Bens, List<object> OrderBy)
        {
            StringBuilder arrangeIds = this.GetArrangeIdsStr(ArrangeIds);
            StringBuilder pharmTypes = this.GetPharmTypesStr(PharmTypes);
            StringBuilder bacths = this.GetBacthsStr(Bacths);
            StringBuilder bens = this.GetBensStr(Bens);
            StringBuilder orderBy = this.GetOrderByStr(OrderBy);

            string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryLabelDetailInfoByArrangeId
                , arrangeIds.ToString()
                , pharmTypes.ToString()
                , bacths.ToString()
                , bens.ToString()
                , orderBy.ToString());
            return sql;
        }

        /// <summary>
        /// 根据摆药单id返回摆药单过滤条件sql语句
        /// </summary>
        /// <param name="ArrangeIds"></param>
        /// <returns></returns>
        public StringBuilder GetArrangeIdsStr(List<object> ArrangeIds)
        {
            StringBuilder arrangeIds = new StringBuilder(" spa.arrange_id in (");
            if (ArrangeIds != null && ArrangeIds.Count > 0)
            {
                foreach (string id in ArrangeIds.ToArray())
                {
                    arrangeIds.Append(id.ToString() + ",");
                }
                arrangeIds.Remove(arrangeIds.Length - 1, 1);
                arrangeIds.Append(") ");
            }
            else
            {
                arrangeIds = new StringBuilder(" 1 = 0 ");
            }
            return arrangeIds;
        }

        /// <summary>
        /// 根据药品类型返回药品类型过滤条件sql语句
        /// </summary>
        /// <param name="PharmTypes"></param>
        /// <returns></returns>
        public StringBuilder GetPharmTypesStr(List<object> PharmTypes)
        {
            StringBuilder pharmTypes = new StringBuilder(" spl.pivas_pharm_type  in (");
            if (PharmTypes != null && PharmTypes.Count > 0)
            {
                foreach (string id in PharmTypes)
                {
                    pharmTypes.Append(id + ",");
                }
                pharmTypes.Remove(pharmTypes.Length - 1, 1);
                pharmTypes.Append(") ");
            }
            else
            {
                pharmTypes = new StringBuilder(" 1 = 0 ");
            }
            return pharmTypes;
        }

        /// <summary>
        /// 根据批次返回批次过滤条件sql语句
        /// </summary>
        /// <param name="Bacths"></param>
        /// <returns></returns>
        public StringBuilder GetBacthsStr(List<object> Bacths)
        {
            StringBuilder bacths = new StringBuilder(" spl.batch_id  in (");
            if (Bacths != null && Bacths.Count > 0)
            {
                foreach (string id in Bacths)
                {
                    bacths.Append(id + ",");
                }
                bacths.Remove(bacths.Length - 1, 1);
                bacths.Append(") ");
            }
            else
            {
                bacths = new StringBuilder(" 1 = 0 ");
            }
            return bacths;
        }

        /// <summary>
        /// 根据病床返回病床过滤条件sql语句
        /// </summary>
        /// <param name="Bens"></param>
        /// <returns></returns>
        public StringBuilder GetBensStr(List<object> Bens)
        {
            StringBuilder bens = new StringBuilder(" (spl.illfield_id,spl.bed_id)  in (");
            if (Bens != null && Bens.Count > 0)
            {
                foreach (string id in Bens)
                {
                    bens.Append("(" + id + "),");
                }
                bens.Remove(bens.Length - 1, 1);
                bens.Append(") ");
            }
            else
            {
                bens = new StringBuilder(" 1 = 0 ");
            }
            return bens;
        }

        /// <summary>
        /// 根据排序方式返回排序方式sql语句
        /// </summary>
        /// <param name="OrderBy"></param>
        /// <returns></returns>
        public StringBuilder GetOrderByStr(List<object> OrderBy)
        {
            StringBuilder orderBy = new StringBuilder(" order by  ");
            if (OrderBy != null && OrderBy.Count > 0)
            {
                foreach (string id in OrderBy)
                {
                    orderBy.Append(id + ",");
                }
                orderBy.Remove(orderBy.Length - 1, 1);
            }
            else
            {
                orderBy = new StringBuilder("");
            }
            return orderBy;
        }


        /// <summary>
        /// 把瓶贴条形码信息插入条形码表中 并返回条形码id
        /// </summary>
        /// <param name="labelID"></param>
        /// <param name="labelPageNo"></param>
        /// <param name="labelAllPageNo"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public object GetLabelBarcode(object labelID, object labelPageNo, object labelAllPageNo, long userid)
        {
            string BarcodeSeq = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.Label.SqlTools.SqlQueryBarcodeSeq);
            object[] paramers = new object[] { BarcodeSeq, labelPageNo, labelAllPageNo, userid, CJia.PIVAS.User.UserName, userid, labelID };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlInsertLabelBarcode, paramers);
            object[] paramers1 = new object[] { BarcodeSeq };
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryBarCode, paramers1);
            return result;
        }

        /// <summary>
        /// 修改瓶贴打印状态
        /// </summary>
        public void UpdateLabelPrintStatus(object labelId, DateTime date)
        {
            object[] paramers = new object[] { date, labelId };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlUpdateLabelPrintStatus, paramers);
        }

        /// <summary>
        /// 修改该条形码的状态
        /// </summary>
        /// <param name="labelId"></param>
        public void UpdateBarCodeStatus(object labelId)
        {
            object[] paramers = new object[] { 1000603, labelId };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlUpdateBarCodeStatusByLabelId, paramers);
        }

        ///// <summary>
        ///// 根据医嘱组号在his中扣费用
        ///// </summary>
        ///// <param name="groupIndex"></param>
        ///// <param name="userid"></param>
        //public string ExecuteGroupIndexFee(string groupIndex,string userid)
        //{
        //    string flag = "";
        //    object[] paramers = new object[] { groupIndex};
        //    DataTable adviceids = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryAdviceIdByGroupIndex, paramers);
        //    if(adviceids != null && adviceids.Rows != null && adviceids.Rows.Count != 0)
        //    {
        //        foreach(DataRow row in adviceids.Rows)
        //        {
        //            string adviceId = row["ADVICE_ID"].ToString();
        //            string result = this.ExecuteAdviceIdFee(adviceId, userid);
        //            if( result == "Successed！")
        //            {
        //                flag = "Successed！";
        //            }
        //            else
        //            {
        //                flag = result;
        //            }
        //        }
        //    }
        //    return flag;
        //}

        ///// <summary>
        ///// 根据医嘱id扣费扣库存
        ///// </summary>
        ///// <param name="adviceId"></param>
        ///// <param name="userid"></param>
        ///// <returns></returns>
        //public string ExecuteAdviceIdFee(string adviceId, string userid)
        //{
        //    Dictionary<string, object> parms = new Dictionary<string, object>();
        //    parms.Add("I_ADVICE_ID", adviceId);
        //    parms.Add("I_USER_ID", "0234");//现阶段使用默认的用户
        //    parms.Add("O_FLAG", "");
        //    CJia.DefaultOleDb.ExecuteProcedure("SP_PHARM_FEE", ref parms);
        //    string flag = parms["O_FLAG"].ToString();
        //    return flag;
        //}


        /// <summary>
        /// 查询瓶贴的扣费次数
        /// </summary>
        /// <param name="labelId"></param>
        /// <returns></returns>
        public string QueryLabelTimes(string labelId)
        {
            object[] paramers = new object[] { labelId };
            string result = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.Label.SqlTools.SqlLabelTimes, paramers);
            if (string.IsNullOrEmpty(result))
            {
                result = "0";
            }
            return result;
        }

        /// <summary>
        /// 检查该瓶贴是否会使药品库存呢不足
        /// </summary>
        /// <param name="labelId"></param>
        /// <returns></returns>
        public DataTable QueryLabelPharmCount(string labelId)
        {
            object[] paramers = new object[] { labelId, labelId };
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryLabelPharmCount, paramers);
            return result;
        }

        #endregion


    }
}