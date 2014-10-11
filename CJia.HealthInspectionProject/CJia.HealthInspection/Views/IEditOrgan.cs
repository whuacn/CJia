using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.HealthInspection.Views
{
    public interface IEditOrgan : CJia.HealthInspection.Tools.IPage
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.EditOrganArgs> OnInit;

        /// <summary>
        /// 保存事件
        /// </summary>
        event EventHandler<Views.EditOrganArgs> OnSave;

        /// <summary>
        /// 绑定界面树状结构
        /// </summary>
        /// <param name="dtTree"></param>
        void ExeBindTree(DataTable dtTree);

        /// <summary>
        /// 绑定控件
        /// </summary>
        /// <param name="dtOrgan"></param>
        void ExeBindControl(DataTable dtOrgan);

        /// <summary>
        /// 弹出信息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isCloseWindow">是否关闭当前窗口，true：关闭；false：不关闭</param>
        void ExeMessageBox(string message, bool isCloseWindow);
    }

    public class EditOrganArgs : EventArgs
    {
        /// <summary>
        /// 组织ID
        /// </summary>
        public string OrganId;

        /// <summary>
        /// 组织编号
        /// </summary>
        public string OrganNo;

        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrganName;

        /// <summary>
        /// 所属区域ID
        /// </summary>
        public string AreaId;

        /// <summary>
        /// 当前用户
        /// </summary>
        public string UserId;
    }
}
