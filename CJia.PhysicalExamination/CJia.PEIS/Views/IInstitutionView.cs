using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PEIS.Views
{
    public interface IInstitutionView:CJia.PEIS.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<InstitutionEventArgs> OnInit;

        /// <summary>
        /// 插入单位事件
        /// </summary>
        event EventHandler<InstitutionEventArgs> OnInsertIns;

        /// <summary>
        /// 更新单位事件
        /// </summary>
        event EventHandler<InstitutionEventArgs> OnUpdateIns;

        /// <summary>
        /// 绑定上级单位
        /// </summary>
        /// <param name="dtUpIns"></param>
        void ExeBindHigherIns(DataTable dtUpIns);

        /// <summary>
        /// 绑定单位性质
        /// </summary>
        /// <param name="dtInsType"></param>
        void ExeBindInsType(DataTable dtInsType);

        /// <summary>
        /// 绑定Grid单位信息
        /// </summary>
        /// <param name="dtGridIns"></param>
        void ExeBindGridIns(DataTable dtGridIns);
    }

    public class InstitutionEventArgs : EventArgs
    {
        #region 单位表字段名称
        /// <summary>
        /// 单位ID
        /// </summary>
        public long InsId = 0;

        /// <summary>
        /// 单位名称
        /// </summary>
        public string InsName = "";

        /// <summary>
        /// 单位类型
        /// </summary>
        public long InsType = 0;

        /// <summary>
        /// 上级单位ID
        /// </summary>
        public object HigherLevelId = null;

        /// <summary>
        /// 单位首拼
        /// </summary>
        public string InsFirstPinyin = "";

        /// <summary>
        /// 单位地址
        /// </summary>
        public string InsAddr = "";

        /// <summary>
        /// 单位电话
        /// </summary>
        public string InsPhone = "";

        /// <summary>
        /// 单位传真
        /// </summary>
        public string InsFax = "";

        /// <summary>
        /// 邮编
        /// </summary>
        public string InsPostCode = "";

        /// <summary>
        /// 单位人数
        /// </summary>
        public object InsNum = null;


        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string ContactName = "";

        /// <summary>
        /// 联系人部门
        /// </summary>
        public string ContactDept = "";

        /// <summary>
        /// 联系人电话
        /// </summary>
        public string ContactPhone = "";

        /// <summary>
        /// 联系人手机
        /// </summary>
        public string ContactMobilePhone = "";

        /// <summary>
        /// 
        /// </summary>
        public string ContactFax = "";

        /// <summary>
        /// 
        /// </summary>
        public string ContactEmail = "";

        /// <summary>
        /// 
        /// </summary>
        public string Remark = "";
        #endregion
    }
}
