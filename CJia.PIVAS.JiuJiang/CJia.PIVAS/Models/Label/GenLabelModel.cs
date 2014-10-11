using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.Label
{
    /// <summary>
    /// ����ƿ��Model
    /// </summary>
    public class GenLabelModel : CJia.PIVAS.Tools.Model
    {

        /// <summary>
        /// ��ѯ���ð�ҩ�İ�ҩ����Ϣ
        /// </summary>
        /// <param name="timeId">SM_TIME_SET  id  ���ظôΰ�ҩ����Ϣ</param>
        /// <returns>�ôΰ�ҩ����Ϣ</returns>
        public DataTable QueryListTime(string timeId)
        {
            object[] paramars = new object[]{timeId};
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryListTime, paramars);
            return result;
        }

        /// <summary>
        /// ��ѯ�����Լ��ò��������ɵİ�ҩ��
        /// </summary>
        /// <returns>�����Լ����ҩ����Ϣ</returns>
        public DataTable QueryIffield()
        {
                DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryIffield);
                return result;
        }

        /// <summary>
        /// ɾ����ʱƿ������û�������
        /// </summary>
        public void DeleteTempLabel()
        {
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlDeleteTempLabel);
        }

        /// <summary>
        /// ������ʱ��ƿ������
        /// </summary>
        /// <param name="iffieldId">ѡ�ŵĲ���</param>
        /// <param name="userid">�û�id</param>
        public void InsertTempLabel(List<string> iffieldId, long userid)
        {
            StringBuilder str = new StringBuilder("");
            if(iffieldId != null && iffieldId.Count > 0)
            {
                str.Append(" and illfield_id in (");
                foreach(string i in iffieldId)
                {
                    str.Append('\'');
                    str.Append(i.ToString());
                    str.Append('\'');
                    str.Append(",");
                }
                str.Remove(str.Length - 1, 1);
                str.Append(") ");
            }
            string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlInsertTempLabel, str);
            object[] paramars = new object[] { userid ,userid};
            CJia.DefaultOleDb.Execute(sql, paramars);
        }

        /// <summary>
        /// ��ѯ��ʱ��ƿ������
        /// </summary>
        /// <param name="userid">�û�id</param>
        /// <returns>��ʱ��ƿ������</returns>
        public DataTable QueryTempLabelCollect(long userid)
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryTempLabelCollect);
            return result;
        }

        /// <summary>
        /// ��ѯ��ʱ��ƿ������
        /// </summary>
        /// <param name="userid">�û�id</param>
        /// <returns>��ʱ��ƿ������</returns>
        public DataTable QueryTempLabelDetail(long userid)
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryTempLabelDetail);
            return result;
        }

        /// <summary>
        /// ����ƿ�����seq
        /// </summary>
        /// <returns>��ҩ��id</returns>
        public int QueryArrangeSeq()
        {
            return int.Parse( CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.Label.SqlTools.SqlQueryArrangeSeq).ToString());
        }
        
        /// <summary>
        /// �����ҩ����
        /// </summary>
        /// <param name="tranid"></param>
        /// <param name="ArrangeId"></param>
        /// <param name="userid"></param>
        /// <param name="illfieldId"></param>
        /// <param name="illfieldName"></param>
        public void InsertArrange(string tranid,long ArrangeId, long userid, string illfieldId,string illfieldName)
        {
            object[] paramars = new object[] { ArrangeId, userid, illfieldId, illfieldName, userid};
            CJia.DefaultOleDb.Execute(tranid,CJia.PIVAS.Models.Label.SqlTools.SqlInsertArrange, paramars);
        }

        /// <summary>
        /// ����ƿ����Ϣ
        /// </summary>
        /// <param name="ArrangeId">ƿ��id</param>
        /// <param name="userid">�û�id</param>
        /// <param name="illfieldId">����id</param>
        public void InsertLabel(string tranid, long ArrangeId, long userid, string illfieldId)
        {
            object[] paramars = new object[] { ArrangeId, userid, illfieldId };
            CJia.DefaultOleDb.Execute(tranid,CJia.PIVAS.Models.Label.SqlTools.SqlInsertLabel, paramars);
        }

        /// <summary>
        /// ���ݰ�ҩ���Ų�ѯ�������ɵ�ƿ��
        /// </summary>
        /// <param name="arrangeIds">��ҩ��id list</param>
        /// <returns>ƿ��</returns>
        public DataTable QueryGenLabel(List<long> arrangeIds)
        {
            StringBuilder str = new StringBuilder("");
            if(arrangeIds == null || arrangeIds.Count == 0)
            {
                str.Append("and 1 = 0");
            }
            else
            {
                str.Append("and spa.arrange_id in (");
                foreach(long lo in arrangeIds)
                {
                    str.Append(lo.ToString() + ",");
                }
                str.Remove(str.Length - 1, 1);
                str.Append(") ");
            }
            string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryGenLabel, str.ToString());
            return  CJia.DefaultOleDb.Query(sql);
        }

    }
}