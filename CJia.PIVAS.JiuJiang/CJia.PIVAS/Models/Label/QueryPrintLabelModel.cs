using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.Label
{
    /// <summary>
    /// ��ѯƿ��Model��
    /// </summary>
    public class QueryPrintLabelModel : CJia.PIVAS.Tools.Model
    {


        /// <summary>
        /// ��ѯ���в���
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllIffield()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllIffield);
            return result;
        }

        /// <summary>
        /// ��ѯ��������
        /// </summary>
        /// <returns></returns>
        public DataTable QueryAllBatch()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.SqlTools.SqlQueryAllBacthLabel);
            return result;
        }


        /// <summary>
        /// ���ݰ�ҩ����ȡ��ҩ���µ�ƿ������
        /// </summary>
        /// <param name="ArrangeIds">��ҩ��id�б�</param>
        /// <param name="PharmTypes">�����б�</param>
        /// <param name="Bacths">�����б�</param>
        /// <param name="Bens">��λ�б�</param>
        /// <param name="OrderBy">�����б�</param>
        /// <returns>ƿ������</returns>
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
        ///// ����ƿ��
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
        /// ����ƿ��
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
        /// ��ѯδ��ӡ��ƿ��
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
        /// ��ȡĳ��İ�ҩ������
        /// </summary>
        /// <param name="dayDate">ÿ��ʱ��</param>
        /// <returns>��ҩ������</returns>
        public DataTable QueryArrangeCollect(DateTime dayDate)
        {
            object[] paramers = new object[] { dayDate };
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryArrangeCollect, paramers);
            return result;
        }

        /// <summary>
        /// ��ȡ����Щ��ҩ���µ�����ƿ��
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
        /// ���ݰ�ҩ����ȡ��ҩ���µ�ƿ������
        /// </summary>
        /// <param name="ArrangeIds">��ҩ��id�б�</param>
        /// <param name="PharmTypes">�����б�</param>
        /// <param name="Bacths">�����б�</param>
        /// <param name="Bens">��λ�б�</param>
        /// <param name="OrderBy">�����б�</param>
        /// <returns>ƿ������</returns>
        public DataTable QueryLabelDetailInfoByArrangeId(List<object> ArrangeIds, List<object> PharmTypes, List<object> Bacths, List<object> Bens, List<object> OrderBy)
        {
            string sql = this.CreateQueryLabelDetailInfoSql(ArrangeIds, PharmTypes, Bacths, Bens, OrderBy);
            DataTable result = CJia.DefaultOleDb.Query(sql);
            return result;
        }

        /// <summary>
        /// ��ѯ���в����������ε�ƿ��������Ϣ
        /// </summary>
        /// <param name="ArrangeIds">��ҩ��id�б�</param>
        /// <param name="PharmTypes">�����б�</param>
        /// <param name="Bacths">�����б�</param>
        /// <param name="Bens">��λ�б�</param>
        /// <param name="OrderBy">�����б�</param>
        /// <returns>ƿ��������Ϣ</returns>
        public DataTable QueryAllIllfieldBacthLabelCollectByArrangeId(List<object> ArrangeIds, List<object> PharmTypes, List<object> Bacths, List<object> Bens, List<object> OrderBy)
        {
            string sql1 = this.CreateQueryLabelDetailSql(ArrangeIds, PharmTypes, Bacths, Bens, OrderBy);
            string sql2 = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryAllIllfieldBacthLabelCollect, sql1);
            DataTable result = CJia.DefaultOleDb.Query(sql2);
            return result;
        }

        /// <summary>
        /// ��ѯҩƷ������Ϣ
        /// </summary>
        /// </summary>
        /// <param name="ArrangeIds">��ҩ��id�б�</param>
        /// <param name="PharmTypes">�����б�</param>
        /// <param name="Bacths">�����б�</param>
        /// <param name="Bens">��λ�б�</param>
        /// <param name="OrderBy">�����б�</param>
        /// <returns>ҩƷ������Ϣ</returns>
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
        /// ���ݰ�ҩ����ȡ��ҩ���µ�ƿ��������Ϣ
        /// </summary>
        /// <param name="ArrangeIds">��ҩ��id�б�</param>
        /// <param name="PharmTypes">�����б�</param>
        /// <param name="Bacths">�����б�</param>
        /// <param name="Bens">��λ�б�</param>
        /// <returns>ƿ��������Ϣ</returns>
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
        /// ��ѯ���е�ҩƷ����
        /// </summary>
        /// <returns>ҩƷ����</returns>
        public DataTable QueryAllPharmType()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryAllPharmType);
            return result;
        }

        /// <summary>
        /// ��ѯ���е�����
        /// </summary>
        /// <returns>����</returns>
        public DataTable QueryAllBacth()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryAllBacth);
            return result;
        }

        /// <summary>
        /// ƿ������
        /// </summary>
        /// <param name="labelId">ƿ��id</param>
        /// <param name="UserId">�û�id</param>
        public void DeleteLabel(string labelId, long UserId)
        {
            object[] paramers = new object[] { UserId, labelId };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlDeletePrintLable, paramers);
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlDeleteLabel, paramers);
        }

        #region ��������

        /// <summary>
        /// ���ɹ�����sql���
        /// </summary>
        /// <param name="ArrangeIds">��ҩ��id�б�</param>
        /// <param name="PharmTypes">�����б�</param>
        /// <param name="Bacths">�����б�</param>
        /// <param name="Bens">��λ�б�</param>
        /// <param name="OrderBy">�����б�</param>
        /// <returns>sql���</returns>
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
        /// ���ɹ�����sql���
        /// </summary>
        /// <param name="ArrangeIds">��ҩ��id�б�</param>
        /// <param name="PharmTypes">�����б�</param>
        /// <param name="Bacths">�����б�</param>
        /// <param name="Bens">��λ�б�</param>
        /// <param name="OrderBy">�����б�</param>
        /// <returns>sql���</returns>
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
        /// ���ݰ�ҩ��id���ذ�ҩ����������sql���
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
        /// ����ҩƷ���ͷ���ҩƷ���͹�������sql���
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
        /// �������η������ι�������sql���
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
        /// ���ݲ������ز�����������sql���
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
        /// ��������ʽ��������ʽsql���
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
        /// ��ƿ����������Ϣ������������� ������������id
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
        /// �޸�ƿ����ӡ״̬
        /// </summary>
        public void UpdateLabelPrintStatus(object labelId, DateTime date)
        {
            object[] paramers = new object[] { date, labelId };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlUpdateLabelPrintStatus, paramers);
        }

        /// <summary>
        /// �޸ĸ��������״̬
        /// </summary>
        /// <param name="labelId"></param>
        public void UpdateBarCodeStatus(object labelId)
        {
            object[] paramers = new object[] { 1000603, labelId };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlUpdateBarCodeStatusByLabelId, paramers);
        }

        ///// <summary>
        ///// ����ҽ�������his�п۷���
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
        //            if( result == "Successed��")
        //            {
        //                flag = "Successed��";
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
        ///// ����ҽ��id�۷ѿۿ��
        ///// </summary>
        ///// <param name="adviceId"></param>
        ///// <param name="userid"></param>
        ///// <returns></returns>
        //public string ExecuteAdviceIdFee(string adviceId, string userid)
        //{
        //    Dictionary<string, object> parms = new Dictionary<string, object>();
        //    parms.Add("I_ADVICE_ID", adviceId);
        //    parms.Add("I_USER_ID", "0234");//�ֽ׶�ʹ��Ĭ�ϵ��û�
        //    parms.Add("O_FLAG", "");
        //    CJia.DefaultOleDb.ExecuteProcedure("SP_PHARM_FEE", ref parms);
        //    string flag = parms["O_FLAG"].ToString();
        //    return flag;
        //}


        /// <summary>
        /// ��ѯƿ���Ŀ۷Ѵ���
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
        /// ����ƿ���Ƿ��ʹҩƷ����ز���
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