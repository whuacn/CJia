using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.Health.Views.Web
{
    public interface IApplyView : CJia.Health.Tools.IPage
    {
        /// <summary>
        /// 查询事件
        /// </summary>
        event EventHandler<ApplyEventArgs> OnSelectRecord;
        /// <summary>
        /// 提交申请事件
        /// </summary>
        event EventHandler<ApplyEventArgs> OnApply;
        /// <summary>
        /// 绑定病人病案基本信息
        /// </summary>
        /// <param name="data"></param>
        void ExeBindRecord(DataTable data);
    }
    /// <summary>
    /// 申请借阅参数
    /// </summary>
    public class ApplyEventArgs : EventArgs
    {
        /// <summary>
        /// 病人ID
        /// </summary>
        public string PatientID;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName;
        /// <summary>
        /// 病案号
        /// </summary>
        public string RecordNO;
        /// <summary>
        /// 登陆的用户信息
        /// </summary>
        public DataTable UserData;
    }
}
