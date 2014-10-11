using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Parking.Views
{
    public interface IMemberSetView : CJia.Parking.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.MemSetArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.MemSetArgs> OnSave;

        /// <summary>
        /// 删除事件
        /// </summary>
        event EventHandler<Views.MemSetArgs> OnDelete;

        /// <summary>
        /// 绑定界面Grid
        /// </summary>
        /// <param name="dtMemType"></param>
        void ExeGridMemType(DataTable dtMemType);
    }

    public class MemSetArgs : EventArgs
    {
        /// <summary>
        /// 会员类型流水号
        /// </summary>
        public long MemTypeId;

        /// <summary>
        ///  会员类型名称
        /// </summary>
        public string MemType;

        /// <summary>
        /// 类型价格
        /// </summary>
        public int Price;

        /// <summary>
        ///  原会员类型名称
        /// </summary>
        public string OldMemType;

        /// <summary>
        /// 保存按钮状态  “add”为添加，“update”为修改
        /// </summary>
        public string MemTypeSaveStatus = "add";
    }
}
