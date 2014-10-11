using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CJia.Health.Views
{
    public interface IRoleFunctionView : CJia.Health.Tools.IView
    {
        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler<Views.RoleFunctionArgs> OnInit;

        /// <summary>
        /// 添加事件
        /// </summary>
        event EventHandler<Views.RoleFunctionArgs> OnAdd;

        /// <summary>
        /// 更新事件
        /// </summary>
        event EventHandler<Views.RoleFunctionArgs> OnUpdate;

        /// <summary>
        /// 删除事件
        /// </summary>
        event EventHandler<Views.RoleFunctionArgs> OnDelete;

        /// <summary>
        /// 点击Grid行事件
        /// </summary>
        event EventHandler<Views.RoleFunctionArgs> OnFocusedRowChanged;

        /// <summary>
        /// 查询
        /// </summary>
        event EventHandler<Views.UserArgs> OnSearch;
        /// <summary>
        /// 绑定用户类型
        /// </summary>
        /// <param name="dtUserType"></param>
        void ExeBindUserType(DataTable dtUserType);

        /// <summary>
        /// 绑定界面Grid
        /// </summary>
        /// <param name="dtGridRole"></param>
        void ExeBindGridRole(DataTable dtGridRole);
    }

    public class RoleFunctionArgs : EventArgs
    {
        /// <summary>
        /// 模块功能Id
        /// </summary>
        public long FunctionId;

        /// <summary>
        /// 模块功能名称
        /// </summary>
        public string FuncionName;

        /// <summary>
        /// 用户类型
        /// </summary>
        public long UserType;

        /// <summary>
        /// 所要修改原值
        /// </summary>
        public string ExistName;

        /// <summary>
        /// 查询关键字
        /// </summary>
        public string KeyWord;
    }
}
