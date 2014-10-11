using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.Label
{
    /// <summary>
    /// ��ѯƿ��Model��
    /// </summary>
    public class QueryLabelModel : CJia.PIVAS.Tools.Model
    {

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
        public DataTable QueryLabelDetailByArrangeId(List<object> ArrangeIds, List<object> PharmTypes, List<object> Bacths, List<object> Bens, List<object> OrderBy)
        {
            string sql = this.CreateQueryLabelDetailSql(ArrangeIds, PharmTypes, Bacths, Bens, OrderBy);
            DataTable result = CJia.DefaultOleDb.Query(sql);
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
        public DataTable QueryPharmCollect(List<object> ArrangeIds, List<object> PharmTypes, List<object> Bacths, List<object> Bens, List<object> OrderBy)
        {
            string sql1 = this.CreateQueryLabelDetailSql(ArrangeIds, PharmTypes, Bacths, Bens, OrderBy);
            string sql2 = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryPharmCollect, sql1);
            DataTable result = CJia.DefaultOleDb.Query(sql2);
            return result;
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
            if(ArrangeIds != null && ArrangeIds.Count > 0)
            {
                foreach(string id in ArrangeIds.ToArray())
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
            if(PharmTypes != null && PharmTypes.Count > 0)
            {
                foreach(string id in PharmTypes)
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
            if(Bacths != null && Bacths.Count > 0)
            {
                foreach(string id in Bacths)
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
            if(Bens != null && Bens.Count > 0)
            {
                foreach(string id in Bens)
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
            if(OrderBy != null && OrderBy.Count > 0)
            {
                foreach(string id in OrderBy)
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
        public object GetLabelBarcode(object labelID,object labelPageNo,object labelAllPageNo,long userid)
        {
            string BarcodeSeq = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.Label.SqlTools.SqlQueryBarcodeSeq);
            object[] paramers = new object[] { BarcodeSeq, labelPageNo, labelAllPageNo, userid, labelID };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlInsertLabelBarcode, paramers);
            object[] paramers1 = new object[] { BarcodeSeq};
            DataTable result =  CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryBarCode, paramers1);
            return result;
        }

        /// <summary>
        /// �޸�ƿ����ӡ״̬
        /// </summary>
        public void UpdateLabelPrintStatus(object labelId)
        {
            object[] paramers = new object[] { labelId };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlUpdateLabelPrintStatus, paramers);
        }

        #endregion

    }
}