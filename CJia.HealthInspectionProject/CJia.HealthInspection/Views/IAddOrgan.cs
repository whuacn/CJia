using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IAddOrgan : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.AddOrganArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.AddOrganArgs> OnSave;

        ///// <summary>
        ///// 绑定下拉角色
        ///// </summary>
        ///// <param name="dtArea"></param>
        //void ExeDropArea(DataTable dtArea);

        /// <summary>
        /// 绑定界面树状结构
        /// </summary>
        /// <param name="dtTree"></param>
        void ExeBindTree(DataTable dtTree);

         /// <summary>
        /// 弹出信息框
        /// </summary>
        /// <param name="message"></param>
        void ExeMessageBox(string message);
    }

    public class AddOrganArgs : EventArgs
    {
        /// <summary>
        /// 组织编号
        /// </summary>
        public string OrganNo;

        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrganName;

        /// <summary>
        /// 组织所属区域
        /// </summary>
        public string AreaId;

        /// <summary>
        /// 当前用户
        /// </summary>
        public string UserId;
    }
}
