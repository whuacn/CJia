using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Views
{
    public interface IMemberView : CJia.Parking.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.MemberArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.MemberArgs> OnSave;

        /// <summary>
        /// 删除事件
        /// </summary>
        event EventHandler<Views.MemberArgs> OnDelete;
        /// <summary>
        /// 绑定会员Grid
        /// </summary>
        /// <param name="dtMember"></param>
        void ExeGridMember(DataTable dtMember);
    }

    public class MemberArgs : EventArgs
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        public long MemId;

        /// <summary>
        /// 会员编号
        /// </summary>
        public string MemNo;

        /// <summary>
        /// 会员姓名
        /// </summary>
        public string MemName;

        /// <summary>
        /// 车牌号
        /// </summary>
        public string PlateNo;

        /// <summary>
        /// 会员原姓名
        /// </summary>
        public string OldMemName;

        /// <summary>
        /// 原车牌号码
        /// </summary>
        public string OldPlateNo;

        /// <summary>
        /// 保存按钮状态  “add”为添加，“update”为修改
        /// </summary>
        public string MemSaveStatus = "add";
    }
}
