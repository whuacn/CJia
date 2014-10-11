using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CJia.PIVAS.Models.DataManage
{
    /// <summary>
    /// �޸�ʱ�����ݵ�M��
    /// </summary>
    public class EditTimeSetModel : CJia.PIVAS.Tools.Model
    {
        /// <summary>
        /// �ж��޸�ʱ���Ƿ����ص� ����true��ʾ���ص� true��ʾû���ص�
        /// </summary>
        /// <param name="type">1�������� 2�����ҩ</param>
        /// <param name="timeId"></param>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="overTime">��ֹʱ��</param>
        /// <returns></returns>
        public bool IsUpdateRepeat(string type, long timeId, string startTime, string overTime)
        {
            object[] ob = new object[] { type, type, type, timeId, startTime, overTime };
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlIsUpdateRepeat,ob) == "1" ? false : true;
        }

        /// <summary>
        /// ���ʱ��ʱ �ж�Ҫ�޸ĵ�ʱ�����������ʱ����Ƿ��ص�  ����true��ʾ���ص� true��ʾû���ص�
        /// </summary>
        /// <param name="type">1�������� 2�����ҩ</param>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="overTime">��ֹʱ��</param>
        /// <returns></returns>
        public bool isInsertRepeat(string type, string startTime, string overTime)
        {
            object[] ob = new object[] { type, startTime, startTime, overTime, overTime, startTime, overTime };
            return CJia.DefaultOleDb.QueryScalar(SqlTools.SqlIsInsertRepeat, ob) == "1" ? true : false;
        }

        /// <summary>
        /// �޸�TimeSet�� true��ʾ�޸ĳɹ�
        /// </summary>
        /// <param name="timeName">ʱ������</param>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="overTime">��ֹʱ��</param>
        /// <param name="userId">��ǰ��¼�û�Id</param>
        /// <param name="timeId">ʱ��ID</param>
        /// <returns></returns>
        public bool UpdateTimeSet( string timeName, string startTime, string overTime, long userId, long timeId)
        {
            //if (overTime == null) overTime = "23:59";
            object[] ob = new object[] { timeName, startTime, overTime, userId, timeId };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlUpdateTimeSet, ob) > 0 ? true : false;
        }


        /// <summary>
        /// ���TimeSet��
        /// </summary>
        /// <param name="timeName">ʱ������</param>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="overTime">��ֹʱ��</param>
        /// <param name="whichpage">�ĸ�ҳ�� 1�������� 2�����ҩ</param>
        /// <param name="updateBy">�޸���</param>
        /// <returns></returns>
        public bool InsertTimeSet(string timeName, string startTime, string overTime, int whichpage, long updateBy )
        {
            object[] ob = new object[] { timeName, startTime, overTime, whichpage, updateBy };
            return CJia.DefaultOleDb.Execute(SqlTools.SqlInsertTimeSet, ob) > 0 ? true : false;
        }
    }
}