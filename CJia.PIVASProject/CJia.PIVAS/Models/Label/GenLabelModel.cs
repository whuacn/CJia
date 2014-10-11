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
        /// ��ѯ����ҩ����
        /// </summary>
        /// <returns>��ҩ����</returns>
        public DataTable QueryListCount()
        {
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryListCount);
            return result;
        }

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
            DataTable count = this.QueryListCount() ;
            if(count != null && count.Rows != null)
            {
                int countInt = count.Rows.Count;
                StringBuilder str = new StringBuilder("");
                for(int i = 1; i <= countInt; i++)
                {
                    str.Append(",decode(spa.arr_type,'" + i + "',spa.arrange_id,'') CREATE_ARRANGE_" + i);
                }
                string sql = string.Format(CJia.PIVAS.Models.Label.SqlTools.SqlQueryIffield, str.ToString());
                DataTable result = CJia.DefaultOleDb.Query(sql);
                return result;
            }
            return null;
        }

        /// <summary>
        /// ɾ����ʱƿ������û�������
        /// </summary>
        /// <param name="userid">�û�id</param>
        public void DeleteTempLabel(long userid)
        {
            object[] paramars = new object[] { userid };
            CJia.DefaultOleDb.Execute(CJia.PIVAS.Models.Label.SqlTools.SqlDeleteTempLabel,paramars);
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
                str.Append(" where illfield_id in (");
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
            object[] paramars = new object[] { userid };
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryTempLabelCollect, paramars);
            return result;
        }

        /// <summary>
        /// ��ѯ��ʱ��ƿ������
        /// </summary>
        /// <param name="userid">�û�id</param>
        /// <returns>��ʱ��ƿ������</returns>
        public DataTable QueryTempLabelDetail(long userid)
        {
            object[] paramars = new object[] { userid };
            DataTable result = CJia.DefaultOleDb.Query(CJia.PIVAS.Models.Label.SqlTools.SqlQueryTempLabelDetail, paramars);
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
        /// <param name="ArrangeId">��ҩ��id</param>
        /// <param name="userid">�û�id</param>
        /// <param name="illfieldId">����id</param>
        /// <param name="illfieldName">��������</param>
        /// <param name="timeid">��ҩid</param>
        public void InsertArrange(string tranid,long ArrangeId, long userid, string illfieldId,string illfieldName,string timeid)
        {
            object[] paramars = new object[] { ArrangeId, userid, illfieldId, illfieldName, userid, timeid };
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
            object[] paramars = new object[] { ArrangeId, userid, illfieldId, userid };
            CJia.DefaultOleDb.Execute(tranid,CJia.PIVAS.Models.Label.SqlTools.SqlInsertLabel, paramars);
        }

        /// <summary>
        /// �жϽ���������Ƿ��Ѿ����ɰ�ҩ��
        /// </summary>
        /// <param name="timeid">��ҩid</param>
        /// <param name="iffieldid">����id</param>
        /// <returns>�Ƿ����ɰ�ҩ��</returns>
        public bool QueryToDayIsGenLabel(string timeid,string iffieldid)
        {
            object[] paramars = new object[] { timeid, iffieldid };
            string str = CJia.DefaultOleDb.QueryScalar(CJia.PIVAS.Models.Label.SqlTools.SqlQueryIsGenArrange, paramars);
            if(str == "1")
            {
                return true;
            }
            return false;
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