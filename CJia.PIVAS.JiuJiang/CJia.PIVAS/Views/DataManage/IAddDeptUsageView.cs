using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CJia.PIVAS.Views.DataManage
{
    /// <summary>
    /// 添加病区对应用法接口
    /// </summary>
    public interface IAddDeptUsageView : CJia.PIVAS.Tools.IView
    {
        /// <summary>
        /// 页面初始化病区下拉框数据
        /// </summary>
        event EventHandler<AddDeptUsageEventArgs> OnInitLoadDept;

        /// <summary>
        /// 插入一条病区对应用法数据
        /// </summary>
        event EventHandler<AddDeptUsageEventArgs> OnInsertData;

        /// <summary>
        /// 点击病区下拉框的一行触发  根据获取到得病区id来得到对应没分配的用法ID
        /// </summary>
        event EventHandler<AddDeptUsageEventArgs> OnRowClick;

        /// <summary>
        /// 页面初始化载入病区数据
        /// </summary>
        /// <param name="dtDept"></param>
        void ExeInitLoadDept(DataTable dtDept);

        /// <summary>
        /// 页面初始化载入用法数据
        /// </summary>
        /// <param name="dtUsage"></param>
        void ExtLoadUsage(DataTable dtUsage);
    }

    public class AddDeptUsageEventArgs : EventArgs
    {
        /// <summary>
        /// 病区Id
        /// </summary>
        public string OfficeId; 
        
        /// <summary>
        /// 病区名称
        /// </summary>
        public string OfficeName;   

        /// <summary>
        /// 用法Id
        /// </summary>
        public long UsageId;        

        /// <summary>
        /// 用法名称
        /// </summary>
        public string UsageName;   

        /// <summary>
        /// 当前登录用户Id
        /// </summary>
        public long UserId;

        /// <summary>
        /// 是否选择了长期
        /// </summary>
        public bool ChecdLong;

        /// <summary>
        /// 是否选择了临时
        /// </summary>
        public bool ChecdTemporary;
    }
}